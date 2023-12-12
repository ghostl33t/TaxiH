using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHFunc.Queries.UserQueries;

namespace TaxiHFunc.Functions;

public class ValidateUserTokenFunction
{
    private readonly IMediator _mediator;
    public ValidateUserTokenFunction(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Function("ValidateUserTokenFunction")]
    public async Task<long> Run([HttpTrigger(AuthorizationLevel.Function, "post")][FromBody] TokenDTO req)
    {
        var res = await _mediator.Send(new GetUserTokenDataQuery(req.TokenValue));
        return res.Id;
    }
}
