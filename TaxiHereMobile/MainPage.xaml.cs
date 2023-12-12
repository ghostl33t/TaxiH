using Microsoft.Extensions.Configuration;
using TaxiHereMobile.Forms;
using TaxiHereMobile.Logic.LoginRegister;

namespace TaxiHereMobile;

public partial class MainPage : ContentPage
{
    private readonly IConfiguration _configuration;
    private readonly ILoginRegister _loginRegister;
    public MainPage(IConfiguration configuration)
    {
        InitializeComponent();
        _configuration = configuration;
        _loginRegister = new LoginRegister(_configuration);
    }
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (await IsUserLoggedIn())
        {
            btnLogin.IsVisible = false;
            btnRegister.IsVisible = false;
        }
    }
    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterForm(_configuration));
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginForm(_configuration));
    }

    private async Task<bool> IsUserLoggedIn()
    {
        string taxiHUserTokenKey = _configuration.GetSection("KeySettings:TaxiH_UserTokenKey").Value ?? "";
        if (string.IsNullOrWhiteSpace(taxiHUserTokenKey))
            return false;

        var storedToken = await SecureStorage.Default.GetAsync(taxiHUserTokenKey);
        if (string.IsNullOrEmpty(storedToken)) 
            return false;

        if (await _loginRegister.ValidateToken(storedToken))
            return true;

        return false;
    }

    
}
