using AssetsService.Application.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetLocationsDispenserformapHandler :IRequestHandler<GetLocationsDispenserformapQuery, List<Core.Response.LocationsDispenser>>
    {
        private readonly ILocationRepository _LocationRepo;

        public GetLocationsDispenserformapHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        public async Task<List<Core.Response.LocationsDispenser>> Handle(GetLocationsDispenserformapQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Response.LocationsDispenser>)await _LocationRepo.GetLocationsDispenserformap(request.Id);
        }
    }
}
