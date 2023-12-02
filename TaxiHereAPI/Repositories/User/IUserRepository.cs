using TaxiHereAPI.Models.DTO;

namespace TaxiHereAPI.Repositories.User;
public interface IUserRepository
{
    public Task<bool> CreateUserAsync(RegisterDTO newUser);
}
