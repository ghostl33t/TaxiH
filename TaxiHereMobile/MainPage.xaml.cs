using Microsoft.Extensions.Configuration;
using TaxiHereMobile.Forms;

namespace TaxiHereMobile;

public partial class MainPage : ContentPage
{
    private readonly IConfiguration _configuration;
    public MainPage(IConfiguration configuration)
    {
        InitializeComponent();
        _configuration = configuration;
    }
    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterForm(_configuration));
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginForm(_configuration));
    }
}
