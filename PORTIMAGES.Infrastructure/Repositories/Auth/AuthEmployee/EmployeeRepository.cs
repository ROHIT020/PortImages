using Dapper;
using PORTIMAGES.Application.Auth.AuthEmployee.DTOs;
using PORTIMAGES.Application.Auth.AuthEmployee.Interfaces;
using PORTIMAGES.Infrastructure.Persistence;
using System.Data;

namespace PORTIMAGES.Infrastructure.Repositories.Auth.AuthEmployee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDapperRepository _dapper;
        public EmployeeRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }
        public async Task<LoginResultDTO> LoginAsync(string username, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserName", username);
            parameters.Add("@Password", password);

            var result = await _dapper.QueryFirstOrDefaultAsync<LoginResultDTO>("dbo.usp_auth_employee", parameters, CommandType.StoredProcedure);
            return result;
        }
    }
}
