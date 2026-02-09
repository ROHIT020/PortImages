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
    public class AddPortCommandHandler:IRequestHandler<AddPortCommand,ApiResponse<object>>
    {
        public readonly IPortRepository _portRepository;
        public AddPortCommandHandler(IPortRepository portRepository)
        {
            this._portRepository = portRepository;  
        }
        public async Task<ApiResponse<object>>Handle(AddPortCommand request,CancellationToken cancellationToken)
        {
            var dto = new PortRequestDTO
            {
                PortName = request.PortName,
                IsActive = request.IsActive,
                CreatedBy = request.CreatedBy
            };
            return await _portRepository.AddPortAsync(dto);
        }
    }
}
