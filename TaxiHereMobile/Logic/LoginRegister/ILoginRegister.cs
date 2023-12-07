using TaxiHereMobile.Models.DTO;

namespace TaxiHereMobile.Logic.LoginRegister;
public interface ILoginRegister
{
    public string SetConfiguration();
    public Task<ResponseDTO> Login();
    public Task<ResponseDTO> Register(RegisterDTO newAccount);
}
