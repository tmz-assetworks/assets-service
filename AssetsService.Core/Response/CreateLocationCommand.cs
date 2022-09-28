
namespace AssetsService.Core.Responses.Assets
{
public class CreateLocation 
    {
        // public CreateLocationCommand()
        // {
        //     locationSchedule = new List<LocationScheduleCommand>();
        //     operatorUserMapper = new List<OperatorUserMapperCommand>();
        // }

        public string LocationId { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonNumber { get; set; }

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

        public string FuelProtectType { get; set; }

        public string TimeZone { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string PinCode { get; set; }

        //  public LocationAddressCommand locationAddress { get; set; }

        public long IdStatus { get; set; }
        public string LocationStatusName { get; set; }

        // public LocationStatusCommand locationStatus { get; set; }
        //  public DepartmentCommand Department { get; set; }

        public string DepartmentName { get; set; }
        public string ContactPersonNameDepartment { get; set; }
        public string Address { get; set; }
        public List<string> locationSchedule { get; set; }
        public List<string> operatorUserMapper { get; set; }

    }
    // public class LocationScheduleCommand
    // {
    //     public string Day { get; set; }
    //     public DateTime StartTime { get; set; }

    //     public DateTime EndTime { get; set; }
    //     public string CreatedBy { get; set; }

    //     public string ModifiedBy { get; set; }

    // }

    // public class LocationAddressCommand
    // {
    //     public double Longitude { get; set; }
    //     public double Latitude { get; set; }
    //     public string AddressLine1 { get; set; }
    //     public string AddressLine2 { get; set; }
    //     public string CityName { get; set; }
    //     public string CountryName { get; set; }
    //     public string StateName { get; set; }
    //     public string PinCode { get; set; }


    // }

    // public class LocationStatusCommand
    // {
    //     public long Id { get; set; }
    //     public string LocationStatusName { get; set; }

    // }
    // public class OperatorUserMapperCommand
    // {
    //     public string UserName { get; set; }
    //     public string UserId { get; set; }

    // }

    // public class DepartmentCommand
    // {
    //     public string DepartmentName { get; set; }
    //     public string ContactPersonName { get; set; }
    //     public string Address { get; set; }

    // }

}