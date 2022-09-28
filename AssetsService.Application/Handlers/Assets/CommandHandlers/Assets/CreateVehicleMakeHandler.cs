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
    public class CreateVehicleMakeHandler : IRequestHandler<CreateVehicleMakeCommand, VehicleMakeResponse>
    {
        private readonly IVehicleMakeRepository _vehicleRepo;

        public CreateVehicleMakeHandler(IVehicleMakeRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }
        public async Task<VehicleMakeResponse> Handle(CreateVehicleMakeCommand request, CancellationToken cancellationToken)
        {
            var vehicleEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.VehicleMake>(request);
            if (vehicleEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            vehicleEntitiy.CreatedOn = DateTime.Now;
            vehicleEntitiy.ModifiedOn = DateTime.Now;
            vehicleEntitiy.IsActive = true;
            var addvehicleResponse = await _vehicleRepo.AddAsync(vehicleEntitiy);
            var mapvehicleResponse = Mapper.Mappers.Map<VehicleMakeResponse>(addvehicleResponse);
            return mapvehicleResponse;
        }
    }
}

