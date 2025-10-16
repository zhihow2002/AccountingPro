using AccountingPro.Core.Enums;

namespace AccountingPro.Application.DTOs;

public class ProformaInvoiceDto
{
    public int Id { get; set; }
    public string ProformaNumber { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ValidUntil { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public ProformaStatus Status { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string Terms { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int? ConvertedToInvoiceId { get; set; }
    public string? ConvertedToInvoiceNumber { get; set; }
    public DateTime? ConvertedDate { get; set; }
    public List<ProformaInvoiceItemDto> Items { get; set; } = new();
}

public class ProformaInvoiceItemDto
{
    public int Id { get; set; }
    public int ProformaInvoiceId { get; set; }
    public int? ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal LineTotal { get; set; }
}

public class CreateProformaInvoiceDto
{
    public int CustomerId { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.Today;
    public DateTime ValidUntil { get; set; } = DateTime.Today.AddDays(30);
    public string Notes { get; set; } = string.Empty;
    public string Terms { get; set; } = string.Empty;
    public List<CreateProformaInvoiceItemDto> Items { get; set; } = new();
}

public class CreateProformaInvoiceItemDto
{
    public int? ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxRate { get; set; }
}

public class UpdateProformaInvoiceDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ValidUntil { get; set; }
    public ProformaStatus Status { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string Terms { get; set; } = string.Empty;
    public List<UpdateProformaInvoiceItemDto> Items { get; set; } = new();
}

public class UpdateProformaInvoiceItemDto
{
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxRate { get; set; }
}

public class ProformaInvoiceListDto
{
    public int Id { get; set; }
    public string ProformaNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime ValidUntil { get; set; }
    public decimal TotalAmount { get; set; }
    public ProformaStatus Status { get; set; }
    public int? ConvertedToInvoiceId { get; set; }
    public DateTime? ConvertedDate { get; set; }
}
