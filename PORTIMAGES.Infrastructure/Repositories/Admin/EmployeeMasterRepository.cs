using Dapper;
using Microsoft.Extensions.Logging;
using PORTIMAGES.Application.Admin.DTOs;
using PORTIMAGES.Application.Admin.Interfaces;
using PORTIMAGES.Common.Responses;
using PORTIMAGES.Infrastructure.Persistence;
using System.Data;

namespace PORTIMAGES.Infrastructure.Repositories.Admin
{
    public class EmployeeMasterRepository : IEmployeeMasterRepository
    {
        private readonly IDapperRepository _dapper;
        private readonly ILogger<EmployeeMasterRepository> _logger;
        public EmployeeMasterRepository(IDapperRepository dapper, ILogger<EmployeeMasterRepository> logger)
        {
            this._dapper = dapper;
            this._logger = logger;
        }

        public async Task<ApiResponse<object>> AddEmployeeAsync(EmployeeMasterRequestDTO request)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@FullName", request.FullName);
                param.Add("@Email", request.Email);
                param.Add("@Mobile", request.Mobile);
                param.Add("@IsActive", request.IsActive);
                param.Add("@CreatedBy", request.CreatedBy);
                param.Add("@Status", dbType: DbType.Int16, direction: ParameterDirection.Output);

                await _dapper.ExecuteAsync("dbo.usp_add_employee", param, CommandType.StoredProcedure);
                short result = param.Get<short?>("@Status") ?? -99;//1,2,-99
                return result switch
                {
                    1 => new ApiResponse<object>(1, "Employee added successfully !!"),
                    2 => new ApiResponse<object>(2, "Email id already exists !!"),
                    3 => new ApiResponse<object>(3, "Mobile number already exists !!"),
                    _ => new ApiResponse<object>(4, "Something went wrong !!")
                };
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString().Substring(0, 8); // first 8 chars              
                _logger.LogError(ex, "AddEmployee failed | ErrorId: {ErrorId}", errorId);
                return new ApiResponse<object>(-99, "Something went wrong.<br/>Please contact to support with Error ID: " + errorId);
            }

        }
        public async Task<ApiResponse<object>> UpdateEmployeeAsync(EmployeeMasterRequestDTO request)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ID", request.ID);
                param.Add("@FullName", request.FullName);
                param.Add("@Email", request.Email);
                param.Add("@Mobile", request.Mobile);
                param.Add("@IsActive", request.IsActive);
                param.Add("@UpdatedBy", request.UpdatedBy);
                param.Add("@Status", dbType: DbType.Int16, direction: ParameterDirection.Output);
                await _dapper.ExecuteAsync("dbo.usp_update_employee", param, CommandType.StoredProcedure);
                short result = param.Get<short?>("@Status") ?? -99;
                return result switch
                {
                    1 => new ApiResponse<object>(1, "Employee updated successfully !!"),
                    2 => new ApiResponse<object>(2, "Email id already exists !!"),
                    3 => new ApiResponse<object>(3, "Mobile number already exists !!"),
                    -1 => new ApiResponse<object>(-1, "Employee not found !!"),
                    _ => new ApiResponse<object>(-99, "Something went wrong !!")
                };
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString().Substring(0, 8); // first 8 chars              
                _logger.LogError(ex, "UpdateEmployee failed | ErrorId: {ErrorId}", errorId);
                return new ApiResponse<object>(-99, "Something went wrong.<br/>Please contact to support with Error ID: " + errorId);
            }
        }

        public async Task<ApiResponse<object>> DeleteEmployeeAsync(int id, int DeletedBy)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ID", id);
                param.Add("@DeletedBy", DeletedBy);
                param.Add("@Status", dbType: DbType.Int16, direction: ParameterDirection.Output);
                await _dapper.ExecuteAsync("dbo.usp_delete_employee", param, CommandType.StoredProcedure);
                short result = param.Get<short?>("@Status") ?? -99;
                return result switch
                {
                    1 => new ApiResponse<object>(1, "Employee deleted successfully !!"),
                    -1 => new ApiResponse<object>(-1, "Employee not found !!"),
                    _ => new ApiResponse<object>(-99, "Something went wrong !!")
                };
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString().Substring(0, 8); // first 8 chars              
                _logger.LogError(ex, "DeleteEmployee failed | ErrorId: {ErrorId}", errorId);
                return new ApiResponse<object>(-99, "Something went wrong.<br/>Please contact to support with Error ID: " + errorId);
            }
        }
        public async Task<ApiResponse<EmployeeMasterRequestDTO?>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var data = await _dapper.QueryFirstOrDefaultAsync<EmployeeMasterRequestDTO?>("dbo.usp_get_employee_by_id", new { ID = id }, CommandType.StoredProcedure);
                if (data == null)
                {
                    return new ApiResponse<EmployeeMasterRequestDTO?>(-1, "Employee not found !!", null);
                }
                return new ApiResponse<EmployeeMasterRequestDTO?>(1, "Success", data);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString().Substring(0, 8); // first 8 chars              
                _logger.LogError(ex, "GetEmployeeById failed | ErrorId: {ErrorId}", errorId);
                return new ApiResponse<EmployeeMasterRequestDTO?>(-99, "Something went wrong.<br/>Please contact to support with Error ID: " + errorId);
            }

        }
        public async Task<ApiResponse<List<EmployeeMasterResponseDTO>>> GetEmployeeListAsync()
        {
            try
            {
                var data = await _dapper.QueryAsync<EmployeeMasterResponseDTO>("dbo.usp_get_employee_list", null, CommandType.StoredProcedure);
                var list = data.ToList();
                return new ApiResponse<List<EmployeeMasterResponseDTO>>(1, "Success", list);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString().Substring(0, 8); // first 8 chars              
                _logger.LogError(ex, "GetEmployeeList failed | ErrorId: {ErrorId}", errorId);
                return new ApiResponse<List<EmployeeMasterResponseDTO>>(-99, "Something went wrong.<br/>Please contact to support with Error ID: " + errorId);
            }

        }
    }
}
