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
    public class GetAllCableHandler : IRequestHandler<GetAllCableQuery, List<AssetsService.Core.Entities.Cable>>
    {
        private readonly ICableRepository _cableRepo;

        public GetAllCableHandler(ICableRepository cableRepository)
        {
            _cableRepo = cableRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Cable>> Handle(GetAllCableQuery request, CancellationToken cancellationToken)
        {

          return (List<AssetsService.Core.Entities.Cable>)await _cableRepo.GetAllAsync();

        }
    }
}
