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
    public class GetDispenserByLocationsHandler : IRequestHandler<GetDispenserByLocationsQuery, List<Core.Response.DispenserByLocationsResponse>>
    {
        private readonly IDispenserRepository _dispenserRepository;

        public GetDispenserByLocationsHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }
        public async Task<List<Core.Response.DispenserByLocationsResponse>> Handle(GetDispenserByLocationsQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Response.DispenserByLocationsResponse>)await _dispenserRepository.GetDispenserByLocations(request.StationId,request.ChargeBoxId);
        }
    }
}
