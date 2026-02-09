using PORTIMAGES.Application.Admin.DTOs;
using PORTIMAGES.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PORTIMAGES.Application.Admin.Interfaces
{
    public  interface ICityRepository
    {
        Task<ApiResponse<object>> AddCityAsync(CityRequestDTO request);
    }
}
