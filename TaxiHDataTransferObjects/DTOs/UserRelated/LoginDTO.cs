namespace TaxiHDataTransferObjects.DTOs.UserRelated;

public class LoginDTO
{
    public LoginDTO()
    {
            
    }
    public LoginDTO(string username, string password)
    {
        Username = username;
        Password = password;
    }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
