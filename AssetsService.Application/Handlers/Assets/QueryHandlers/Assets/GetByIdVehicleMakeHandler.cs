using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdVehicleMakeHandler : IRequestHandler<GetByIdVehicleMakeQuery, AssetsService.Core.Entities.VehicleMake>
    {
        private readonly IVehicleMakeRepository _VehicleMakeRepo;

        public GetByIdVehicleMakeHandler(IVehicleMakeRepository VehicleMakeRepository)
        {
            _VehicleMakeRepo = VehicleMakeRepository;
        }

        public async Task<AssetsService.Core.Entities.VehicleMake> Handle(GetByIdVehicleMakeQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.VehicleMake)await _VehicleMakeRepo.GetByIdVehicleMake(request.Id);
        }
    }
}
