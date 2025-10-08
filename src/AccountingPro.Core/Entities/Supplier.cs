using AccountingPro.Core.Common;
using AccountingPro.Core.Enums;

namespace AccountingPro.Core.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public SupplierStatus Status { get; set; }
    public int CompanyId { get; set; }
    
    // Navigation properties
    public virtual Company Company { get; set; } = null!;
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}