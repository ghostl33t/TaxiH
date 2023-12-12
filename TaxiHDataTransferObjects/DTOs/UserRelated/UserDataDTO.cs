namespace TaxiHDataTransferObjects.DTOs.UserRelated;

public class UserDataDTO
{
    public long Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get;set; } = string.Empty;
}
