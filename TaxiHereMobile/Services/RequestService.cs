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
    public string GetRoute(RequestTo reqTo)
    {
        var settings = _configuration.GetRequiredSection("ApiSettings").Get<Settings>();
        if (settings != null)
        {
            if (reqTo == RequestTo.API)
                return settings.RouteEmulator;
            if (reqTo == RequestTo.AZFunctions)
                return settings.RouteAzureFunctions;
        }
        return "";
    }
    public string PrepareEndPoint(RequestTo reqTo, string endPoint)
    {
        return GetRoute(reqTo) + endPoint;
    }
    public StringContent PrepareRequest(object dtoObject)
    {
        var dataContent = JsonSerializer.Serialize(dtoObject);
        return new StringContent(dataContent, Encoding.UTF8, "application/json");
    }
}
public enum RequestTo
{
    API = 0,
    AZFunctions = 1
}