using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Services.TokensService;

public interface ITokenHandlerService 
{
    public Task<string> CreateTokenAsync(LoginDTO userCreds);
}
