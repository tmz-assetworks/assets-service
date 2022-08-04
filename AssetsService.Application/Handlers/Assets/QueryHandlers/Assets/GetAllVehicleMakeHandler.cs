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
    public class GetAllVehicleMakeHandler : IRequestHandler<GetAllVehicleMakeQuery, List<AssetsService.Core.Entities.VehicleMake>>
    {
        private readonly IVehicleMakeRepository _VehicleMakeRepo;

        public GetAllVehicleMakeHandler(IVehicleMakeRepository VehicleMakeRepository)
        {
            _VehicleMakeRepo = VehicleMakeRepository;
        }
        public async Task<List<AssetsService.Core.Entities.VehicleMake>> Handle(GetAllVehicleMakeQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.VehicleMake>)await _VehicleMakeRepo.GetAllVehicleMake();
        }
    }
}
