using System.Net;

namespace TaxiHDataTransferObjects.DTOs.ReqResRelated;
public class ResponseDTO
{
    public ResponseDTO() { }
    public ResponseDTO(HttpStatusCode statusCode, string message)
    {
        StatusCode = ((int)statusCode);
        Message = message;
    }
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}
