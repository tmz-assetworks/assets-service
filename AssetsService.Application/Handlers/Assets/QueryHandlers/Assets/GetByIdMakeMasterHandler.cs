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
    public class GetByIdMakeMasterHandler : IRequestHandler<GetByIdMakeMastersQuery, AssetsService.Core.Entities.MakeMaster>
    {
        private readonly IMakeMasterRepository _MakeMasterRepo;

        public GetByIdMakeMasterHandler(IMakeMasterRepository MakeMasterRepository)
        {
            _MakeMasterRepo = MakeMasterRepository;
        }

        public async Task<AssetsService.Core.Entities.MakeMaster> Handle(GetByIdMakeMastersQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.MakeMaster)await _MakeMasterRepo.GetAllMakeMasterById(request.Id);
        }
    }
}
