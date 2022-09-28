using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllLocationStatusHandler : IRequestHandler<GetAllLocationStatusQuery, List<AllLocationStatuss>>
    {
        private readonly ILocationRepository _LocationRepo;

        public GetAllLocationStatusHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        
        public async Task<List<AllLocationStatuss>> Handle(GetAllLocationStatusQuery request, CancellationToken cancellationToken)
        {
           return (List<AllLocationStatuss>)await _LocationRepo.GetAllLocationStatus();
        }
    }
}
