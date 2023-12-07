using System.Net;

namespace TaxiHereMobile.Models.DTO;
public class ResponseDTO
{
    public ResponseDTO(HttpStatusCode statusCode, string message)
    {
        StatusCode = ((int)statusCode);
        Message = message;
    }
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}
