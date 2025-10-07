using AccountingPro.Application.DTOs;
using AccountingPro.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<AccountDto>>> GetAccounts([FromQuery] int companyId)
    {
        var query = new GetAccountsQuery { CompanyId = companyId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
