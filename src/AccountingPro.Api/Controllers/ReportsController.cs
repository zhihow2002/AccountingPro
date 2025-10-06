using Microsoft.AspNetCore.Mvc;
using MediatR;
using AccountingPro.Application.Queries;
using AccountingPro.Application.DTOs;

namespace AccountingPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("balance-sheet")]
    public async Task<ActionResult<BalanceSheetDto>> GetBalanceSheet(
        [FromQuery] int companyId,
        [FromQuery] DateTime asOfDate)
    {
        var query = new GetBalanceSheetQuery 
        { 
            CompanyId = companyId, 
            AsOfDate = asOfDate 
        };
        
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("income-statement")]
    public async Task<ActionResult<IncomeStatementDto>> GetIncomeStatement(
        [FromQuery] int companyId,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        var query = new GetIncomeStatementQuery 
        { 
            CompanyId = companyId, 
            StartDate = startDate, 
            EndDate = endDate 
        };
        
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}