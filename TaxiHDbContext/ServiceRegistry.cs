using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text;
using TaxiHDbContext.DBContext;

namespace TaxiHDbContext;

public static class ServiceRegistry
{
    public static string GetEmbeddedResource(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                throw new InvalidOperationException($"Resource '{resourceName}' not found in assembly '{assembly.FullName}'.");
            }

            using (StreamReader reader = new StreamReader(stream))
            {
                var res = reader.ReadToEnd();
                Console.WriteLine(res);
                return res;
            }
        }
    }
    public static string ExtractConnectionString()
    {
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        var embeddedAppSettingsJson = GetEmbeddedResource($"{ assemblyName }.appsettings.json");
        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(embeddedAppSettingsJson)));
            })
            .Build();

        var configuration = host.Services.GetRequiredService<IConfiguration>();
        string dbConnectionString = configuration.GetConnectionString("DBConnection") ?? "";

        return dbConnectionString;
    }
    public static void RegisterServices(IServiceCollection services, string dbConnectionString)
    {
        #region Database
        services.AddDbContext<ApplicationDBContext>(options =>
        {
            ConfigureDbContext(options, dbConnectionString);
        });
        #endregion
    }
    public static void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string dbConnectionString)
    {
        try
        {
            if (dbConnectionString != null)
            {
                optionsBuilder.UseSqlServer(dbConnectionString);
                Console.WriteLine("INFO: Connection with the database established successfully!");
            }
            else
            {
                Console.WriteLine("ERROR: Unable to connect to the SQL server.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: Configuration of DBContext failed!\n{ ex}");
            throw;
        }
        
    }
}
