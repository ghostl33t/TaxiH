using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaxiHereMobile.Models.DTO;
using TaxiHereMobile.Services;

namespace TaxiHereMobile.Logic.LoginRegister;
public class LoginRegister : ILoginRegister
{
    private readonly string _apiRoute;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly IRequestService _requestService;
    public LoginRegister(IConfiguration configuration)
    {
        _configuration = configuration;
        _apiRoute = SetConfiguration();
        _httpClient = new HttpClient();
        _requestService = new RequestService();
    }
    public string SetConfiguration()
    {
        var settings = _configuration.GetRequiredSection("ApiSettings").Get<Settings>();
        if (settings != null)
        {
            return settings.RouteEmulator;
        }
        return "";
    }
    public Task<ResponseDTO> Login()
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDTO> Register(RegisterDTO newAccount)
    {
        var requestRoute = _apiRoute + "api/User";
        var reqBody = _requestService.PrepareRequest(newAccount);
        try
        {
            var res = await _httpClient.PostAsync(requestRoute, reqBody);
            var resMessage = await res.Content.ReadAsStringAsync();
            return new ResponseDTO(res.StatusCode, resMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}
