using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using TaxiHereMobile.Logic.LoginRegister;

namespace TaxiHereMobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
#if DEBUG
		builder.Logging.AddDebug();
#endif
        #region Service Registration
        try
        {
            ConfigureServices(builder.Services);
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("TaxiHereMobile.appsettings.json");

            if (stream != null)
            {
                var config = new ConfigurationBuilder()
               .AddJsonStream(stream)
               .Build();
                builder.Configuration.AddConfiguration(config);
            }
            builder.Services.AddTransient<MainPage>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
        #endregion

        return builder.Build();
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ILoginRegister, LoginRegister>();
    }
}
