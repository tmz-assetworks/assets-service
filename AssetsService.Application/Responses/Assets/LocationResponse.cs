using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;

namespace AssetsService.Application.Responses.Assets
{
    public class LocationQueryResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public Location data { get; set; }
    }

    public class LocationResponse
    {

        public LocationResponse()
        {
            locationSchedule = new List<LocationSchedule>();
            operatorUserMapper = new List<OperatorUserMapper>();
        }
        public long Id { get; set; }

        public long LocationAddressId { get; set; }

        public long LocationStatusId { get; set; }

        public long DepartmentId { get; set; }

        ///  public long LocationId { get; set; }

        public string ContactPersonName { get; set; }

        public string GlobalTax { get; set; }

        public string TotalCapacity { get; set; }

        public string UtilityService { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }



        public string LocationName { get; set; }

        public long LocationNumber { get; set; }



        public string TimeZone { get; set; }

        public LocationAddress locationAddress { get; set; }

        public LocationStatus locationStatus { get; set; }

        public Department department { get; set; }

        public string FuelProtectType { get; set; }




        public List<LocationSchedule> locationSchedule { get; set; }
        public List<OperatorUserMapper> operatorUserMapper { get; set; }

    }

    public class AllLocationStatusQueryResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<LocationStatusData> data { get; set; }
    }

    public class LocationStatusData
    {
        public long Id { get; set; }
        public string LocationName { get; set; }

        public string LocationStatus { get; set; }
    }


    // public class AllLocationQueryResponse
    // {
    //     public int StatusCode { get; set; }
    //     public string StatusMessage { get; set; }

    //     public List<LocationData> data { get; set; }
    // }

    // public class LocationData
    // {
    //     public long Id { get; set; }
    //     public string LocationName { get; set; }
    // }


   
}
