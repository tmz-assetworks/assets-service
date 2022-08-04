using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{

public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdQuery, AssetsService.Core.Entities.Location>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationByIdHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<AssetsService.Core.Entities.Location> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Location)await _locationRepository.GetByIdLocation(Convert.ToInt32(request.Id));
        }
    }
}