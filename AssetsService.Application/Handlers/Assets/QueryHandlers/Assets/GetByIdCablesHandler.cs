using AssetsService.Application.Queries;
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdCablesHandler : IRequestHandler<GetByIdCablesQuery, CableData>
    {
        private readonly ICableRepository _cableRepo;

        public GetByIdCablesHandler(ICableRepository cableRepository)
        {
            _cableRepo = cableRepository;
        }
     
        public async Task<CableData> Handle(GetByIdCablesQuery request, CancellationToken cancellationToken)
        {
            return (CableData)await _cableRepo.GetByIdCable(request.Id);
        }
    }

    

}
