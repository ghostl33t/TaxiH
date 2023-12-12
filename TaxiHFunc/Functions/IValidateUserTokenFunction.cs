using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Functions;

public interface IValidateUserTokenFunction
{
    public Task<TokenDTO> Run([HttpTrigger(AuthorizationLevel.Function, "post")][FromBody] TokenDTO req);
}
