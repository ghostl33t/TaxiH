using Microsoft.Extensions.Configuration;
using TaxiHereMobile.Models.DTO;

namespace TaxiHereMobile.Logic.LoginRegister;
public class LoginRegister : ILoginRegister
{
    private readonly string _apiRoute;
    private readonly IConfiguration _configuration;
    public LoginRegister(IConfiguration configuration)
    {
        _configuration = configuration;
        _apiRoute = SetConfiguration();

    }
    public string SetConfiguration()
    {
        var settings = _configuration.GetRequiredSection("ApiSettings").Get<Settings>();
        if (settings != null)
        {
            return settings.Route;
        }
        return "";
    }
    public Task<bool> Login()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Register(RegisterDTO newAccount)
    {
        /* Execute API request Here */
        throw new NotImplementedException();
    }
}
