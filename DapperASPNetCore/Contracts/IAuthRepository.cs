using DapperASPNetCore.Models;

namespace DapperASPNetCore.Contracts
{
    public interface IAuthRepository
    {
        public Task<LoginModel> GetUser(LoginModel user);
    }
}
