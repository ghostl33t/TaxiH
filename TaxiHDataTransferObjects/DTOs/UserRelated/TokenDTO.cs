namespace TaxiHDataTransferObjects.DTOs.UserRelated;

public class TokenDTO
{
    public string TokenValue { get; set; } = string.Empty;
    public long UserId { get; set; }
}
