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

public class GetDispenserByStationIdHandler : IRequestHandler<GetDispenserByStationIdQuery, AssetsService.Core.Entities.Charger>
    {
        private readonly IDispenserRepository _dispenserRepository;
        public GetDispenserByStationIdHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }
        public async Task<AssetsService.Core.Entities.Charger> Handle(GetDispenserByStationIdQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Charger)await _dispenserRepository.GetDispenserByStationId(Convert.ToInt32(request.StationId));
        }
    }
}
