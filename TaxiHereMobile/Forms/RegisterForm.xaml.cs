using TaxiHereMobile.Logic.LoginRegister;
using TaxiHereMobile.Models.DTO;

namespace TaxiHereMobile.Forms;

public partial class RegisterForm : ContentPage
{
    private readonly ILoginRegister _loginRegisterService;
	public RegisterForm(ILoginRegister loginRegisterService)
	{
		InitializeComponent();
        _loginRegisterService = loginRegisterService;
    }

    private async void btnRegister_Clicked(object sender, EventArgs e)
    {
        var newAccount = new RegisterDTO(txtUsername.Text ?? "",txtPhone.Text ?? "",txtEmail.Text ?? "",txtPassword.Text ?? "");
        if (await FieldValidations(newAccount))
            await _loginRegisterService.Register(newAccount);
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
    private bool ValidateEmail(string email) { return false; }
    private bool ValidatePasswordComplexity(string password) {  return false; }
    private bool ValidateUserUnique(string userName) {  return false; }
    private bool ValidateEmailUnique(string email) {  return false; }
    private bool ValidatePhoneNumber(string phoneNumber) { return false; }
}