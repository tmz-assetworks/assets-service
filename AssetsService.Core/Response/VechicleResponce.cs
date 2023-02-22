using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;

namespace AssetsService.Core.Responses.Assets
{
    public class AllVehicle
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Active { get; set; }
        public string Inactive { get; set; }
        public PagedList<Vehicle> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }

    }



    public class VehicleListResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<StatusData> statusData { get; set; }
        public PagedList<VehicleDTO> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }

    }
    public class VehicleListData
    {
        
        public int Active { get; set; }
        public int InActive { get; set; }
       
        public PagedList<VehicleDTO> data { get; set; }       

    }

  
    public class StatusVehicleresponcse
    {
        public string Active { get; set; }
        public string Inactive { get; set; }
        public PagedList<Vehicle> data { get; set; }

    }
    public class VehicleDetailsResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<VehicleDTO> data { get; set; }
    }

    public class VehicleInfo
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public Vehicle data { get; set; }
    }
    public class GetAllVehicleRequest : QueryStringParameters
    {
        public string? opratorid { get; set; }
    }
    public class CreateVehicle
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public CreateVehicleResponse data { get; set; }
    }
    public class CreateVehicleResponse

    {
        public long id { get; set; }
        public string VIN { get; set; }
        public long ModelYear { get; set; }
        public string MakeName { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModelName { get; set; }
        public string LicencePlate { get; set; }
        public string Department { get; set; }
        public string DomicileLocation { get; set; }
        public string VehicleMacAddress { get; set; }
        public string? UnitNumber { get; set; }
        public List <Rfids> rfids{ get; set; }
    }

    public class VehicleDTO
    {
        public long Id { get; set; }
        public string VIN { get; set; }
        public string LicencePlate { get; set; }
        public string Department { get; set; }
        public string DomicileLocation { get; set; }
        public string VehicleMacAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long ModelYear { get; set; }       
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public string vehicleRFIDName { get; set; }
        public string? UnitNumber { get; set; }
        public List <VehicleRFIDId> vehicleRFIDIds  { get; set; }
         
    }
    public class VehicleRFIDId
    {
        public long Id { get;set;}
        public string Name {get;set;}
        public bool IsActive { get;set;}

    }
    public class Rfids{
        public long Id{get;set;}
        public string Name{get;set;}
        public bool IsActive { get;set;}
    }

    public class ApplicableSubscriptionPlan
    {
        public string SubscriptionPlanName { get; set; }
        public string Type { get; set; }
        public string SubscriptionsValue { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string RfIdNumbers { get; set; }

    }
    //added by Abhishek External API Entity 17/2/2023--------------------------------------------------------------------//
    public class CreateVehicleResponseExternal

    {
        public long id { get; set; }
        public string VIN { get; set; }
        public long ModelYear { get; set; }
        public string MakeName { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModelName { get; set; }
        public string LicencePlate { get; set; }
        public string Department { get; set; }
        public string DomicileLocation { get; set; }
        public string VehicleMacAddress { get; set; }
        public string? UnitNumber { get; set; }
        public List<Rfids> rfids { get; set; }
    }
}
