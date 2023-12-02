using Microsoft.EntityFrameworkCore;
using TaxiHereAPI.Models.Domain;

namespace TaxiHereAPI.Database;
public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    /* DBSets */
    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Zone> Zones { get; set; }
}
