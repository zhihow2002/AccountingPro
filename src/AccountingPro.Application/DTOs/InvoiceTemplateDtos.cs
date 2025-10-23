namespace AccountingPro.Application.DTOs
{
    /// <summary>
    /// Extended DTO for rendering invoice templates with complete company and customer information
    /// Extends the existing InvoiceDto with additional fields needed for printing and PDF export
    /// </summary>
    public class InvoicePrintDto : InvoiceDto
    {
        // Company Information
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public string CompanyPhone { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string? CompanyTaxId { get; set; }
        public string? CompanyLogoUrl { get; set; }
        
        // Extended Customer Information (beyond what's in InvoiceDto)
        public string? CustomerCompany { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerState { get; set; }
        public string? CustomerZipCode { get; set; }
        public string? CustomerCountry { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        
        // Payment terms (Notes already exists in InvoiceDto)
        public string? Terms { get; set; }
    }
}
