using Microsoft.Extensions.Configuration;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHereMobile.Logic.LoginRegister;

namespace TaxiHereMobile.Forms;

public partial class LoginForm : ContentPage
{
    private readonly IConfiguration _configuration;
    private readonly ILoginRegister _loginRegisterService;
    public LoginForm(IConfiguration configuration)
	{
        _configuration = configuration;
        _loginRegisterService = new LoginRegister(_configuration);
        InitializeComponent();
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        var userCreds = new LoginDTO(txtUsername.Text ?? "", txtPassword.Text ?? "");
        var loginResult = await _loginRegisterService.Login(userCreds);
        var messageHeader = loginResult.StatusCode == 200 ? "SUCCESS!" : "FAILED";
        await DisplayAlert(messageHeader, loginResult.Message, "OK");
    }
}