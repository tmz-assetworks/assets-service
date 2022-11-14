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
    public class GetAllSwitchGearHandler : IRequestHandler<GetAllSwitchGearQuery, AllSwitchGearResponse>
    {
        private readonly ISwitchGearRepository _switchGearRepository;

        public GetAllSwitchGearHandler(ISwitchGearRepository switchGearRepository)
        {
            _switchGearRepository = switchGearRepository;
        }
        public async Task<AllSwitchGearResponse> Handle(GetAllSwitchGearQuery request, CancellationToken cancellationToken)
        {
            return (AllSwitchGearResponse)await _switchGearRepository.GetAllSwitchGears(request.SwitchGearRequest);
        }
    }
}
