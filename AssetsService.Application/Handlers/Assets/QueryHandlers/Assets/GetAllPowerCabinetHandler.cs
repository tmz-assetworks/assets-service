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
    public class GetAllPowerCabinetHandler : IRequestHandler<GetAllPowerCabinetQuery, List<AssetsService.Core.Entities.PowerCabinet>>
    {
        private readonly IPowerCabinetRepository _powerCabinetRepo;

        public GetAllPowerCabinetHandler(IPowerCabinetRepository powerCabinetRepo)
        {
            _powerCabinetRepo = powerCabinetRepo;
        }
        public async Task<List<AssetsService.Core.Entities.PowerCabinet>> Handle(GetAllPowerCabinetQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.PowerCabinet>)await _powerCabinetRepo.GetAllAsync();
        }
    }
}
