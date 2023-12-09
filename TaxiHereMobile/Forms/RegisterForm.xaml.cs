using Microsoft.Extensions.Configuration;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHereMobile.Logic.LoginRegister;

namespace TaxiHereMobile.Forms;

public partial class RegisterForm : ContentPage
{
    private readonly IConfiguration _configuration;
    private readonly ILoginRegister _loginRegisterService;
    public RegisterForm(IConfiguration configuration)
	{
            _configuration = configuration;
            _loginRegisterService = new LoginRegister(_configuration);
            InitializeComponent();
    }

    private async void btnRegister_Clicked(object sender, EventArgs e)
    {
        var newAccount = new RegisterDTO(txtUsername.Text ?? "",txtPhone.Text ?? "",txtEmail.Text ?? "",txtPassword.Text ?? "");
        if (await FieldValidations(newAccount))
        {
            var registrationResult = await _loginRegisterService.Register(newAccount);
            var messageHeader = registrationResult.StatusCode == 201 ? "SUCCESS!" : "FAILED";
            await DisplayAlert(messageHeader, registrationResult.Message, "OK");
        }
            
    }

    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
    private async Task<bool> FieldValidations(RegisterDTO account)
    {
        var errorMessage = string.Empty;

        if (account.Username.Length < 5)
            errorMessage = "Minimum length of the field Username is 5!";
        else if (account.Phone.Length < 9)
            errorMessage = "Minimum length of the field Phone is 9!";
        else if (account.Password.Length < 8)
            errorMessage = "Minimum length of the field Password is 8!";

        if (!string.IsNullOrEmpty(errorMessage))
        {
            await DisplayAlert("INFO", errorMessage, "OK");
            return false;
        }
            
        return true;
    }
}