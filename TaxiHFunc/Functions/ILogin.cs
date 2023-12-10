using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Functions;
public interface ILogin
{
    public Task<string> Run([HttpTrigger(AuthorizationLevel.Function, "post")] LoginDTO req);
}
