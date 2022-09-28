using AssetsService.Application.Queries;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetPowerCabinetDataHandler : IRequestHandler<GetPowerCabinetDataQuery, List<GetPowerCabinetResponse>>
    {
        private readonly IPowerCabinetRepository _powerCabinetRepo;

        public GetPowerCabinetDataHandler(IPowerCabinetRepository powerCabinetRepo)
        {
            _powerCabinetRepo = powerCabinetRepo;
        }
        public async Task<List<GetPowerCabinetResponse>> Handle(GetPowerCabinetDataQuery request, CancellationToken cancellationToken)
        {
            return (List<GetPowerCabinetResponse>)await _powerCabinetRepo.GetPowerCabinetData();
        }
    }
}
