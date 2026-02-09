using MediatR;
using PORTIMAGES.Application.Admin.Commands;
using PORTIMAGES.Application.Admin.DTOs;
using PORTIMAGES.Application.Admin.Interfaces;
using PORTIMAGES.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PORTIMAGES.Application.Admin.Handlers
{
    public class AddCityCommandHandler:IRequestHandler<AddCityCommand,ApiResponse<object>>
            {
        private readonly ICityRepository _cityRepository;
        public AddCityCommandHandler(ICityRepository cityRepository)
        {
            this._cityRepository= cityRepository;  
        }
        public async Task<ApiResponse<object>>Handle(AddCityCommand request,CancellationToken cancellationToken)
        {
            var dto = new CityRequestDTO
            {
                CityName = request.CityName,
                IsActive = request.IsActive,
                CreatedBy = request.CreatedBy,
            };
            return await _cityRepository.AddCityAsync(dto); 
        }
    }
}
