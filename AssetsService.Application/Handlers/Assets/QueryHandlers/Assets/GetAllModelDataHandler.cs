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
          public class GetAllModelDataHandler : IRequestHandler<GetAllModelDataQuery, List<AssetsService.Core.Entities.Model>>
          {
          private readonly IModelRepository _ModelRepo;

          public GetAllModelDataHandler(IModelRepository modelRepository)
          {
            _ModelRepo = modelRepository;
          }
          public async Task<List<AssetsService.Core.Entities.Model>> Handle(GetAllModelDataQuery request, CancellationToken cancellationToken)
          {
             return (List<AssetsService.Core.Entities.Model>)await _ModelRepo.GetAllModelData(request.modelDataRequest);
          }
        }
}
