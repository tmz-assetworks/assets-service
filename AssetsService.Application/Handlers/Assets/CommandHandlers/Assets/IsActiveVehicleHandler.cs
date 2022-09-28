using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Repositories;
using AssetsService.Infrastructure.Repositories.Assets;
using AssetsService.Core.Mapper;
using MediatR;
using System;


namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class IsActiveVehicleHandler : IRequestHandler<IsActiveVehicleCommand, VehicleResponse>
    {
        private readonly IVehicleRepository _VehicleRepo;
        public IsActiveVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _VehicleRepo = vehicleRepository;
        }
        public async Task<VehicleResponse> Handle(IsActiveVehicleCommand request, CancellationToken cancellationToken)
        {            
            var vehicleMapper = Mapper.Mappers.Map<AssetsService.Core.Entities.Vehicle>(request);
            vehicleMapper.ModifiedOn = DateTime.Now;
            var updatecable = _VehicleRepo.IsActiveStatusChangeAsync(vehicleMapper, vehicleMapper.Id, "VEHICLE");
             VehicleResponse _vehicleResponse = new VehicleResponse();
             _vehicleResponse.Id = vehicleMapper.Id;
            return _vehicleResponse;
        }
    }
}
