using AssetsService.Application.Queries;
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllTimeZonesHandler: IRequestHandler<GetAllTimeZoneQuery, List<TimeZoneResponse>>
    {
        private readonly ITimeZoneRepository _TimeZoneRepo;

        public GetAllTimeZonesHandler(ITimeZoneRepository TimeZoneRepository)
        {
            _TimeZoneRepo = TimeZoneRepository;
        }
        public async Task<List<TimeZoneResponse>> Handle(GetAllTimeZoneQuery request, CancellationToken cancellationToken)
        {
            return await _TimeZoneRepo.GetAllTimeZones();
        }
    }
}
