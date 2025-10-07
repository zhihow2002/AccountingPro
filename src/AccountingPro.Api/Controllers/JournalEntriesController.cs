using AccountingPro.Application.Commands;
using AccountingPro.Application.DTOs;
using AccountingPro.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JournalEntriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public JournalEntriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<JournalEntryDto>>> GetJournalEntries(
        [FromQuery] int companyId,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null
    )
    {
        var query = new GetJournalEntriesQuery
        {
            CompanyId = companyId,
            StartDate = startDate,
            EndDate = endDate
        };

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<JournalEntryDto>> GetJournalEntry(int id)
    {
        var query = new GetJournalEntryByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<JournalEntryDto>> CreateJournalEntry(
        [FromBody] CreateJournalEntryDto dto
    )
    {
        var command = new CreateJournalEntryCommand { JournalEntry = dto };
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetJournalEntry), new { id = result.Id }, result);
    }

    [HttpPost("{id}/approve")]
    public async Task<ActionResult> ApproveJournalEntry(int id, [FromBody] string approvedBy)
    {
        var command = new ApproveJournalEntryCommand { Id = id, ApprovedBy = approvedBy };
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return Ok();
    }
}
