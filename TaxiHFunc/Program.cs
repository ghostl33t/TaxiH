using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiHDbContext.DBContext;
using TaxiHDbContext;
using TaxiHFunc.Repositories.UserRelated;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using TaxiHFunc.Services.TokensService;


var configBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
var jwtSection = configBuilder.GetSection("Jwt");

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.Configure<JWTSettings>(jwtSection);
        #region Database
        services.AddDbContext<ApplicationDBContext>(options =>
        {
            var dbConnectionString = TaxiHDbContext.ServiceRegistry.ExtractConnectionString();
            ServiceRegistry.ConfigureDbContext(options, dbConnectionString);
        });
        #endregion
        #region Services
        services.AddAutoMapper(typeof(Program));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        #region JWT
        .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]))
        });
        #endregion
        services.AddTransient<ITokenHandlerService,TokenHandlerService>();
        services.AddScoped<IUserRepository, UserRepository>();

        #endregion
    })
    .Build();

host.Run();
