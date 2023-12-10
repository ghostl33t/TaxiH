namespace TaxiHDataTransferObjects.DTOs.UserRelated;
public class RegisterDTO
{
    public RegisterDTO()
    {
            
    }
    public RegisterDTO(string username, string phone, string email, string password)
    {
        Username = username;
        Phone = phone;
        Email = email;
        Password = password;
    }
    public string Username { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
