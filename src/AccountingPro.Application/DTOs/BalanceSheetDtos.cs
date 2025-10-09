using AccountingPro.Core.Enums;

namespace AccountingPro.Application.DTOs;

public class BalanceSheetEntryDto
{
    public int AccountId { get; set; }
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public AccountType AccountType { get; set; }
    public decimal Amount { get; set; }
}

public class OpeningBalanceSheetDto
{
    public DateTime AsOfDate { get; set; } = DateTime.Today;
    public List<BalanceSheetEntryDto> FixedAssets { get; set; } = new();
    public List<BalanceSheetEntryDto> CurrentAssets { get; set; } = new();
    public List<BalanceSheetEntryDto> CurrentLiabilities { get; set; } = new();
    public List<BalanceSheetEntryDto> CapitalAccount { get; set; } = new();
    public decimal Drawings { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class BalanceSheetAccountTemplateDto
{
    public string Category { get; set; } = string.Empty;
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public AccountType AccountType { get; set; }
    public string Description { get; set; } = string.Empty;
}
