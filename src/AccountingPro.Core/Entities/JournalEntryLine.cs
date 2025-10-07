using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class JournalEntryLine : BaseEntity
{
    public int JournalEntryId { get; set; }
    public int AccountId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal DebitAmount { get; set; } = 0;
    public decimal CreditAmount { get; set; } = 0;
    public TransactionType TransactionType { get; set; }

    // Navigation properties
    public virtual JournalEntry JournalEntry { get; set; } = null!;
    public virtual Account Account { get; set; } = null!;
}
