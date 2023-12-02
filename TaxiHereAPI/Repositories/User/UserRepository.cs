using AutoMapper;
using TaxiHereAPI.Database;
using TaxiHereAPI.Models.DTO;

namespace TaxiHereAPI.Repositories.User;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IMapper _mapper;
    public UserRepository(ApplicationDBContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<bool> CreateUserAsync(RegisterDTO newUser)
    {
        try
        {
            var user = _mapper.Map<Models.Domain.User>(newUser);
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
