using TaxiHDataTransferObjects.DTOs.ReqResRelated;
using TaxiHDataTransferObjects.DTOs.UserRelated;

namespace TaxiHereMobile.Logic.LoginRegister;
public interface ILoginRegister
{
    public Task<ResponseDTO> Login(LoginDTO userCreds);
    public Task<ResponseDTO> Register(RegisterDTO newAccount);
}
