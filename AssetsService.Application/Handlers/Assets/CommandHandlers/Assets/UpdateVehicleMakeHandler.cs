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
    public class UpdateVehicleMakeHandler : IRequestHandler<UpdateVehicleMakeCommand, VehicleMakeResponse>
    {
        private readonly IVehicleMakeRepository _VehicleMakeRepo;

        public UpdateVehicleMakeHandler(IVehicleMakeRepository VehicleMakeRepository)
        {
            _VehicleMakeRepo = VehicleMakeRepository;
        }


        public async Task<VehicleMakeResponse> Handle(UpdateVehicleMakeCommand request, CancellationToken cancellationToken)
        {
            var VehicleMakeEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.VehicleMake>(request);
            if (VehicleMakeEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            VehicleMakeEntitiy.CreatedOn = DateTime.Now;
            VehicleMakeEntitiy.ModifiedOn = DateTime.Now;
            var updateVehicleMake = _VehicleMakeRepo.UpdateAsync(VehicleMakeEntitiy, request.Id, "VEHICLEMAKE");
            var mapCableResponse = Mapper.Mappers.Map<VehicleMakeResponse>(updateVehicleMake.Result);
            return mapCableResponse;
        }
    }
}
