using System.Text;
using System.Text.Json;

namespace TaxiHereMobile.Services;

public class RequestService : IRequestService
{
    public StringContent PrepareRequest(object dtoObject)
    {
        var dataContent = JsonSerializer.Serialize(dtoObject);
        return new StringContent(dataContent, Encoding.UTF8, "application/json");
    }
}
