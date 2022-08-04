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
    public class GetAllDispenserHandler : IRequestHandler<GetAllDispenserQuery, List<AssetsService.Core.Entities.Dispenser>>
    {
        private readonly IDispenserRepository _DispenserRepo;

        public GetAllDispenserHandler(IDispenserRepository DispenserRepository)
        {
            _DispenserRepo = DispenserRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Dispenser>> Handle(GetAllDispenserQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.Dispenser>)await _DispenserRepo.GetAllDispenser();
        }
    }
}
