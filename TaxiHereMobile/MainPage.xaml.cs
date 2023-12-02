using TaxiHereMobile.Forms;
using TaxiHereMobile.Logic.LoginRegister;

namespace TaxiHereMobile;

public partial class MainPage : ContentPage
{
    private readonly ILoginRegister _loginRegisterService;
    public MainPage()
    {
        InitializeComponent();
        _loginRegisterService = new LoginRegister();
    }
    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterForm(_loginRegisterService));
    }
}
