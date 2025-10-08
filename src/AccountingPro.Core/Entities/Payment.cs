using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class Payment : BaseEntity
{
    public string PaymentNumber { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus Status { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    
    // Foreign keys
    public int? CustomerId { get; set; }
    public int? SupplierId { get; set; }
    public int? InvoiceId { get; set; }
    public int? BillId { get; set; }
    public int? BankAccountId { get; set; }
    
    // Navigation properties
    public virtual Company Company { get; set; } = null!;
    public virtual Customer? Customer { get; set; }
    public virtual Supplier? Supplier { get; set; }
    public virtual Invoice? Invoice { get; set; }
    public virtual Bill? Bill { get; set; }
    public virtual Account? BankAccount { get; set; }
}