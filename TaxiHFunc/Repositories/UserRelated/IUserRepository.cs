using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Repositories.UserRelated;
public interface IUserRepository
{
    public Task<bool> LoginUserAsync(LoginDTO userCreds);
    public Task<bool> SaveTokenForUserAsync(TokenDTO userToken);
    public Task<UserDataDTO> GetUserByUsernameAsync(string userName);
    public Task<UserDataDTO> GetUserByTokenAsync(string tokenVal);
    public Task<LoginDTO> GetUserCredsAsync(TokenDTO userToken);
}
