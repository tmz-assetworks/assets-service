using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetCombineAssetHandler : IRequestHandler<GetCombineAssetQuery, CombineAssetResponse>
    {
        private readonly ICombineAssetRepository _CombineAssetRepo;

        public GetCombineAssetHandler(ICombineAssetRepository CombineAssetRepository)
        {
            _CombineAssetRepo = CombineAssetRepository;
        }
        public async Task<CombineAssetResponse> Handle(GetCombineAssetQuery request, CancellationToken cancellationToken)
        {
            return await _CombineAssetRepo.GetCombineAssetList(request._combineAssetRequest);

        }
    }
}
