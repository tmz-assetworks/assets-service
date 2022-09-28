using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetCombineAssetQuery : IRequest<CombineAssetResponse>
    {
        public CombineAssetRequest _combineAssetRequest = null;
        public GetCombineAssetQuery(CombineAssetRequest combineAssetRequest)
        {
            this._combineAssetRequest = combineAssetRequest;
        }
    }
}
