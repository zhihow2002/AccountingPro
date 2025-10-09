using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public interface IBalanceSheetService
{
    Task<List<BalanceSheetAccountTemplateDto>> GetBalanceSheetTemplatesAsync();
    Task CreateOpeningBalancesAsync(OpeningBalanceSheetDto dto, int companyId);
    Task<OpeningBalanceSheetDto?> GetOpeningBalancesAsync(int companyId);
}
