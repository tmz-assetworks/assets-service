using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
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
    
   
    public class GetAllDispenserLocationHandler : IRequestHandler<GetDispenserslocationIdQuery, DispenserLocationResponse>
    {
        private readonly IDispenserLocationRepository _DispenserRepo;

        public GetAllDispenserLocationHandler(IDispenserLocationRepository DispenserRepository)
        {
            _DispenserRepo = DispenserRepository;
        }
        public async Task<DispenserLocationResponse> Handle(GetDispenserslocationIdQuery request, CancellationToken cancellationToken)
        {
            return (DispenserLocationResponse)await _DispenserRepo.GetDispenserByLocationsId(request.DispenserLocationRequest);
        }
    }
}
