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
    public class GetAllModelHandler : IRequestHandler<GetAllModelQuery, List<AssetsService.Core.Entities.Model>>
    {
        private readonly IModelRepository _ModelRepo;

        public GetAllModelHandler(IModelRepository ModelRepository)
        {
            _ModelRepo = ModelRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Model>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.Model>)await _ModelRepo.GetAllModel();
        }
    }
}
