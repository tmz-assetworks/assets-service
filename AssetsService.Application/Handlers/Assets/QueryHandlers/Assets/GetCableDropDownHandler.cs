using AssetsService.Application.Queries;
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
    public class GetCableDropDownHandler : IRequestHandler<GetCableDropDownQuery, List<CableListDropDown>>
    {
        private readonly ICableRepository _cableRepo;

        public GetCableDropDownHandler(ICableRepository cableRepo)
        {
            _cableRepo = cableRepo;
        }
        public async Task<List<CableListDropDown>> Handle(GetCableDropDownQuery request, CancellationToken cancellationToken)
        {
            return (List<CableListDropDown>)await _cableRepo.GetAllCableDropDown(request.userId, request.dispenserId);
        }
    }
}
