using AssetsService.Application.Queries;
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{
    public class GetTotalLocationAndChargerHandler : IRequestHandler<GetTotalLocationAndChargerQuery, TotalLocationAndChargerResponse>
    {
        private readonly ITotalLocationAndChargerRepository _totalLocationAndChargerRepository;

        public GetTotalLocationAndChargerHandler(ITotalLocationAndChargerRepository totalLocationAndChargerRepository)
        {
            _totalLocationAndChargerRepository = totalLocationAndChargerRepository;
        }

        async Task<TotalLocationAndChargerResponse> IRequestHandler<GetTotalLocationAndChargerQuery, TotalLocationAndChargerResponse>.Handle(GetTotalLocationAndChargerQuery request, CancellationToken cancellationToken)
        {
            return (TotalLocationAndChargerResponse)await _totalLocationAndChargerRepository.GetTotalLocationAndCharger();
        }
    }
}
