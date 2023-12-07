using TaxiHereMobile.Models.DTO;

namespace TaxiHereMobile.Logic.LoginRegister;
internal interface ILoginRegister
{
    internal string SetConfiguration();
    internal Task<ResponseDTO> Login();
    internal Task<ResponseDTO> Register(RegisterDTO newAccount);
}
