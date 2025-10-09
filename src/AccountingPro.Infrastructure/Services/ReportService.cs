using AccountingPro.Application.DTOs;
using AccountingPro.Application.Services;
using AccountingPro.Core.Enums;
using AccountingPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingPro.Infrastructure.Services;

public class ReportService : IReportService
{
    private readonly AccountingDbContext _context;
    private readonly ICompanyContextService _companyContextService;

    private sealed record TrialBalanceAccount(int Id, string Code, string Name, AccountType Type);

    public ReportService(AccountingDbContext context, ICompanyContextService companyContextService)
    {
        _context = context;
        _companyContextService = companyContextService;
    }

    public async Task<TrialBalanceSummaryDto> GetTrialBalanceAsync(DateTime? asOfDate = null)
    {
        await _companyContextService.InitializeAsync();

        if (_companyContextService.CurrentCompanyId == null)
        {
            return new TrialBalanceSummaryDto();
        }

        var companyId = _companyContextService.CurrentCompanyId.Value;

        var rawBalances = await LoadRawBalancesAsync(companyId, asOfDate);
        var accounts = await LoadAccountsAsync(companyId);

        var trialBalanceEntries = BuildTrialBalanceEntries(accounts, rawBalances);

        var totalDebit = trialBalanceEntries.Sum(entry => entry.Debit);
        var totalCredit = trialBalanceEntries.Sum(entry => entry.Credit);

        return new TrialBalanceSummaryDto
        {
            Entries = trialBalanceEntries.OrderBy(entry => entry.AccountCode).ToList(),
            TotalDebit = Math.Round(totalDebit, 2, MidpointRounding.AwayFromZero),
            TotalCredit = Math.Round(totalCredit, 2, MidpointRounding.AwayFromZero)
        };
    }

    private async Task<Dictionary<int, (decimal debit, decimal credit)>> LoadRawBalancesAsync(int companyId, DateTime? asOfDate)
    {
        var query = _context.JournalEntryLines
            .AsNoTracking()
            .Where(line => line.JournalEntry.CompanyId == companyId);

        if (asOfDate.HasValue)
        {
            query = query.Where(line => line.JournalEntry.EntryDate <= asOfDate.Value);
        }

        return await query
            .GroupBy(line => line.AccountId)
            .Select(group => new
            {
                AccountId = group.Key,
                Debit = group.Sum(line => line.DebitAmount),
                Credit = group.Sum(line => line.CreditAmount)
            })
            .ToDictionaryAsync(x => x.AccountId, x => (x.Debit, x.Credit));
    }

    private async Task<IReadOnlyList<TrialBalanceAccount>> LoadAccountsAsync(int companyId)
    {
        return await _context.Accounts
            .AsNoTracking()
            .Where(account => account.CompanyId == companyId)
            .Select(account => new TrialBalanceAccount(account.Id, account.Code, account.Name, account.AccountType))
            .ToListAsync();
    }

    private static List<TrialBalanceEntryDto> BuildTrialBalanceEntries(
        IReadOnlyList<TrialBalanceAccount> accounts,
        IReadOnlyDictionary<int, (decimal debit, decimal credit)> balances)
    {
        var results = new List<TrialBalanceEntryDto>(accounts.Count);

        foreach (var account in accounts)
        {
            var (debit, credit) = balances.TryGetValue(account.Id, out var amounts)
                ? NormalizeBalance(account.Type, amounts.debit, amounts.credit)
                : (0m, 0m);

            if (debit == 0 && credit == 0)
            {
                continue;
            }

            results.Add(
                new TrialBalanceEntryDto
                {
                    AccountId = account.Id,
                    AccountCode = account.Code,
                    AccountName = account.Name,
                    Debit = Math.Round(debit, 2, MidpointRounding.AwayFromZero),
                    Credit = Math.Round(credit, 2, MidpointRounding.AwayFromZero)
                }
            );
        }

        return results;
    }

    private static (decimal debit, decimal credit) NormalizeBalance(AccountType accountType, decimal debit, decimal credit)
    {
        return accountType switch
        {
            AccountType.Asset or AccountType.Expense => NormalizeDebitBalance(debit, credit),
            AccountType.Liability or AccountType.Equity or AccountType.Revenue => NormalizeCreditBalance(debit, credit),
            _ => (Math.Max(debit, 0), Math.Max(credit, 0))
        };
    }

    private static (decimal debit, decimal credit) NormalizeDebitBalance(decimal debit, decimal credit)
    {
        var net = debit - credit;
        return net >= 0 ? (net, 0m) : (0m, Math.Abs(net));
    }

    private static (decimal debit, decimal credit) NormalizeCreditBalance(decimal debit, decimal credit)
    {
        var net = credit - debit;
        return net >= 0 ? (0m, net) : (Math.Abs(net), 0m);
    }
}
