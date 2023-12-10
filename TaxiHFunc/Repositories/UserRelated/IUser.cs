using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHFunc.Repositories.UserRelated;
public interface IUser
{
    public Task<bool> LoginUser(LoginDTO userCreds);
}
