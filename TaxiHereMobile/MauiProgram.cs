using Microsoft.Extensions.Logging;
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

            builder.Build();
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
