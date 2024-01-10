using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHereMobile.Services;

namespace TaxiHereMobile.Logic.LoginRegister;
public class LoginRegister : ILoginRegister
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly IRequestService _requestService;
    public LoginRegister(IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = new HttpClient();
        _requestService = new RequestService(_configuration);
    }
    public async Task<ResponseDTO> Login(LoginDTO userCreds)
    {
        var requestRoute = _requestService.PrepareEndPoint(RequestTo.AZFunctions, "LoginFunction");
        var reqBody = _requestService.PrepareRequest(userCreds);
        try
        {
            var res = await _httpClient.PostAsync(requestRoute,reqBody);
            var resMessage = await res.Content.ReadAsStringAsync();

            var responseObject = JsonSerializer.Deserialize<ResponseDTO>(resMessage);
            if (responseObject != null)
                await SaveTokenInSecureStorage(responseObject.Message);

            return new ResponseDTO(res.StatusCode, resMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
    public async Task<ResponseDTO> Register(RegisterDTO newAccount)
    {
        var requestRoute = _requestService.PrepareEndPoint(RequestTo.API,"api/User");
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
    public async Task<bool> SaveTokenInSecureStorage(string token)
    {
        try
        {
            string taxiHUserTokenKey = _configuration.GetSection("KeySettings:TaxiH_UserTokenKey").Value ?? "";
            if (string.IsNullOrWhiteSpace(taxiHUserTokenKey)) 
                return false;

            await SecureStorage.Default.SetAsync(taxiHUserTokenKey, token);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
    public async Task<TokenDTO> RefreshToken(TokenDTO userToken)
    {
        var requestRoute = _requestService.PrepareEndPoint(RequestTo.AZFunctions, "RefreshUserToken");
        var reqBody = _requestService.PrepareRequest(userToken);
        try
        {
            var res = await _httpClient.PostAsync(requestRoute, reqBody);
            var resMessage = await res.Content.ReadAsStringAsync();
            var tokenFromResponseMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenDTO>(resMessage);

            if (tokenFromResponseMessage != null)
                userToken = tokenFromResponseMessage;
            else
                Console.WriteLine("ERROR: Issue with refreshing user token!");
            
            return userToken;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }

    }
    public async Task<bool> ValidateToken(string storedToken)
    {
        var userToken = new TokenDTO()
        {
            UserId = 0, 
            TokenValue = storedToken
        };
        var requestRoute = _requestService.PrepareEndPoint(RequestTo.AZFunctions, "ValidateUserTokenFunction");
        var reqBody = _requestService.PrepareRequest(userToken);

        try
        {
            var res = await _httpClient.PostAsync(requestRoute, reqBody);
            var userId = Convert.ToInt32(await res.Content.ReadAsStringAsync());
            if (userId == 0)
                return false;

            userToken.UserId = userId;
            userToken = await RefreshToken(userToken);
            await SaveTokenInSecureStorage(userToken.TokenValue); 

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }

    }
}
