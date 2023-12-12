using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHDbContext.DBContext;

namespace TaxiHFunc.Repositories.UserRelated;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IMapper _mapper;
    public UserRepository(ApplicationDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<bool> LoginUserAsync(LoginDTO userCreds)
    {
        try
        {
            var user = await _dbContext.Users.
                                    Where(x => x.UserName == userCreds.Username &&
                                    x.Password == userCreds.Password).Select(x => x.Id).FirstOrDefaultAsync();
            if (user != 0)
                return true;
        }
        catch (Exception ex)
        {
            /* add insights */
            Console.WriteLine(ex.ToString());
            throw;
        }
        return false;
    }

    public async Task<bool> SaveTokenForUserAsync(TokenDTO userToken)
    {
        try
        {
            var user = await _dbContext.Users.FirstAsync(x => x.Id == userToken.UserId);
            user.Token = userToken.TokenValue;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    public async Task<UserDataDTO> GetUserByUsernameAsync(string userName)
    {
        try
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == userName);
            var userDto = _mapper.Map<UserDataDTO>(user);
            return userDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    public async Task<UserDataDTO> GetUserByTokenAsync(string tokenVal)
    {
        try
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Token == tokenVal);
            var userDto = _mapper.Map<UserDataDTO>(user);
            return userDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    public async Task<LoginDTO> GetUserCredsAsync(TokenDTO userToken)
    {
        try
        {
            var user = await _dbContext.Users.AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.Id == userToken.UserId
                                            && x.Token == userToken.TokenValue);
            var userCreds = _mapper.Map<LoginDTO>(user);
            return userCreds;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}
