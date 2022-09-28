using AssetsService.Application.Queries;
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
    public class GetVehicleMakeDDLHandler : IRequestHandler<GetVechicleMakeDDLQuery, List<ListDropDown>>
    {
        private readonly IVehicleRepository _VehicleMakeRepo;

        public GetVehicleMakeDDLHandler(IVehicleRepository VehicleMakeRepository)
        {
            _VehicleMakeRepo = VehicleMakeRepository;
        }
        public async Task<List<ListDropDown>> Handle(GetVechicleMakeDDLQuery request, CancellationToken cancellationToken)
        {
            return (List<ListDropDown>)await _VehicleMakeRepo.GetVehicleMakeDDLList();
        }
    }
}
