using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHereAPI.Repositories.User;
public interface IUserRepository
{
    public Task<bool> CreateUserAsync(RegisterDTO newUser);
    public Task<bool> UsernameInUseAsync(string username);
    public Task<bool> EmailInUseAsync(string email);
    public Task<bool> PhoneInUseAsync(string phone);
}
