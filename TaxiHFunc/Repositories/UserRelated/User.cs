using Microsoft.EntityFrameworkCore;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHDbContext.DBContext;

namespace TaxiHFunc.Repositories.UserRelated;
public class User : IUser
{
    private readonly ApplicationDBContext _dbContext;
    public User(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> LoginUser(LoginDTO userCreds)
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
}
