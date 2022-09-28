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
    public class GetVehicleModelDDLHandler : IRequestHandler<GetVechicleModelDDLQuery, List<ListDropDown>>
    {
        private readonly IVehicleRepository _VehicleMakeRepo;

        public GetVehicleModelDDLHandler(IVehicleRepository vehicleRepository)
        {
            _VehicleMakeRepo = vehicleRepository;
        }
        public async Task<List<ListDropDown>> Handle(GetVechicleModelDDLQuery request, CancellationToken cancellationToken)
        {
            return (List<ListDropDown>)await _VehicleMakeRepo.GetVehicleModelDDLList();
        }
    }
}
