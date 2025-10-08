using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class Tax : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public TaxType Type { get; set; }
    public bool IsActive { get; set; } = true;
    public int? TaxAccountId { get; set; }
    public int CompanyId { get; set; }
    
    // Navigation properties
    public virtual Company Company { get; set; } = null!;
    public virtual Account? TaxAccount { get; set; }
}