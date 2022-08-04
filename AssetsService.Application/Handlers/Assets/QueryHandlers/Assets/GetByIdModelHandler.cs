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
    public class GetByIdModelHandler : IRequestHandler<GetByIdModelQuery, AssetsService.Core.Entities.Model>
    {
        private readonly IModelRepository _ModelRepo;

        public GetByIdModelHandler(IModelRepository ModelRepository)
        {
            _ModelRepo = ModelRepository;
        }

        public async Task<AssetsService.Core.Entities.Model> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Model)await _ModelRepo.GetAllModelById(request.Id);
        }
    
    }
}
