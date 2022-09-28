
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Application.Handlers.Assets.QueryHandlers;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdModemHandler : IRequestHandler<GetByIdModemsQuery, AssetsService.Core.Entities.ModemByIDResponse>
    {
        private readonly IModemRepository _modemRepo;

        public GetByIdModemHandler(IModemRepository modemRepository)
        {
            _modemRepo = modemRepository;
        }

        public async Task<AssetsService.Core.Entities.ModemByIDResponse> Handle(GetByIdModemsQuery request, CancellationToken cancellationToken)
        {
            return await _modemRepo.GetByIdModem(request.Id);
        }        
    }   

}
