using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class Account : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AccountType AccountType { get; set; }
    public int? ParentAccountId { get; set; }
    public int CompanyId { get; set; }
    public bool IsActive { get; set; } = true;
    public decimal Balance { get; set; } = 0;

    // Navigation properties
    public virtual Company Company { get; set; } = null!;
    public virtual Account? ParentAccount { get; set; }
    public virtual ICollection<Account> ChildAccounts { get; set; } = new List<Account>();
    public virtual ICollection<JournalEntryLine> JournalEntryLines { get; set; } =
        new List<JournalEntryLine>();
}
