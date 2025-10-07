using AccountingPro.Application.DTOs;
using MediatR;

namespace AccountingPro.Application.Queries;

public class GetJournalEntriesQuery : IRequest<List<JournalEntryDto>>
{
    public int CompanyId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class GetJournalEntryByIdQuery : IRequest<JournalEntryDto?>
{
    public int Id { get; set; }
}

public class GetAccountsQuery : IRequest<List<AccountDto>>
{
    public int CompanyId { get; set; }
}

public class GetBalanceSheetQuery : IRequest<BalanceSheetDto>
{
    public int CompanyId { get; set; }
    public DateTime AsOfDate { get; set; }
}

public class GetIncomeStatementQuery : IRequest<IncomeStatementDto>
{
    public int CompanyId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
