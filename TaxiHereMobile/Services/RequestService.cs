using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace TaxiHereMobile.Services;

public class RequestService : IRequestService
{
    private readonly IConfiguration _configuration;
    public RequestService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GetRoute()
    {
        var settings = _configuration.GetRequiredSection("ApiSettings").Get<Settings>();
        if (settings != null)
        {
            return settings.RouteEmulator;
        }
        return "";
    }
    public string PrepareEndPoint(string endPoint)
    {
        return GetRoute() + endPoint;
    }
    public StringContent PrepareRequest(object dtoObject)
    {
        var dataContent = JsonSerializer.Serialize(dtoObject);
        return new StringContent(dataContent, Encoding.UTF8, "application/json");
    }
}
