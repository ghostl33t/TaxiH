using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiHereAPI.Commands.UserCommands;
using TaxiHereAPI.Models.DTO;

namespace TaxiHereAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] RegisterDTO newUser)
    {
        await _mediator.Send(new AddUserCommand(newUser));
        return StatusCode(201);
    }
}
