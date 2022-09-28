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
using AssetsService.Core.Response;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{

public class GetPowerCabinetByIdHandler : IRequestHandler<GetPowerCabinetByIdQuery, GetPowerCabinetResponse>
    {
        private readonly IPowerCabinetRepository _powerCabinetRepository;
        public GetPowerCabinetByIdHandler(IPowerCabinetRepository powerCabinetRepository)
        {
            _powerCabinetRepository = powerCabinetRepository;
        }
        public async Task<GetPowerCabinetResponse> Handle(GetPowerCabinetByIdQuery request, CancellationToken cancellationToken)
        {
            return (GetPowerCabinetResponse)await _powerCabinetRepository.GetPowerCabinetById(Convert.ToInt32(request.Id));
        }
    }
}
