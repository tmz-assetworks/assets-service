using AssetsService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Responses
{
    // public class CableQueryResponse
    // {
    //     public int StatusCode { get; set; }
    //     public string StatusMessage { get; set; }
    //     public List<AssetsService.Core.Entities.Cable> data { get; set; }
    // }

    // public class CableByIdResponse
    // {
    //     public int StatusCode { get; set; }
    //     public string StatusMessage { get; set; }
    //     public AssetsService.Core.Entities.Cable data { get; set; }
    // }

    public class CableResponse
    {
       
        public long Id { get; set; }
      
      
        public string AssetId { get; set; }

      
        public string CreatedBy { get; set; }

      
        public DateTime CreatedOn { get; set; }

       
        public DateTime InstallationDate { get; set; }

       
        public long MakeMasterId { get; set; }
        public  MakeMaster MakeMaster { get; set; }

      
      
        public long ModelId { get; set; }

      
       
        public string ModifiedBy { get; set; }

     
      
        public DateTime ModifiedOn { get; set; }

   
        public long NetworkId { get; set; }

       
        public string NetworkName { get; set; }

        
        public string SerialNumber { get; set; }

        
        public long StatusId { get; set; }
        public  Status Status { get; set; }

      
        public long SubNetworkId { get; set; }

       
        public string SubNetworkName { get; set; }

     
        public long WarrantyDuration { get; set; }

       
        public DateTime WarrantyExpiryDate { get; set; }

        
        public DateTime WarrantyStartDate { get; set; }

      
        public bool IsActive { get; set; }
    }
}
