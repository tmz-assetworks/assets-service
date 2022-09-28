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
    public class GetByIdPadHandlers : IRequestHandler<GetByIdPadQuery, GetPadResponse>
    {
        private readonly IPadRepository _padRepo;
        public GetByIdPadHandlers(IPadRepository padRepository)
        {
            _padRepo = padRepository;
        }
        public async Task<GetPadResponse> Handle(GetByIdPadQuery request, CancellationToken cancellationToken)
        {
            return (GetPadResponse)await _padRepo.GetPadById(Convert.ToInt32(request.Id));
        }
    }
}
