using Dapper;
using PORTIMAGES.Application.Auth.AuthUser.DTOs;
using PORTIMAGES.Application.Auth.AuthUser.Interfaces;
using PORTIMAGES.Infrastructure.Persistence;
using System.Data;
namespace PORTIMAGES.Infrastructure.Repositories.Auth.AuthUser
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperRepository _dapper;

        public UserRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<UserLoginResultDTO> LoginAsync(string username,string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserName", username);
            parameters.Add("@Password", password);
            return await _dapper.QueryFirstOrDefaultAsync<UserLoginResultDTO>("dbo.usp_auth_user",parameters,CommandType.StoredProcedure);
        }
    }
}
