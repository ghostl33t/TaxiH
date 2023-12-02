using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TaxiHereAPI.Database;
using TaxiHereAPI.Repositories.User;

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

#region Database
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    var mainConnectionString = builder.Configuration.GetConnectionString("DBConnection");
    if (mainConnectionString != null)
    {
        options.UseSqlServer(mainConnectionString);
        Console.WriteLine("INFO: Connection with the database established successfuly!");
    }
    else
    {
        Console.WriteLine("ERROR: Unable to connect to the SQL server.");
    }
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