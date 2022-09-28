using AssetsService.Core.PagingHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Entities
{
    public class statusData
    {

        public string key { get; set; }
        public int value { get; set; }

    }

    public class CombineAsset
    {

        public long Id { get; set; }
        public string Type { get; set; }

        public string AssetId { get; set; }
        public string LocationName { get; set; }
        public string locationStatus { get; set; }
        public string SerialNumber { get; set; }
        public bool IsActive { get; set; }

        public DateTime ModifiedAt { get; set; }
        
    }
    
    public class CombineAssetResponse
    {
        public CombineAssetResponse()
        {
            //statusData = new List<statusData>();
            data = new List<CombineAsset>();
           
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        
        public List<statusData> statusData { get; set; }
        public List<CombineAsset> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
    }
    public class CombineAssetRequest : QueryStringParameters
    {

    }
}

