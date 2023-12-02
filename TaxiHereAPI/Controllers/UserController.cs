using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiHereAPI.Commands.UserCommands;
using TaxiHereAPI.Models.DTO;
using TaxiHereAPI.Services.ResponseService;

namespace TaxiHereAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    private readonly IResponseService _responseService;
    public UserController(IMediator mediator, IResponseService responseService)
    {
        _mediator = mediator;
        _responseService = responseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] RegisterDTO newUser)
    {
        try
        {
            /* 
                Validations Here 
            */
            await _mediator.Send(new AddUserCommand(newUser));
            return await _responseService.Response(201, "User created successfully!");
        }
        catch (Exception)
        {
            /* Logger Here */
            return await _responseService.Response(400, "Bad Request");
        }
    }
}
