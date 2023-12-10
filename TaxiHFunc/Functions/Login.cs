using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TaxiHDataTransferObjects.DTOs.UserRelated;
using TaxiHFunc.Repositories.UserRelated;

namespace TaxiHFunc.Functions;

public class Login : ILogin
{ 
    private readonly IUser _userRepository;
    public Login(IUser userRepository)
    {
        _userRepository = userRepository;
    }

    [Function("Login")]
    public async Task<string> Run([HttpTrigger(AuthorizationLevel.Function, "post")] LoginDTO req)
    {
        var res = await _userRepository.LoginUser(req);
        var mess = "";
        if (res == true)
        {
            mess = "User exists";
        }
        else
            mess = "User doesn't exist";

        Console.WriteLine(mess);
        return mess;
    }
}
