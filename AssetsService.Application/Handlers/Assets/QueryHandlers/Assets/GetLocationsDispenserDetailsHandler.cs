using AssetsService.Application.Queries;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    internal class GetLocationsDispenserDetailsHandler : IRequestHandler<GetLocationsDispenserDetailsQuery, List<Core.Response.LocationsDispenserDetails>>
    //internal class GetLocationsDispenserDetailsHandler : IRequestHandler<GetLocationsDispenserDetailsQuery, List<Core.Response.LocationsDispenserDetails>>
    {
        private readonly ILocationRepository _LocationRepo;

        public GetLocationsDispenserDetailsHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        public async Task<List<Core.Response.LocationsDispenserDetails>> Handle(GetLocationsDispenserDetailsQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Response.LocationsDispenserDetails>)await _LocationRepo.GetLocationsDispenserDetails(request.Id);
        }
    }
}
