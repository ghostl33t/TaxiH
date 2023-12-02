using TaxiHereMobile.Models.DTO;

namespace TaxiHereMobile.Logic.LoginRegister
{
    public interface ILoginRegister
    {
        public Task<bool> Login();
        public Task<bool> Register(RegisterDTO newAccount);
    }
}
