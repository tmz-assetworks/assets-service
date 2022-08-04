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

public class GetDispenserByIdHandler : IRequestHandler<GetDispenserByIdQuery, AssetsService.Core.Entities.Dispenser>
    {
        private readonly IDispenserRepository _dispenserRepository;
        public GetDispenserByIdHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }
        public async Task<AssetsService.Core.Entities.Dispenser> Handle(GetDispenserByIdQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Dispenser)await _dispenserRepository.GetByIdAsync(Convert.ToInt32(request.Id));
        }
    }
}
