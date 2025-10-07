using AccountingPro.Application.DTOs;
using MediatR;

namespace AccountingPro.Application.Commands;

public class CreateJournalEntryCommand : IRequest<JournalEntryDto>
{
    public CreateJournalEntryDto JournalEntry { get; set; } = null!;
}

public class ApproveJournalEntryCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string ApprovedBy { get; set; } = string.Empty;
}
