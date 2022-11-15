using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.Response;

namespace AssetsService.Application.Responses.Assets
{
    public class PowerCabinetResponse
    {

        public long Id { get; set; }

        public string AssetId { get; set; }

        public double BreakerRating { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int DcPortQuantityRating { get; set; }

        public DateTime InstallationDate { get; set; }

        public long MakeMasterId { get; set; }

        public long ModelId { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int PeakCurrent { get; set; }

        public string SerialNumber { get; set; }

        public long ServiceVolts { get; set; }

        public long StatusId { get; set; }

        public bool IsActive { get; set; }
        public long WarrantyDuration { get; set; }

        public DateTime WarrantyExpiryDate { get; set; }

        public DateTime WarrantyStartDate { get; set; }
    }
    public class AllPowerCabinetData
    {

       
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<PowerCabinetResults> Data { get; set; }
    }
    public class PowerCabinetResults
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public bool IsActive { get; set; }
    }
    public class AllPowerCabinet{
        
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<PowerCabinet> data{get;set;}
    }

    public class PowerCabinetById{
        
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public GetPowerCabinetResponse data {get;set;}
    }
}
