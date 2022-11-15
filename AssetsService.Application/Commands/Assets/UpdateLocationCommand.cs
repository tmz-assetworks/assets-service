using System.ComponentModel.DataAnnotations;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{

    public class UpdateLocationCommand : IRequest<Location>
    {

        // public UpdateLocationCommand()
        // {
        //     locationSchedule = new List<LocationSchedule>();
        //     operatorUserMapper = new List<OperatorUserMapper>();
        // }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Id")]
        public long Id { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid LocationStatusId")]
        public long LocationStatusId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "DepartmentName must be fewer than 200 characters.")]
        public string DepartmentName { get; set; }                                          // DepartmentId to DepartmentName, Date:09/11/2022

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid LocationAddressId")]
        public long LocationAddressId { get; set; }

        public string UserId { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "LocationId must be fewer than 20 characters.")]
        [Required]
        public string LocationId { get; set; }

        [StringLength(25, MinimumLength = 0, ErrorMessage = "ContactPersonName must be fewer than 25 characters.")]
        [Required]
        public string ContactPersonName { get; set; }

        [StringLength(15, MinimumLength = 0, ErrorMessage = "ContactPersonNumber must be fewer than 15 characters.")]
        [Required]
        public string ContactPersonNumber { get; set; }

        [StringLength(200, MinimumLength = 0, ErrorMessage = "UtilityService must be fewer than 200 characters.")]
        public string UtilityService { get; set; }

        [StringLength(15, MinimumLength = 0, ErrorMessage = "TotalCapacity must be fewer than 15 characters.")]
        public string TotalCapacity { get; set; }
        public string Email { get; set; }

        //[Range(1, double.MaxValue, ErrorMessage = "Longitude Can only be between 1 to 15 character")]
        public double Longitude { get; set; }

        //[Range(1, double.MaxValue, ErrorMessage = "Longitude Can only be between 1 to 15 character")]
        public double Latitude { get; set; }

        [StringLength(255, MinimumLength = 0, ErrorMessage = "Description must be fewer than 255 characters.")]
        public string Description { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "LocationName must be fewer than 20 characters.")]
        [Required]
        public string LocationName { get; set; }

        [StringLength(255, MinimumLength = 0, ErrorMessage = "AddressLine1 must be fewer than 255 characters.")]
        [Required]
        public string AddressLine1 { get; set; }

        [StringLength(255, MinimumLength = 0, ErrorMessage = "AddressLine2 must be fewer than 255 characters.")]
        public string AddressLine2 { get; set; }

        //[Required]
        //public long CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public long CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public long StateId { get; set; }

        [Required]
        public string StateName { get; set; }

        [StringLength(9, MinimumLength = 0, ErrorMessage = "PinCode must be fewer than 9 characters.")]
        [Required]
        public string PinCode { get; set; }
        public List<LocationScheduleCommands> locationScheduleCommand { get; set; }

        public class LocationScheduleCommands
        {
            public long Id { get; set; }
            public string Day { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public bool IsOpenAlldays { get; set; }

        }

        // public string FuelProtectType { get; set; }

        // public string LocationName { get; set; }

        // public long LocationNumber { get; set; }

        // public string TimeZone { get; set; }

        // public LocationAddress locationAddress { get; set; }

        // public LocationStatus locationStatus { get; set; }

        // public Department department { get; set; }
        // public List<LocationSchedule> locationSchedule { get; set; }
        // public List<OperatorUserMapper> operatorUserMapper { get; set; }

    }
}
