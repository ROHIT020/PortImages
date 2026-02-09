using PORTIMAGES.Application.Admin.DTOs;
using PORTIMAGES.Common.Responses;


namespace PORTIMAGES.Application.Admin.Interfaces
{
    public interface IPortRepository
    {
        Task<ApiResponse<object>> AddPortAsync(PortRequestDTO request);
        //Task<ApiResponse<object>> UpdatePortAsync(PortRequestDTO request);
        //Task<ApiResponse<object>> DeletePortAsync(int id, int DeletedBy);
        //Task<ApiResponse<PortRequestDTO?>> GetPortByIdAsync(int id);
        //Task<ApiResponse<List<PortResponseDTO>>> GetPortListAsync();
    }
}
