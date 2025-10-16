using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Core.Entities;
using AccountingPro.Core.Enums;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class ProformaInvoiceService : IProformaInvoiceService
{
    private readonly AccountingDbContext _context;
    private readonly ICompanyContextService _companyContext;
    private const string NoCompanyContextError = "No company context set";

    public ProformaInvoiceService(
        AccountingDbContext context,
        ICompanyContextService companyContext
    )
    {
        _context = context;
        _companyContext = companyContext;
    }

    public async Task<List<ProformaInvoiceListDto>> GetAllProformaInvoicesAsync(int companyId)
    {
        var proformas = await _context
            .ProformaInvoices.Include(p => p.Customer)
            .Where(p => p.CompanyId == companyId && !p.IsDeleted)
            .OrderByDescending(p => p.IssueDate)
            .Select(
                p =>
                    new ProformaInvoiceListDto
                    {
                        Id = p.Id,
                        ProformaNumber = p.ProformaNumber,
                        CustomerName = p.Customer.Name,
                        IssueDate = p.IssueDate,
                        ValidUntil = p.ValidUntil,
                        TotalAmount = p.TotalAmount,
                        Status = p.Status,
                        ConvertedToInvoiceId = p.ConvertedToInvoiceId,
                        ConvertedDate = p.ConvertedDate
                    }
            )
            .ToListAsync();

        return proformas;
    }

    public async Task<ProformaInvoiceDto?> GetProformaInvoiceByIdAsync(int id)
    {
        var proforma = await _context
            .ProformaInvoices.Include(p => p.Customer)
            .Include(p => p.ProformaInvoiceItems)
            .ThenInclude(i => i.Product)
            .Include(p => p.ConvertedToInvoice)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (proforma == null)
            return null;

        return new ProformaInvoiceDto
        {
            Id = proforma.Id,
            ProformaNumber = proforma.ProformaNumber,
            CustomerId = proforma.CustomerId,
            CustomerName = proforma.Customer.Name,
            IssueDate = proforma.IssueDate,
            ValidUntil = proforma.ValidUntil,
            SubTotal = proforma.SubTotal,
            TaxAmount = proforma.TaxAmount,
            DiscountAmount = proforma.DiscountAmount,
            TotalAmount = proforma.TotalAmount,
            Status = proforma.Status,
            Notes = proforma.Notes,
            Terms = proforma.Terms,
            CompanyId = proforma.CompanyId,
            ConvertedToInvoiceId = proforma.ConvertedToInvoiceId,
            ConvertedToInvoiceNumber = proforma.ConvertedToInvoice?.InvoiceNumber,
            ConvertedDate = proforma.ConvertedDate,
            Items = proforma
                .ProformaInvoiceItems.Select(
                    i =>
                        new ProformaInvoiceItemDto
                        {
                            Id = i.Id,
                            ProformaInvoiceId = i.ProformaInvoiceId,
                            ProductId = i.ProductId,
                            ProductName = i.Product?.Name ?? "",
                            Description = i.Description,
                            Quantity = i.Quantity,
                            UnitPrice = i.UnitPrice,
                            Discount = i.Discount,
                            TaxRate = i.TaxRate,
                            TaxAmount = i.TaxAmount,
                            LineTotal = i.LineTotal
                        }
                )
                .ToList()
        };
    }

    public async Task<ProformaInvoiceDto> CreateProformaInvoiceAsync(
        CreateProformaInvoiceDto createDto,
        int companyId
    )
    {
        // Generate proforma number
        var lastProforma = await _context
            .ProformaInvoices.Where(p => p.CompanyId == companyId)
            .OrderByDescending(p => p.Id)
            .FirstOrDefaultAsync();

        var proformaNumber = $"PF-{DateTime.Now:yyyyMM}-{(lastProforma?.Id ?? 0) + 1:D4}";

        var proforma = new ProformaInvoice
        {
            ProformaNumber = proformaNumber,
            CustomerId = createDto.CustomerId,
            CompanyId = companyId,
            IssueDate = createDto.IssueDate,
            ValidUntil = createDto.ValidUntil,
            Status = ProformaStatus.Draft,
            Notes = createDto.Notes,
            Terms = createDto.Terms,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        // Calculate totals
        decimal subTotal = 0;
        decimal taxAmount = 0;
        decimal discountAmount = 0;

        foreach (var itemDto in createDto.Items)
        {
            var lineSubTotal = itemDto.Quantity * itemDto.UnitPrice;
            var lineDiscount = lineSubTotal * (itemDto.Discount / 100);
            var lineAmountAfterDiscount = lineSubTotal - lineDiscount;
            var lineTax = lineAmountAfterDiscount * (itemDto.TaxRate / 100);
            var lineTotal = lineAmountAfterDiscount + lineTax;

            var item = new ProformaInvoiceItem
            {
                ProductId = itemDto.ProductId == 0 ? null : itemDto.ProductId,
                Description = itemDto.Description,
                Quantity = itemDto.Quantity,
                UnitPrice = itemDto.UnitPrice,
                Discount = itemDto.Discount,
                TaxRate = itemDto.TaxRate,
                TaxAmount = lineTax,
                LineTotal = lineTotal,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };

            proforma.ProformaInvoiceItems.Add(item);

            subTotal += lineSubTotal;
            discountAmount += lineDiscount;
            taxAmount += lineTax;
        }

        proforma.SubTotal = subTotal;
        proforma.DiscountAmount = discountAmount;
        proforma.TaxAmount = taxAmount;
        proforma.TotalAmount = subTotal - discountAmount + taxAmount;

        _context.ProformaInvoices.Add(proforma);
        await _context.SaveChangesAsync();

        return (await GetProformaInvoiceByIdAsync(proforma.Id))!;
    }

    public async Task<ProformaInvoiceDto?> UpdateProformaInvoiceAsync(
        int id,
        UpdateProformaInvoiceDto updateDto
    )
    {
        var proforma = await _context
            .ProformaInvoices.Include(p => p.ProformaInvoiceItems)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

        if (proforma == null)
            return null;

        // Don't allow editing if converted
        if (proforma.Status == ProformaStatus.Converted)
            throw new InvalidOperationException("Cannot edit a converted proforma invoice");

        proforma.CustomerId = updateDto.CustomerId;
        proforma.IssueDate = updateDto.IssueDate;
        proforma.ValidUntil = updateDto.ValidUntil;
        proforma.Status = updateDto.Status;
        proforma.Notes = updateDto.Notes;
        proforma.Terms = updateDto.Terms;
        proforma.UpdatedAt = DateTime.UtcNow;
        proforma.UpdatedBy = "System";

        // Remove old items
        _context.ProformaInvoiceItems.RemoveRange(proforma.ProformaInvoiceItems);

        // Add updated items
        decimal subTotal = 0;
        decimal taxAmount = 0;
        decimal discountAmount = 0;

        foreach (var itemDto in updateDto.Items)
        {
            var lineSubTotal = itemDto.Quantity * itemDto.UnitPrice;
            var lineDiscount = lineSubTotal * (itemDto.Discount / 100);
            var lineAmountAfterDiscount = lineSubTotal - lineDiscount;
            var lineTax = lineAmountAfterDiscount * (itemDto.TaxRate / 100);
            var lineTotal = lineAmountAfterDiscount + lineTax;

            var item = new ProformaInvoiceItem
            {
                ProductId = itemDto.ProductId == 0 ? null : itemDto.ProductId,
                Description = itemDto.Description,
                Quantity = itemDto.Quantity,
                UnitPrice = itemDto.UnitPrice,
                Discount = itemDto.Discount,
                TaxRate = itemDto.TaxRate,
                TaxAmount = lineTax,
                LineTotal = lineTotal,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };

            proforma.ProformaInvoiceItems.Add(item);

            subTotal += lineSubTotal;
            discountAmount += lineDiscount;
            taxAmount += lineTax;
        }

        proforma.SubTotal = subTotal;
        proforma.DiscountAmount = discountAmount;
        proforma.TaxAmount = taxAmount;
        proforma.TotalAmount = subTotal - discountAmount + taxAmount;

        await _context.SaveChangesAsync();

        return await GetProformaInvoiceByIdAsync(id);
    }

    public async Task<bool> DeleteProformaInvoiceAsync(int id)
    {
        var proforma = await _context.ProformaInvoices.FindAsync(id);
        if (proforma == null || proforma.IsDeleted)
            return false;

        // Don't allow deletion if converted
        if (proforma.Status == ProformaStatus.Converted)
            throw new InvalidOperationException("Cannot delete a converted proforma invoice");

        proforma.IsDeleted = true;
        proforma.UpdatedAt = DateTime.UtcNow;
        proforma.UpdatedBy = "System";

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ProformaInvoiceDto?> ConvertToInvoiceAsync(int proformaId)
    {
        var proforma = await _context
            .ProformaInvoices.Include(p => p.ProformaInvoiceItems)
            .Include(p => p.Customer)
            .FirstOrDefaultAsync(p => p.Id == proformaId && !p.IsDeleted);

        if (proforma == null)
            return null;

        if (proforma.Status == ProformaStatus.Converted)
            throw new InvalidOperationException("Proforma invoice already converted");

        // Generate invoice number
        var lastInvoice = await _context
            .Invoices.Where(i => i.CompanyId == proforma.CompanyId)
            .OrderByDescending(i => i.Id)
            .FirstOrDefaultAsync();

        var invoiceNumber = $"INV-{DateTime.Now:yyyyMM}-{(lastInvoice?.Id ?? 0) + 1:D4}";

        // Create invoice from proforma
        var invoice = new Invoice
        {
            InvoiceNumber = invoiceNumber,
            CustomerId = proforma.CustomerId,
            CompanyId = proforma.CompanyId,
            InvoiceDate = DateTime.Today,
            DueDate = DateTime.Today.AddDays(30),
            SubTotal = proforma.SubTotal,
            TaxAmount = proforma.TaxAmount,
            DiscountAmount = proforma.DiscountAmount,
            TotalAmount = proforma.TotalAmount,
            PaidAmount = 0,
            BalanceAmount = proforma.TotalAmount,
            Status = InvoiceStatus.Draft,
            Notes = proforma.Notes,
            Terms = proforma.Terms,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };

        // Copy items
        foreach (var proformaItem in proforma.ProformaInvoiceItems)
        {
            invoice.InvoiceItems.Add(
                new InvoiceItem
                {
                    ProductId = proformaItem.ProductId,
                    Description = proformaItem.Description,
                    Quantity = proformaItem.Quantity,
                    UnitPrice = proformaItem.UnitPrice,
                    Discount = proformaItem.Discount,
                    TaxRate = proformaItem.TaxRate,
                    TaxAmount = proformaItem.TaxAmount,
                    LineTotal = proformaItem.LineTotal,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "System"
                }
            );
        }

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        // Update proforma status
        proforma.Status = ProformaStatus.Converted;
        proforma.ConvertedToInvoiceId = invoice.Id;
        proforma.ConvertedDate = DateTime.UtcNow;
        proforma.UpdatedAt = DateTime.UtcNow;
        proforma.UpdatedBy = "System";

        await _context.SaveChangesAsync();

        return await GetProformaInvoiceByIdAsync(proformaId);
    }

    public async Task<List<ProformaInvoiceListDto>> GetProformaInvoicesByCustomerIdAsync(
        int customerId,
        int companyId
    )
    {
        var proformas = await _context
            .ProformaInvoices.Include(p => p.Customer)
            .Where(p => p.CustomerId == customerId && p.CompanyId == companyId && !p.IsDeleted)
            .OrderByDescending(p => p.IssueDate)
            .Select(
                p =>
                    new ProformaInvoiceListDto
                    {
                        Id = p.Id,
                        ProformaNumber = p.ProformaNumber,
                        CustomerName = p.Customer.Name,
                        IssueDate = p.IssueDate,
                        ValidUntil = p.ValidUntil,
                        TotalAmount = p.TotalAmount,
                        Status = p.Status,
                        ConvertedToInvoiceId = p.ConvertedToInvoiceId,
                        ConvertedDate = p.ConvertedDate
                    }
            )
            .ToListAsync();

        return proformas;
    }

    public async Task<bool> UpdateStatusAsync(int id, ProformaStatus status)
    {
        var proforma = await _context.ProformaInvoices.FindAsync(id);
        if (proforma == null || proforma.IsDeleted)
            return false;

        proforma.Status = status;
        proforma.UpdatedAt = DateTime.UtcNow;
        proforma.UpdatedBy = "System";

        await _context.SaveChangesAsync();
        return true;
    }
}
