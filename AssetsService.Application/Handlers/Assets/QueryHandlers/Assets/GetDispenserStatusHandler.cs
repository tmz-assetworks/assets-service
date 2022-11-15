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
    public class GetDispenserStatusHandler : IRequestHandler<GetDispenserStatusQuery, List<AssetsService.Core.Entities.ChargerStatus>>
    {
        private readonly IDispenserRepository _DispenserRepo;

        public GetDispenserStatusHandler(IDispenserRepository modelRepository)
        {
            _DispenserRepo = modelRepository;
        }
        public async Task<List<AssetsService.Core.Entities.ChargerStatus>> Handle(GetDispenserStatusQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.ChargerStatus>)await _DispenserRepo.GetDispenserStatusData(request.statusRequest);
        }
    }
}
