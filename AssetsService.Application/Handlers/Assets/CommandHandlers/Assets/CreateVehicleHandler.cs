using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Repositories;
using AssetsService.Core.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, VehicleResponse>
    {
        private readonly IVehicleRepository _vehicleRepo;

        public CreateVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }
        public async Task<VehicleResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicleEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Vehicle>(request);
            if (vehicleEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            vehicleEntitiy.IsActive = true;
            var addvehicleResponse = await _vehicleRepo.AddAsync(vehicleEntitiy);
            var mapvehicleResponse = Mapper.Mappers.Map<VehicleResponse>(addvehicleResponse);
            return mapvehicleResponse;
        }
    }
}
