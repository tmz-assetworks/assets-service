using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Responses.Assets
{
    public class AssetResponse
    {
        public long Id { get; set; }
    }
        public class PadResponse
    {
        public long Id { get; set; }

        public string AssetId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime InstallationDate { get; set; }

        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string PadName { get; set; }
        public long StatusId { get; set; }

        public long LocationId { get; set; }

    }

    public class AllPad{
        
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<GetPadResponse> data{get;set;}
    }
    public class AllPadData
    {

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<PadResults> data { get; set; }
    }
    public class PadById{
        
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public GetPadResponse data {get;set;}
    }


}
