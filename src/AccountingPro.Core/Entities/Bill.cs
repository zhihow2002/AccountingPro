using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class Bill : BaseEntity
{
    public string BillNumber { get; set; } = string.Empty;
    public int SupplierId { get; set; }
    public DateTime BillDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal BalanceAmount { get; set; }
    public BillStatus Status { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    
    // Navigation properties
    public virtual Supplier Supplier { get; set; } = null!;
    public virtual ICollection<BillItem> BillItems { get; set; } = new List<BillItem>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}