using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Functions;
public interface ILoginFunction
{
    public Task<ResponseDTO> Run([HttpTrigger(AuthorizationLevel.Function, "post")][FromBody] LoginDTO req);
    protected Task<bool> WriteTokenForUser(string userName, string token);
}
