using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHFunc.Commands;
using TaxiHFunc.Queries.UserQueries;
using TaxiHFunc.Services.TokensService;

namespace TaxiHFunc.Functions;
public class RefreshUserToken
{
    private readonly IMediator _mediator;
    private readonly ITokenHandlerService _tokenHandlerService;
    public RefreshUserToken(IMediator mediator, ITokenHandlerService tokenHandlerService)
    {
        _mediator = mediator;
        _tokenHandlerService = tokenHandlerService;
    }

    [Function("RefreshUserToken")]
    public async Task<TokenDTO> Run([HttpTrigger(AuthorizationLevel.Function, "post")][FromBody] TokenDTO req)
    {
        var userLoginCreds = await _mediator.Send(new GetUserLoginCredentialsQuery(req));
        if (userLoginCreds == null) 
            return new TokenDTO { TokenValue = "", UserId = 0 };

        var token = await _tokenHandlerService.CreateTokenAsync(userLoginCreds);
        await WriteTokenForUser(userLoginCreds.Username, token);

        var res = req;
        res.TokenValue = token;

        return res;
    }
    public async Task<bool> WriteTokenForUser(string userName, string token)
    {
        try
        {
            var user = await _mediator.Send(new GetUserDataQuery(userName));
            var userToken = new TokenDTO()
            {
                UserId = user.Id,
                TokenValue = token
            };
            await _mediator.Send(new AddUserTokenCommand(userToken));
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }

    }
}
