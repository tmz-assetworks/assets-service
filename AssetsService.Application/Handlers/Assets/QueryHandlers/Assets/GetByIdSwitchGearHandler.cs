using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdSwitchGearHandler : IRequestHandler<GetByIdSwitchGearQuery, GetSwitchGearResponse>
    {
        private readonly ISwitchGearRepository _switchGearRepository;
        public GetByIdSwitchGearHandler(ISwitchGearRepository switchGearRepository)
        {
            _switchGearRepository = switchGearRepository;
        }
        public async Task<GetSwitchGearResponse> Handle(GetByIdSwitchGearQuery request, CancellationToken cancellationToken)
        {
            return (GetSwitchGearResponse)await _switchGearRepository.GetSwitchGearById(request.Id);
        }
    }
}
