using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    public async Task<bool> EmailInUseAsync(string email)
    {
        try
        {
            if (await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Email == email) != null)
                return true;
        }
        catch (Exception ex)
        {
            /* Log Errors */
            Console.WriteLine(ex.ToString());
            throw;
        }
        
        return false;
    }

    public async Task<bool> PhoneInUseAsync(string phone)
    {
        try
        {
            if (await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Phone == phone) != null)
                return true;
        }
        catch (Exception ex)
        {
            /* Log Errors */
            Console.WriteLine(ex.ToString());
            throw;
        }
        
        return false;
    }

    public async Task<bool> UsernameInUseAsync(string username)
    {
        try
        {
            if (await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.UserName == username) != null)
                return true;
        }
        catch (Exception ex)
        {
            /* Log Errors */
            Console.WriteLine(ex.ToString());
            throw;
        }

        return false;
    }
}
