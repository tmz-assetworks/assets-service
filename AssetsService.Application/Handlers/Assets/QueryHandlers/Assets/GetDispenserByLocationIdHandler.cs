using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{
    public class GetDispenserByLocationHandler : IRequestHandler<GetDispenserByLocationIdQuery, List<AssetsService.Core.Responses.Assets.DispenserByLocationIdResponse>>
    {
        private readonly IDispenserRepository _dispenserRepository;

        public GetDispenserByLocationHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }
        public async Task<List<AssetsService.Core.Responses.Assets.DispenserByLocationIdResponse>> Handle(GetDispenserByLocationIdQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Responses.Assets.DispenserByLocationIdResponse>)await _dispenserRepository.GetDispenserByLocationId(request.LocationId);
        }
    }
}
