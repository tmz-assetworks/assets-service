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
    public class GetAllMakeMasterHandler : IRequestHandler<GetAllMakeMasterQuery, List<AssetsService.Core.Entities.MakeMaster>>
    {
        private readonly IMakeMasterRepository _MakeMasterRepo;

        public GetAllMakeMasterHandler(IMakeMasterRepository MakeMasterRepository)
        {
            _MakeMasterRepo = MakeMasterRepository;
        }
        public async Task<List<AssetsService.Core.Entities.MakeMaster>> Handle(GetAllMakeMasterQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.MakeMaster>)await _MakeMasterRepo.GetAllMakeMaster();
        }
    }
}
