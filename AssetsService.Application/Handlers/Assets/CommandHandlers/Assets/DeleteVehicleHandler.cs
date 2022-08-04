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
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, VehicleResponse>
    {
        private readonly IVehicleRepository _VehicleRepo;
        public DeleteVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _VehicleRepo = vehicleRepository;
        }
        public async Task<VehicleResponse> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicleEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Vehicle>(request);
            if (vehicleEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatecable = _VehicleRepo.DeleteActiveAsync(vehicleEntitiy, vehicleEntitiy.Id, "VEHICLEMAKE");
            var mapcustomerResponse = Mapper.Mappers.Map<VehicleResponse>(updatecable.Result);

            return mapcustomerResponse;
        }
    }
}
