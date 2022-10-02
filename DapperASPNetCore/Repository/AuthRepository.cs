using Dapper;
using DapperASPNetCore.Context;
using DapperASPNetCore.Contracts;
using DapperASPNetCore.Models;

namespace DapperASPNetCore.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DapperContext _context;
        public AuthRepository(DapperContext context) => _context = context;

        public async Task<LoginModel> GetUser(LoginModel user)
        {
            var query = "SELECT * FROM Users where UserName = @UserName and Password = @Password";
            //var parameters = new DynamicParameters();
            //parameters.Add("UserName", user.UserName);
            //parameters.Add("Password", user.Password);
            using (var connection = _context.CreateConnection())
            {
                var dbUser = await connection.QuerySingleOrDefaultAsync<LoginModel>(query, user);
                return dbUser;
            }
        }
    }
}
