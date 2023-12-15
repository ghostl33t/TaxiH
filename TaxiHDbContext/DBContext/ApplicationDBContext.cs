using Microsoft.EntityFrameworkCore;
using TaxiHDbContext.DBContext.Models.Domain;

namespace TaxiHDbContext.DBContext;
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
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyAvailability> CompanyAvailabilities { get; set; }
    public DbSet<CompanyEmployee> CompanyEmployees { get; set; }
    public DbSet<CompanyCar> CompanyCars { get; set; }
    public DbSet<CompanyNumbers> CompanyNumbers { get; set; }
    public DbSet<UserCityInterest> UserCityInterests { get; set;}
    public DbSet<EmployeeRideHistory> EmployeeRideHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyEmployee>()
            .HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.NoAction)

        modelBuilder.Entity<CompanyEmployee>()
            .HasOne(e => e.CompanyCar)
            .WithMany()
            .HasForeignKey(e => e.CompanyCarId)
            .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.NoAction)

        modelBuilder.Entity<CompanyNumbers>()
            .HasOne(cn => cn.CompanyAvailability)
            .WithMany()
            .HasForeignKey(cn => cn.CompanyAvailabilityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CompanyNumbers>()
            .HasOne(cn => cn.CompanyEmployee)
            .WithMany()
            .HasForeignKey(cn => cn.CompanyEmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }

}
