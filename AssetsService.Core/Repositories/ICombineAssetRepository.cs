using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface ICombineAssetRepository : IRepository<CombineAsset>
    {
        Task<CombineAssetResponse> GetCombineAssetList(CombineAssetRequest CombineAssetRequest);
    }
}
