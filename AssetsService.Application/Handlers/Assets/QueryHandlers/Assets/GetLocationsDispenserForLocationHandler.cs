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
    internal class GetLocationsDispenserForLocationHandler : IRequestHandler<GetLocationsDispenserForLocationQuery, List<Core.Response.LocationDispenserForLocation>>
    {
        private readonly ILocationRepository _LocationRepo;

        public GetLocationsDispenserForLocationHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        public async Task<List<Core.Response.LocationDispenserForLocation>> Handle(GetLocationsDispenserForLocationQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Response.LocationDispenserForLocation>)await _LocationRepo.GetLocationsDispenserForLocation(request.Id);
        }
    }
}