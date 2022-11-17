using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateLocationCommand : IRequest<Location>
    {
        // public CreateLocationCommand()
        // {
        //     locationSchedule = new List<LocationScheduleCommand>();
        //     operatorUserMapper = new List<OperatorUserMapperCommand>();
        // }
        //   public long Id { get; set; }
        public string UserId { get; set; }


        [StringLength(6, MinimumLength = 0, ErrorMessage = "LocationId must be fewer than 6 characters.")]
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

        [StringLength(255, MinimumLength = 0, ErrorMessage = "Description must be fewer than 255 characters.")]
        public string Description { get; set; }

        [StringLength(40, MinimumLength = 0, ErrorMessage = "LocationName must be fewer than 49 characters.")]
        [Required]
        public string LocationName { get; set; }

        public string Email { get; set; }

        //[Range(1, double.MaxValue, ErrorMessage = "Longitude Can only be between 1 to 15 character")]
        public double Longitude { get; set; }

        //[Range(1, double.MaxValue, ErrorMessage = "Latitude Can only be between 1 to 15 character")]
        public double Latitude { get; set; }

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

        //  public LocationAddressCommand locationAddress { get; set; }
        // public string LocationStatusName { get; set; }
        [Required]
        public long LocationStatusId { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "DepartmentName must be fewer than 200 characters.")]
        public string DepartmentName { get; set; }
      
        [StringLength(15, MinimumLength = 0, ErrorMessage = "TotalCapacity must be fewer than 15 characters.")]
        public string TotalCapacity { get; set; }
        public List<LocationScheduleCommand> locationScheduleCommand { get; set; }
        // public List<OperatorUserMapperCommand> operatorUserMapperCommand { get; set; }

    }
    public class LocationScheduleCommand
    {
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsOpenAlldays { get; set; }

    }
    public class OperatorUserMapperCommand
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }


    }

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
