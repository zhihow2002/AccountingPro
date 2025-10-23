using AccountingPro.Core.Common;

namespace AccountingPro.Core.Entities;

public class Company : BaseEntity
{
    [Required(ErrorMessage = "Company name is required")]
    [StringLength(100, ErrorMessage = "Company name cannot exceed 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Company code is required")]
    [StringLength(20, ErrorMessage = "Company code cannot exceed 20 characters")]
    [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Company code can only contain uppercase letters and numbers")]
    public string Code { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
    public string Address { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Phone cannot exceed 20 characters")]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string Email { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Tax ID cannot exceed 20 characters")]
    public string TaxId { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    public bool EnableInvoiceTax { get; set; } = true;
    
    // Invoice Template Settings
    [StringLength(50, ErrorMessage = "Invoice template name cannot exceed 50 characters")]
    public string InvoiceTemplateName { get; set; } = "ModernTemplate"; // Default template
    
    [StringLength(500, ErrorMessage = "Logo URL cannot exceed 500 characters")]
    public string? LogoUrl { get; set; }

    // Navigation properties
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<FiscalYear> FiscalYears { get; set; } = new List<FiscalYear>();
    public virtual ICollection<JournalEntry> JournalEntries { get; set; } =
        new List<JournalEntry>();
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<Tax> Taxes { get; set; } = new List<Tax>();
}
