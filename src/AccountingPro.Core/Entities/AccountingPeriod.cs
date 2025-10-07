using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class AccountingPeriod : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public AccountingPeriodStatus Status { get; set; } = AccountingPeriodStatus.Open;
    public int FiscalYearId { get; set; }
    public bool IsCurrent { get; set; } = false;

    // Navigation properties
    public virtual FiscalYear FiscalYear { get; set; } = null!;
}
