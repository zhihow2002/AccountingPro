using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class JournalEntry : BaseEntity
{
    public string EntryNumber { get; set; } = string.Empty;
    public DateTime EntryDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
    public JournalEntryStatus Status { get; set; } = JournalEntryStatus.Draft;
    public decimal TotalDebit { get; set; } = 0;
    public decimal TotalCredit { get; set; } = 0;
    public int CompanyId { get; set; }
    public int? ReversalOfEntryId { get; set; }
    public bool IsReversed { get; set; } = false;
    public DateTime? ApprovedAt { get; set; }
    public string? ApprovedBy { get; set; }

    // Navigation properties
    public virtual Company Company { get; set; } = null!;
    public virtual JournalEntry? ReversalOfEntry { get; set; }
    public virtual ICollection<JournalEntryLine> JournalEntryLines { get; set; } =
        new List<JournalEntryLine>();
}
