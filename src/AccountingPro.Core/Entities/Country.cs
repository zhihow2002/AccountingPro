using AccountingPro.Core.Common;

namespace AccountingPro.Core.Entities;

public class Country : BaseEntity
{
    public string Code { get; set; } = string.Empty; // ISO 3166-1 alpha-2 code (e.g., "US", "MY")
    public string Name { get; set; } = string.Empty;
    public string Code3 { get; set; } = string.Empty; // ISO 3166-1 alpha-3 code (e.g., "USA", "MYS")
    public string NumericCode { get; set; } = string.Empty; // ISO 3166-1 numeric code
    public string PhoneCode { get; set; } = string.Empty; // International dialing code (e.g., "+1", "+60")
    public string Currency { get; set; } = string.Empty; // Currency code (e.g., "USD", "MYR")
    public string CurrencySymbol { get; set; } = string.Empty; // Currency symbol (e.g., "$", "RM")
    public bool IsActive { get; set; } = true;
}
