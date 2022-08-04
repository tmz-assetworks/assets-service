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
    public class GetAllModemHandler : IRequestHandler<GetAllModemQuery, List<AssetsService.Core.Entities.Modem>>
    {
        private readonly IModemRepository _modemRepo;

        public GetAllModemHandler(IModemRepository modemRepository)
        {
            _modemRepo = modemRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Modem>> Handle(GetAllModemQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.Modem>)await _modemRepo.GetAllModem();
        }
    }
}
