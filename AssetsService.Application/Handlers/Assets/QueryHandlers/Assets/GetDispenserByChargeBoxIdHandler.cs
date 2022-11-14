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

public class GetDispenserByChargeBoxIdHandler : IRequestHandler<GetDispenserByChargeBoxIdQuery, AssetsService.Core.Entities.Charger>
    {
        private readonly IDispenserRepository _dispenserRepository;
        public GetDispenserByChargeBoxIdHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }
        public async Task<AssetsService.Core.Entities.Charger> Handle(GetDispenserByChargeBoxIdQuery request, CancellationToken cancellationToken)
        {
            //return (AssetsService.Core.Entities.Dispenser)await _dispenserRepository.GetDispenserByChargeBoxId(request.ChargeBoxId);
        return (AssetsService.Core.Entities.Charger)await _dispenserRepository.GetDispenserByChargeBoxId(request.ChargeBoxId);
        }
    }
}
