using Microsoft.Extensions.Configuration;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using TaxiHereMobile.Models.DTO;

namespace TaxiHereMobile.Logic.LoginRegister;
public class LoginRegister : ILoginRegister
{
    private readonly string _apiRoute;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    public LoginRegister(IConfiguration configuration)
    {
        _configuration = configuration;
        _apiRoute = SetConfiguration();
        _httpClient = new HttpClient();
        //var handler = new HttpClientHandler();
        //handler.ServerCertificateCustomValidationCallback = ValidateServerCertificate;
        //_httpClient = new HttpClient(handler);
    }
    //private static bool ValidateServerCertificate(HttpRequestMessage request, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //{
    //    //Just for the test, import valid certificate!!!!
    //    return true;
    //}
    public string SetConfiguration()
    {
        var settings = _configuration.GetRequiredSection("ApiSettings").Get<Settings>();
        if (settings != null)
        {
            return settings.RouteEmulator;
        }
        return "";
    }
    public Task<bool> Login()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Register(RegisterDTO newAccount)
    {
        var requestRoute = _apiRoute + "api/User";
        var dataContent = JsonSerializer.Serialize(newAccount);
        var reqBody = new StringContent(dataContent, Encoding.UTF8, "application/json");
        try
        {
            var res = await _httpClient.PostAsync(requestRoute, reqBody);
            if (res.IsSuccessStatusCode)
            {
                var resMessage = res.Content;
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
        
        return false;
    }
}
