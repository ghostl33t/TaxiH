using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHFunc.Queries.UserQueries;
using TaxiHFunc.Services.TokensService;

namespace TaxiHFunc.Functions;

public class LoginFunction : ILoginFunction
{
    private readonly IMediator _mediator;
    private readonly ITokenHandlerService _tokenHandlerService;
    public LoginFunction(IMediator mediator, ITokenHandlerService tokenHandlerService)
    {
        _mediator = mediator;
        _tokenHandlerService = tokenHandlerService;
    }

    [Function("LoginFunction")]
    public async Task<ResponseDTO> Run([HttpTrigger(AuthorizationLevel.Function, "post")][FromBody] LoginDTO req)
    {
        var res = await _mediator.Send(new GetUserCredentialsQuery(req));
        if (res.StatusCode == 200)
        {
            var token = await _tokenHandlerService.CreateTokenAsync(req);
            Console.WriteLine(token);
            res.Message = token;
        }
        
        return res;
    }
}
