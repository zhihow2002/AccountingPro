using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class ProformaInvoice : BaseEntity
{
    public string ProformaNumber { get; set; } = string.Empty;
    public int CustomerId { get; set; }
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
    public DateTime? ConvertedDate { get; set; }

    // Navigation properties
    public virtual Company Company { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
    public virtual Invoice? ConvertedToInvoice { get; set; }
    public virtual ICollection<ProformaInvoiceItem> ProformaInvoiceItems { get; set; } =
        new List<ProformaInvoiceItem>();
}
