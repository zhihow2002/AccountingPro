using AccountingPro.Core.Common;

namespace AccountingPro.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public decimal SalePrice { get; set; }
    public decimal CostPrice { get; set; }
    public int QuantityOnHand { get; set; }
    public int ReorderLevel { get; set; }
    public bool IsActive { get; set; } = true;
    public int? IncomeAccountId { get; set; }
    public int? ExpenseAccountId { get; set; }
    
    // Navigation properties
    public virtual Account? IncomeAccount { get; set; }
    public virtual Account? ExpenseAccount { get; set; }
    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    public virtual ICollection<BillItem> BillItems { get; set; } = new List<BillItem>();
}