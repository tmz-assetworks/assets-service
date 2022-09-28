using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdVehicleHandler : IRequestHandler<GetByIdVehicleQuery,VehicleDTO>
    {
        private readonly IVehicleRepository _vehicleRepo;

        public GetByIdVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }

        public async Task<VehicleDTO> Handle(GetByIdVehicleQuery request, CancellationToken cancellationToken)
        {
            return await _vehicleRepo.GetVehicleById(request.Id);
        }
        
    }
}
