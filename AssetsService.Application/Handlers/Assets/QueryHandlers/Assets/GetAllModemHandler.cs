using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{
    public class GetAllModemHandler : IRequestHandler<GetAllModemQuery, PagedList<ModemDTO>>
    {
        private readonly IModemRepository _modemRepo;

        public GetAllModemHandler(IModemRepository modemRepository)
        {
            _modemRepo = modemRepository;
        }
        public async Task<PagedList<ModemDTO>> Handle(GetAllModemQuery request, CancellationToken cancellationToken)
        {
            return await _modemRepo.GetAllModem(request._modemRequest);
          
        }
    }
}
