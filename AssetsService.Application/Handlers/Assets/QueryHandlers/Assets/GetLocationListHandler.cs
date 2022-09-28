using AssetsService.Application.Queries;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetLocationListHandler : IRequestHandler<GetLocationListQuery, Locationalist>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationListHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<Locationalist> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
        {
            return (Locationalist)await _locationRepository.GetLocationList(request.LocationListRequst);
        }
    }
}
