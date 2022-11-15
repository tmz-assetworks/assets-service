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
    public class GetSwitchGearDDLHandler : IRequestHandler<GetSwitchGearDDLQuery, List<ListSwitchGear>>
    {
        private readonly ISwitchGearRepository _switchGearRepository;

        public GetSwitchGearDDLHandler(ISwitchGearRepository switchGearRepository)
        {
            _switchGearRepository = switchGearRepository;
        }
        public async Task<List<ListSwitchGear>> Handle(GetSwitchGearDDLQuery request, CancellationToken cancellationToken)
        {
            return (List<ListSwitchGear>)await _switchGearRepository.GetSwitchGearDLList(request.userId, request._dispenserId);
        }
    }
}
