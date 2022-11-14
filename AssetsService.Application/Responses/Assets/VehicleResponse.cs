using AssetsService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Responses.Assets
{

    public class vehicleStatus{
        
        public int StatusCode;
        public string StatusMessage;       
    }
    public  class VehicleResponse
    {
        public long Id { get; set; }      
        public string VIN { get; set; }       
        public string LicencePlate { get; set; } 
        public string Department { get; set; }       
        public string DomicileLocation { get; set; }        
        public string VehicleMacAddress { get; set; }        
        public bool IsActive { get; set; }       
        public string CreatedBy { get; set; }       
        public DateTime CreatedOn { get; set; }      
        public string ModifiedBy { get; set; }      
        public DateTime ModifiedOn { get; set; } 
        public long VehicleModelId { get; set; }
        public  VehicleModel VehicleModel { get; set; }       
        public long VehicleMakeId { get; set; }
        public  VehicleMake VehicleMake { get; set; }       
        public long vehicleRFIDid { get; set; }
        public  VehicleRFID VehicleRFID { get; set; }
        public long SubscriptionPlanCustomerId {get;set;}
        public  SubscriptionPlan SubscriptionPlan{get;set;}
    }

}
