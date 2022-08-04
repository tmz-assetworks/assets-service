using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
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
    public class GetAllLocationNameHandler : IRequestHandler<GetAllLocationNameQuery, List<AssetsService.Core.Response.LocationData>>
    {
        private readonly ILocationRepository _LocationRepo;

        public GetAllLocationNameHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        public async Task<List<AssetsService.Core.Response.LocationData>> Handle(GetAllLocationNameQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Response.LocationData>) await _LocationRepo.GetAllLocationName();
        }
    }
}
