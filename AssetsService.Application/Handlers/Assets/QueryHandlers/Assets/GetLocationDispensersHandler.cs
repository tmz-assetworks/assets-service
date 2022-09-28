using AssetsService.Application.Queries;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetLocationDispensersHandler : IRequestHandler<GetLocationDispensersQuery, PagedList<DispenserByLocationsResponse>>
    {
        private readonly IDispenserRepository _dispenserRepo;

        public GetLocationDispensersHandler(IDispenserRepository dispenserRepo)
        {
            this._dispenserRepo = dispenserRepo;
        }

        public async Task<PagedList<DispenserByLocationsResponse>> Handle(GetLocationDispensersQuery request, CancellationToken cancellationToken)
        {
            return (PagedList<DispenserByLocationsResponse>)await _dispenserRepo.GetLocationDispensers(request._LocationDispensersRequest);
        }
    }
}
