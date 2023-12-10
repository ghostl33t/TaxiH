using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiHDbContext.DBContext;
using TaxiHDbContext;
using TaxiHFunc.Repositories.UserRelated;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        #region Database
        services.AddDbContext<ApplicationDBContext>(options =>
        {
            var dbConnectionString = TaxiHDbContext.ServiceRegistry.ExtractConnectionString();
            ServiceRegistry.ConfigureDbContext(options, dbConnectionString);
        });
        #endregion
        #region Services
        services.AddTransient<IUser, User>();
        #endregion
    })
    .Build();

host.Run();
