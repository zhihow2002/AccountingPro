using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class InvoiceService : IInvoiceService
{
    private readonly AccountingDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICompanyContextService _companyContext;
    private const string NoCompanyContextError = "No company context set";

    public InvoiceService(AccountingDbContext context, IMapper mapper, ICompanyContextService companyContext)
    {
        _context = context;
        _mapper = mapper;
        _companyContext = companyContext;
    }

    public async Task<List<InvoiceDto>> GetAllInvoicesAsync()
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var invoices = await _context
            .Invoices.Include(i => i.Customer)
            .Include(i => i.InvoiceItems)
            .Where(i => i.CompanyId == _companyContext.CurrentCompanyId)
            .OrderByDescending(i => i.InvoiceDate)
            .ToListAsync();

        return _mapper.Map<List<InvoiceDto>>(invoices);
    }

    public async Task<InvoiceDto?> GetInvoiceByIdAsync(int id)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var invoice = await _context
            .Invoices.Include(i => i.Customer)
            .Include(i => i.InvoiceItems)
            .ThenInclude(ii => ii.Product)
            .FirstOrDefaultAsync(i => i.Id == id && i.CompanyId == _companyContext.CurrentCompanyId);

        return invoice == null ? null : _mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<InvoiceDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var companyId = _companyContext.CurrentCompanyId.Value;

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

        var invoice = new Invoice
        {
            InvoiceNumber = invoiceNumber,
            CustomerId = createInvoiceDto.CustomerId,
            CompanyId = companyId,
            InvoiceDate = createInvoiceDto.InvoiceDate,
            DueDate = createInvoiceDto.InvoiceDate.AddDays(30), // Default due date 30 days from invoice date
            DiscountAmount = 0, // No discount by default
            Notes = createInvoiceDto.Notes,
            Status = Core.Enums.InvoiceStatus.Draft,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System" // Should be current user in real implementation
        };

        // Add invoice items
        foreach (var itemDto in createInvoiceDto.Items)
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
        invoice.BalanceAmount = invoice.TotalAmount - invoice.PaidAmount;

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return _mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<InvoiceDto?> UpdateInvoiceAsync(int id, InvoiceDto updateInvoiceDto)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var invoice = await _context
            .Invoices.Include(i => i.InvoiceItems)
            .FirstOrDefaultAsync(i => i.Id == id && i.CompanyId == _companyContext.CurrentCompanyId);

        if (invoice == null)
            return null;

        // Update invoice properties
        invoice.InvoiceDate = updateInvoiceDto.InvoiceDate;
        invoice.DueDate = updateInvoiceDto.DueDate;
        invoice.DiscountAmount = updateInvoiceDto.DiscountAmount;
        invoice.Notes = updateInvoiceDto.Notes;
        invoice.Status = updateInvoiceDto.Status;
        invoice.UpdatedAt = DateTime.UtcNow;
        invoice.UpdatedBy = "System"; // Should be current user in real implementation

        await _context.SaveChangesAsync();

        return _mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<bool> DeleteInvoiceAsync(int id)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == id && i.CompanyId == _companyContext.CurrentCompanyId);

        if (invoice == null)
            return false;

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<InvoiceDto>> GetInvoicesByCustomerIdAsync(int customerId)
    {
        if (_companyContext.CurrentCompanyId == null)
            throw new InvalidOperationException(NoCompanyContextError);

        var invoices = await _context
            .Invoices.Include(i => i.Customer)
            .Include(i => i.InvoiceItems)
            .Where(i => i.CustomerId == customerId && i.CompanyId == _companyContext.CurrentCompanyId)
            .OrderByDescending(i => i.InvoiceDate)
            .ToListAsync();

        return _mapper.Map<List<InvoiceDto>>(invoices);
    }

    public async Task<List<InvoiceDto>> GetInvoicesByCompanyIdAsync(int companyId)
    {
        var invoices = await _context
            .Invoices.Include(i => i.Customer)
            .Include(i => i.InvoiceItems)
            .Where(i => i.CompanyId == companyId)
            .OrderByDescending(i => i.InvoiceDate)
            .ToListAsync();

        return _mapper.Map<List<InvoiceDto>>(invoices);
    }
}
