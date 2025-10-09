namespace AccountingPro.Application.DTOs;

public class CountryDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Code3 { get; set; } = string.Empty;
    public string PhoneCode { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string CurrencySymbol { get; set; } = string.Empty;
}
