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
    public class ValidateChargerIdHandler : IRequestHandler<ValidateChargerIdQuery, ChargerResponse>
    {
        private readonly IDispenserRepository _DispenserRepo;
         public ValidateChargerIdHandler(IDispenserRepository DispenserRepository)
        {
            _DispenserRepo = DispenserRepository;
        }
        public async Task<ChargerResponse> Handle(ValidateChargerIdQuery request, CancellationToken cancellationToken)
        {
            return (ChargerResponse)await _DispenserRepo.ValidateChargerId(request.ChargeBoxId);
        }
    }
}