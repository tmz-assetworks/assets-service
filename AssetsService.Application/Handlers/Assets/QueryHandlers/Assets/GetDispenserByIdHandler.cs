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

public class GetDispenserByIdHandler : IRequestHandler<GetDispenserByIdQuery, AssetsService.Core.Entities.Charger>
    {
        private readonly IDispenserRepository _dispenserRepository;
        public GetDispenserByIdHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }
        public async Task<AssetsService.Core.Entities.Charger> Handle(GetDispenserByIdQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Charger)await _dispenserRepository.GetByIdAsync(Convert.ToInt16(request.Id));
        }
    }
}
