using TaxiHereMobile.Models.DTO;

namespace TaxiHereMobile.Logic.LoginRegister;
public interface ILoginRegister
{
    public Task<ResponseDTO> Login();
    public Task<ResponseDTO> Register(RegisterDTO newAccount);
}
