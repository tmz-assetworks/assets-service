using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Core.Response
{

    public class LocationListResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public StatusList statusList { get; set; }
        public PagedList<LocationsData> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
    }

    public class StatusList
    {
        public List<StatusData> StatusData { get; set; }

    }

    public class StatusData
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Color { get; set; }
    }

    public class Locationalist
    {
        public string TotalLocation { get; set; }
        public string Live { get; set; }
        public string UnderMaintenance { get; set; }
        public string Upcomming { get; set; }
        public PagedList<LocationsData> data { get; set; }
    }

    public class LocationListRequst : QueryStringParameters
    {
        public string? operatorid { get; set; }
    }

    public class LocationsData
    {
        public LocationsData()
        {
            locationSchedule = new List<LocationSchedule>();
        }
        public long Id { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LocationStatusName { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int NumberOfCharger { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string PinCode { get; set; }
        public string TotalCapacity { get; set; }
        public string UtilityService { get; set; }
        public bool IsActive { get; set; }
        public List<LocationSchedule> locationSchedule { get; set; }
    }

    public class CreateUpdateLocationResponse
    {
        public CreateUpdateLocationResponse()
        {
            locationSchedule = new List<LocationSchedule>();
            operatorUserMapper = new List<OperatorUserMapper>();
        }
        public long Id { get; set; }
        public long LocationAddressId { get; set; }
        public long LocationStatusId { get; set; }
        public long DepartmentId { get; set; }
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
        public string TimeZone { get; set; }
        public LocationAddress locationAddress { get; set; }
        public LocationStatus locationStatus { get; set; }
        public Department department { get; set; }
        public string FuelProtectType { get; set; }
        public List<LocationSchedule> locationSchedule { get; set; }
        public List<OperatorUserMapper> operatorUserMapper { get; set; }

    }







}