using Microsoft.Extensions.Configuration;
using TaxiHereMobile.Forms;
using TaxiHereMobile.Logic.LoginRegister;

namespace TaxiHereMobile;

public partial class MainPage : ContentPage
{
    private readonly ILoginRegister _loginRegisterService;
    private readonly IConfiguration _configuration;
    public MainPage(IConfiguration configuration)
    {
        InitializeComponent();
        _configuration = configuration;
        _loginRegisterService = new LoginRegister(_configuration);
    }
    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterForm(_loginRegisterService));
    }
}
