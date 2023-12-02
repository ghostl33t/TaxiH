using Microsoft.EntityFrameworkCore;

namespace TaxiHereAPI.Database;
public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    /* DBSets */
}
