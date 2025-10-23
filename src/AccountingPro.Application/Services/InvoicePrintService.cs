using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

/// <summary>
/// Service for mapping invoice data to print-ready DTOs
/// </summary>
public interface IInvoicePrintService
{
    /// <summary>
    /// Maps an invoice with company and customer details to a print DTO
    /// </summary>
    InvoicePrintDto MapToPrintDto(InvoiceDto invoice, CompanyDto company, CustomerDto customer);
}

public class InvoicePrintService : IInvoicePrintService
{
    public InvoicePrintDto MapToPrintDto(
        InvoiceDto invoice,
        CompanyDto company,
        CustomerDto customer
    )
    {
        return new InvoicePrintDto
        {
            // Copy all invoice properties
            Id = invoice.Id,
            InvoiceNumber = invoice.InvoiceNumber,
            CustomerId = invoice.CustomerId,
            CustomerName = invoice.CustomerName,
            InvoiceDate = invoice.InvoiceDate,
            DueDate = invoice.DueDate,
            SubTotal = invoice.SubTotal,
            TaxAmount = invoice.TaxAmount,
            DiscountAmount = invoice.DiscountAmount,
            TotalAmount = invoice.TotalAmount,
            PaidAmount = invoice.PaidAmount,
            OutstandingAmount = invoice.OutstandingAmount,
            BalanceAmount = invoice.BalanceAmount,
            Description = invoice.Description,
            Status = invoice.Status,
            Notes = invoice.Notes,
            CreatedAt = invoice.CreatedAt,
            UpdatedAt = invoice.UpdatedAt,
            LineItems = invoice.LineItems,
            Items = invoice.Items,
            // Company information
            CompanyName = company.Name,
            CompanyAddress = company.Address,
            CompanyPhone = company.Phone,
            CompanyEmail = company.Email,
            CompanyTaxId = company.TaxId,
            CompanyLogoUrl = null, // Logo URL will be available after database migration
            // Customer information
            CustomerCompany = customer.CompanyName,
            CustomerAddress = customer.Address,
            CustomerCity = customer.City,
            CustomerState = customer.State,
            CustomerZipCode = customer.ZipCode,
            CustomerCountry = customer.Country,
            CustomerEmail = customer.Email,
            CustomerPhone = customer.Phone,
            // Payment terms - can be made configurable via Company settings in future
            Terms = "Net 30 Days"
        };
    }
}
