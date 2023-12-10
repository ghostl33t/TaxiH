using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Repositories.UserRelated;
public interface IUserRepository
{
    public Task<bool> LoginUser(LoginDTO userCreds);
}
