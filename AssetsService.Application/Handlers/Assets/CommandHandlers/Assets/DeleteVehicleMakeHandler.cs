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
    public class DeleteVehicleMakeMakeHandler : IRequestHandler<DeleteVehicleMakeCommand, VehicleMakeResponse>
    {
        private readonly IVehicleMakeRepository _VehicleMakeRepo;
        public DeleteVehicleMakeMakeHandler(IVehicleMakeRepository VehicleMakeRepository)
        {
            _VehicleMakeRepo = VehicleMakeRepository;
        }
        public async Task<VehicleMakeResponse> Handle(DeleteVehicleMakeCommand request, CancellationToken cancellationToken)
        {
            var VehicleMakeEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.VehicleMake>(request);
            if (VehicleMakeEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatecable = _VehicleMakeRepo.DeleteActiveAsync(VehicleMakeEntitiy, VehicleMakeEntitiy.Id, "VEHICLEMAKE");
            var mapcustomerResponse = Mapper.Mappers.Map<VehicleMakeResponse>(updatecable.Result);

            return mapcustomerResponse;
        }
    }
}
