using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
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
    public class GetAllPadDataHandler : IRequestHandler<GetAllPadDataQuery, List<ListDropDown>>
    {
        private readonly IPadRepository _padRepo;
        public GetAllPadDataHandler(IPadRepository padRepository)
        {
            _padRepo = padRepository;
        }
        public async Task<List<ListDropDown>> Handle(GetAllPadDataQuery request, CancellationToken cancellationToken)
        {
            return (List<ListDropDown>) await _padRepo.GetAllPadData(request._dispenserId.Value);
        }
    }
}
