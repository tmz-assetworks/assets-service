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
    public class GetByIdPadHandlers : IRequestHandler<GetByIdPadQuery, AssetsService.Core.Entities.Pad>
    {
        private readonly IPadRepository _padRepo;
        public GetByIdPadHandlers(IPadRepository padRepository)
        {
            _padRepo = padRepository;
        }
        public async Task<AssetsService.Core.Entities.Pad> Handle(GetByIdPadQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Pad)await _padRepo.GetPadById(Convert.ToInt32(request.Id));
        }
    }
}
