using Dapper;
using Microsoft.Extensions.Logging;
using PORTIMAGES.Application.Admin.DTOs;
using PORTIMAGES.Application.Admin.Interfaces;
using PORTIMAGES.Common.Responses;
using PORTIMAGES.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PORTIMAGES.Infrastructure.Repositories.Admin
{
    public class PortRepository : IPortRepository
    {
        private readonly IDapperRepository _dapper;
        private readonly ILogger<TerminalRepository> _logger;

        public PortRepository(IDapperRepository dapper, ILogger<TerminalRepository> logger)
        {
            this._dapper = dapper;
            this._logger = logger;
        }
        public async Task<ApiResponse<object>> AddPortAsync(PortRequestDTO request)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@PortName", request.PortName);
                param.Add("@IsActive", request.IsActive);
                param.Add("@CreatedBy", request.CreatedBy);
                param.Add("@Status", dbType: DbType.Int16, direction: ParameterDirection.Output);
                await _dapper.ExecuteAsync("dbo.usp_add_port", param, CommandType.StoredProcedure);
                short result = param.Get<short?>("@Status") ?? -99; // 1, 2, -99
                return result switch
                {
                    1 => new ApiResponse<object>(1, "Port added successfully !!"),
                    2 => new ApiResponse<object>(2, "Port already exists !!"),
                    _ => new ApiResponse<object>(3, "Something went wrong !!")
                };
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid().ToString().Substring(0, 8); // first 8 chars              
                //_logger.LogError(ex, "AddTerminal failed | ErrorId: {ErrorId}", errorId);
                return new ApiResponse<object>(-99, "Something went wrong.<br/>Please contact to support with Error ID: " + errorId);
            }
        }
        public async Task<ApiResponse<List<PortResponseDTO>>>GetPortListAsync(){
}
    }
}
