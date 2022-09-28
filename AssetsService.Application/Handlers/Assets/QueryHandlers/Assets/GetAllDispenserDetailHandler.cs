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
    public class GetAllDispenserDetailHandler : IRequestHandler<GetAllDispenserDetailQuery, AllDispenserResponse>
    {
        private readonly IDispenserRepository _DispenserRepo;

        public GetAllDispenserDetailHandler(IDispenserRepository DispenserRepository)
        {
            _DispenserRepo = DispenserRepository;
        }
        public async Task<AllDispenserResponse> Handle(GetAllDispenserDetailQuery request, CancellationToken cancellationToken)
        {
            return (AllDispenserResponse)await _DispenserRepo.GetAllDispensers(request.DispensersRequest);
        }
    }
}
