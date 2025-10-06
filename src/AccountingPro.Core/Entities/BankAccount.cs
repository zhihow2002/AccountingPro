using AccountingPro.Core.Common;

namespace AccountingPro.Core.Entities;

public class BankAccount : BaseEntity
{
    public string AccountName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string BankCode { get; set; } = string.Empty;
    public string IBAN { get; set; } = string.Empty;
    public string SWIFT { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public bool IsActive { get; set; } = true;
    public int? AccountId { get; set; }
    
    // Navigation properties
    public virtual Account? Account { get; set; }
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}