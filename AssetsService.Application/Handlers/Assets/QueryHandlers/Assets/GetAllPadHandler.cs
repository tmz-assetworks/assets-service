using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllPadHandler : IRequestHandler<GetAllPadQuery, List<AssetsService.Core.Entities.Pad>>
    {
        private readonly IPadRepository _padRepo;

        public GetAllPadHandler(IPadRepository padRepository)
        {
            _padRepo = padRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Pad>> Handle(GetAllPadQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.Pad>)await _padRepo.GetAllPad();
        }
    }
}
