using AccountingPro.Application.DTOs;

namespace AccountingPro.Application.Services;

public interface IReportService
{
    Task<TrialBalanceSummaryDto> GetTrialBalanceAsync(DateTime? asOfDate = null);
}
