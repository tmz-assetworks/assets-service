using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Repositories;
using AssetsService.Infrastructure.Repositories.Assets;
using AssetsService.Core.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, VehicleResponse>
    {
        private readonly IVehicleRepository _vehicleRepo;

        public UpdateVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }


        public async Task<VehicleResponse> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var VehicleEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Vehicle>(request);
            if (VehicleEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
           
            var updateVehicle = _vehicleRepo.UpdateAsync(VehicleEntitiy, request.Id, "CABLE");
            var mapCableResponse = Mapper.Mappers.Map<VehicleResponse>(updateVehicle.Result);
            return mapCableResponse;
        }
    }
}
