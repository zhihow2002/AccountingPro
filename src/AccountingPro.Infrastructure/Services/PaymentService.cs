using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Core.Enums;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly AccountingDbContext _context;
    private readonly IInvoiceService _invoiceService;

    public PaymentService(AccountingDbContext context, IInvoiceService invoiceService)
    {
        _context = context;
        _invoiceService = invoiceService;
    }

    public async Task<List<PaymentDto>> GetPaymentsByCompanyAsync(int companyId)
    {
        return await _context.Payments
            .Include(p => p.Customer)
            .Include(p => p.Invoice)
            .Where(p => p.CompanyId == companyId && !p.IsDeleted)
            .OrderByDescending(p => p.PaymentDate)
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                PaymentNumber = p.PaymentNumber,
                PaymentDate = p.PaymentDate,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                Status = p.Status,
                Reference = p.Reference,
                Notes = p.Notes,
                CompanyId = p.CompanyId,
                CustomerId = p.CustomerId,
                InvoiceId = p.InvoiceId,
                CustomerName = p.Customer != null ? p.Customer.Name : "",
                InvoiceNumber = p.Invoice != null ? p.Invoice.InvoiceNumber : ""
            })
            .ToListAsync();
    }

    public async Task<PaymentDto?> GetPaymentByIdAsync(int id)
    {
        return await _context.Payments
            .Include(p => p.Customer)
            .Include(p => p.Invoice)
            .Where(p => p.Id == id && !p.IsDeleted)
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                PaymentNumber = p.PaymentNumber,
                PaymentDate = p.PaymentDate,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                Status = p.Status,
                Reference = p.Reference,
                Notes = p.Notes,
                CompanyId = p.CompanyId,
                CustomerId = p.CustomerId,
                InvoiceId = p.InvoiceId,
                CustomerName = p.Customer != null ? p.Customer.Name : "",
                InvoiceNumber = p.Invoice != null ? p.Invoice.InvoiceNumber : ""
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Payment> CreatePaymentAsync(CreatePaymentReceiptDto dto, int companyId)
    {
        var payment = new Payment
        {
            PaymentNumber = await GeneratePaymentNumberAsync(companyId),
            PaymentDate = dto.PaymentDate,
            Amount = dto.Amount,
            PaymentMethod = dto.Method,
            Status = PaymentStatus.Completed,
            Reference = dto.Reference,
            Notes = dto.Notes,
            CompanyId = companyId,
            CustomerId = dto.CustomerId,
            InvoiceId = dto.InvoiceId,
            BankAccountId = dto.BankAccountId,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        // Update invoice if payment is linked
        if (dto.InvoiceId.HasValue)
        {
            var invoice = await _context.Invoices.FindAsync(dto.InvoiceId.Value);
            if (invoice != null)
            {
                invoice.PaidAmount += dto.Amount;
                invoice.BalanceAmount = invoice.TotalAmount - invoice.PaidAmount;
                
                if (invoice.BalanceAmount <= 0)
                {
                    invoice.Status = InvoiceStatus.Paid;
                }
                else if (invoice.PaidAmount > 0)
                {
                    invoice.Status = InvoiceStatus.PartiallyPaid;
                }

                invoice.UpdatedAt = DateTime.UtcNow;
                invoice.UpdatedBy = "System";
                await _context.SaveChangesAsync();
            }
        }

        return payment;
    }

    public async Task<Payment> CreateCashSaleAsync(CashSaleDto dto, int companyId)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        
        return await strategy.ExecuteAsync(async () =>
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                // Get company config for tax settings
                var companyConfig = await _context.Companies
                    .AsNoTracking()
                    .Where(c => c.Id == companyId)
                    .Select(c => new { c.EnableInvoiceTax })
                    .FirstOrDefaultAsync();

                var applyTax = companyConfig?.EnableInvoiceTax ?? true;

                // Generate invoice number
                var lastInvoice = await _context
                    .Invoices.Where(i => i.CompanyId == companyId)
                    .OrderByDescending(i => i.Id)
                    .FirstOrDefaultAsync();

                var invoiceNumber = $"INV-{DateTime.Now:yyyyMM}-{(lastInvoice?.Id ?? 0) + 1:D4}";

                // Create invoice directly (don't use InvoiceService to avoid nested transactions)
                var invoice = new Invoice
                {
                    InvoiceNumber = invoiceNumber,
                    CustomerId = dto.CustomerId.HasValue && dto.CustomerId.Value > 0 ? dto.CustomerId.Value : 0,
                    CompanyId = companyId,
                    InvoiceDate = dto.SaleDate,
                    DueDate = dto.SaleDate, // Cash sale - due immediately
                    DiscountAmount = 0,
                    Notes = dto.Notes,
                    Status = InvoiceStatus.Paid, // Mark as paid immediately
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                // Add invoice items
                foreach (var itemDto in dto.Items)
                {
                    var lineSubTotal = itemDto.Quantity * itemDto.UnitPrice;
                    var effectiveTaxRate = applyTax ? itemDto.TaxRate : 0;
                    var taxAmount = applyTax ? lineSubTotal * (effectiveTaxRate / 100) : 0;

                    var invoiceItem = new InvoiceItem
                    {
                        ProductId = itemDto.ProductId == 0 ? null : itemDto.ProductId,
                        Description = itemDto.Description,
                        Quantity = itemDto.Quantity,
                        UnitPrice = itemDto.UnitPrice,
                        TaxRate = effectiveTaxRate,
                        TaxAmount = taxAmount,
                        LineTotal = lineSubTotal + taxAmount,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "System"
                    };
                    invoice.InvoiceItems.Add(invoiceItem);
                }

                // Calculate totals
                invoice.SubTotal = invoice.InvoiceItems.Sum(i => i.Quantity * i.UnitPrice);
                invoice.TaxAmount = invoice.InvoiceItems.Sum(i => i.TaxAmount);
                invoice.TotalAmount = invoice.SubTotal + invoice.TaxAmount - invoice.DiscountAmount;
                invoice.PaidAmount = invoice.TotalAmount; // Fully paid
                invoice.BalanceAmount = 0; // No balance

                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();

                // Create payment for the invoice
                var payment = new Payment
                {
                    PaymentNumber = await GeneratePaymentNumberAsync(companyId),
                    PaymentDate = dto.SaleDate,
                    Amount = dto.TotalAmount,
                    PaymentMethod = dto.Method,
                    Status = PaymentStatus.Completed,
                    Reference = dto.Reference,
                    Notes = $"Cash Sale - {dto.Notes}",
                    CompanyId = companyId,
                    CustomerId = dto.CustomerId.HasValue && dto.CustomerId.Value > 0 ? dto.CustomerId : null,
                    InvoiceId = invoice.Id,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                };

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return payment;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        });
    }

    public async Task DeletePaymentAsync(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment != null)
        {
            payment.IsDeleted = true;
            payment.UpdatedAt = DateTime.UtcNow;
            payment.UpdatedBy = "System";
            
            // Update invoice if payment was linked
            if (payment.InvoiceId.HasValue)
            {
                var invoice = await _context.Invoices.FindAsync(payment.InvoiceId.Value);
                if (invoice != null)
                {
                    invoice.PaidAmount -= payment.Amount;
                    invoice.BalanceAmount = invoice.TotalAmount - invoice.PaidAmount;
                    
                    if (invoice.BalanceAmount > 0 && invoice.PaidAmount > 0)
                    {
                        invoice.Status = InvoiceStatus.PartiallyPaid;
                    }
                    else if (invoice.BalanceAmount == invoice.TotalAmount)
                    {
                        invoice.Status = InvoiceStatus.Sent;
                    }

                    invoice.UpdatedAt = DateTime.UtcNow;
                    invoice.UpdatedBy = "System";
                }
            }

            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> GeneratePaymentNumberAsync(int companyId)
    {
        var lastPayment = await _context.Payments
            .Where(p => p.CompanyId == companyId)
            .OrderByDescending(p => p.Id)
            .FirstOrDefaultAsync();

        var nextNumber = 1;
        if (lastPayment != null && !string.IsNullOrEmpty(lastPayment.PaymentNumber))
        {
            var parts = lastPayment.PaymentNumber.Split('-');
            if (parts.Length > 1 && int.TryParse(parts[^1], out var lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }

        return $"PAY-{nextNumber:D6}";
    }
}
