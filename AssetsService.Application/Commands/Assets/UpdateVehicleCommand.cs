using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class UpdateVehicleCommand : IRequest<VehicleResponse>
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

    

       
        public long VehicleModelYearid { get; set; }
      
        public long VehicleModelId { get; set; }
      

       
        public long VehicleMakeId { get; set; }

        public long CustomerId {get; set;}
        

        
        public long vehicleRFIDid { get; set; }

     ///   public long VehicleSubscriptionPlanId {get; set;}
       
    }
}
