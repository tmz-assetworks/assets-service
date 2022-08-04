using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
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

public class GetPowerCabinetByIdHandler : IRequestHandler<GetPowerCabinetByIdQuery, AssetsService.Core.Entities.PowerCabinet>
    {
        private readonly IPowerCabinetRepository _powerCabinetRepository;
        public GetPowerCabinetByIdHandler(IPowerCabinetRepository powerCabinetRepository)
        {
            _powerCabinetRepository = powerCabinetRepository;
        }
        public async Task<AssetsService.Core.Entities.PowerCabinet> Handle(GetPowerCabinetByIdQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.PowerCabinet)await _powerCabinetRepository.GetByIdAsync(Convert.ToInt32(request.Id));
        }
    }
}
