using Microsoft.EntityFrameworkCore;
using TaxiHDbContext;
using TaxiHDbContext.DBContext;
using TaxiHereAPI.Repositories.User;
using TaxiHereAPI.Services.ResponseService;

var builder = WebApplication.CreateBuilder(args);

#region EnvironmentSetup
// Load environment-specific configuration (appsettings.{Environment}.json)
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
#endregion

#region Dependencies-Services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

#region Database
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    var dbConnectionString = TaxiHDbContext.ServiceRegistry.ExtractConnectionString();
    ServiceRegistry.ConfigureDbContext(options, dbConnectionString);
});
#endregion


var app = builder.Build();

#region RunSwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#endregion

#region AppSettings
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion