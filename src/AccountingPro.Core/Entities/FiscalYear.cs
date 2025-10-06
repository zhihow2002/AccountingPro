using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class FiscalYear : BaseEntity
{
    public int Year { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public FiscalYearStatus Status { get; set; } = FiscalYearStatus.Open;
    public int CompanyId { get; set; }
    public bool IsCurrent { get; set; } = false;

    // Navigation properties
    public virtual Company Company { get; set; } = null!;
    public virtual ICollection<AccountingPeriod> AccountingPeriods { get; set; } = new List<AccountingPeriod>();
}