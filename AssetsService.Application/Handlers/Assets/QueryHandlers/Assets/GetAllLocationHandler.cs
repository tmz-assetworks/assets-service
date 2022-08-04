using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllLocationHandler : IRequestHandler<GetAllLocationQuery, List<AssetsService.Core.Entities.Location>>
    {
        private readonly ILocationRepository _LocationRepo;

        public GetAllLocationHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Location>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.Location>)await _LocationRepo.GetAllLocation();
        }
    }
}
