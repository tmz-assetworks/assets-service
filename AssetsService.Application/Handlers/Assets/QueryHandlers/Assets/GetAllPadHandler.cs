using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllPadHandler : IRequestHandler<GetAllPadQuery, List<GetPadResponse>>
    {
        private readonly IPadRepository _padRepo;

        public GetAllPadHandler(IPadRepository padRepository)
        {
            _padRepo = padRepository;
        }
        public async Task<List<GetPadResponse>> Handle(GetAllPadQuery request, CancellationToken cancellationToken)
        {
            return (List<GetPadResponse>)await _padRepo.GetAllPad();
        }
    }
}
