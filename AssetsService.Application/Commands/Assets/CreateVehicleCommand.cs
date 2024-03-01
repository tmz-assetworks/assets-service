using System.ComponentModel.DataAnnotations;
using AssetsService.Core.Responses.Assets;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateVehicleCommand : IRequest<AssetsService.Core.Responses.Assets.CreateVehicleResponse>
    {

        //public long Id { get; set; }              // 12/Oct/2022
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Vin must be fewer than 50 characters.")]
        [Required]
        public string VIN { get; set; }
        [RegularExpression("^[a-zA-Z0-9-_ ]{0,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "LicencePlate must be fewer than 50 characters.")]

        public string LicencePlate { get; set; }
        [StringLength(255,MinimumLength = 0 ,ErrorMessage = "Department must be fewer than 255 characters." )]
        public string Department { get; set; }
        [RegularExpression("^[a-zA-Z0-9 ]{0,25}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "DomicileLocation must be fewer than 50 characters.")]
        public string DomicileLocation { get; set; }
        
        [StringLength(25, MinimumLength = 0, ErrorMessage = "VehicleMacAddress must be fewer than 25 characters.")]
        public string VehicleMacAddress { get; set; }
        public string CreatedBy { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ModelYear")]
        [Required]
        public long ModelYear { get; set; }
        [RegularExpression("^[a-zA-Z0-9 -/]{0,40}$", ErrorMessage = "Only Alphabets , Numbers and -/ allowed.")]
        [Required]
        public string ModelName { get; set; }
        [RegularExpression("^[a-zA-Z0-9 -/]{0,40}$", ErrorMessage = "Only Alphabets , Numbers and -/ allowed.")]
        [Required]
        public string MakeName { get; set; }
        [Required]
        public List<RfIdCardsAssigneds>  RfIdCardsAssigneds { get; set; }
        [Required]
        public string UnitNumber { get; set; }
        
    }
    public class RfIdCardsAssigneds
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
    //added by Abhishek External API Entity 17/2/2023--------------------------------------------------------------------//
    public class CreateNewVehicleCommandExternal : IRequest<CreateVehicleResponseExternal>
    {

       
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Vin must be fewer than 50 characters.")]
        [Required]
        public string VIN { get; set; }
        [RegularExpression("^[a-zA-Z0-9-_ ]{0,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "LicencePlate must be fewer than 50 characters.")]

        public string LicencePlate { get; set; }
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Department must be fewer than 255 characters.")]
        public string Department { get; set; }
        [RegularExpression("^[a-zA-Z0-9 ]{0,25}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "DomicileLocation must be fewer than 50 characters.")]
        public string DomicileLocation { get; set; }

        [StringLength(25, MinimumLength = 0, ErrorMessage = "VehicleMacAddress must be fewer than 25 characters.")]
        public string VehicleMacAddress { get; set; }
        public string CreatedBy { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ModelYear")]
        [Required]
        public long ModelYear { get; set; }
        [RegularExpression("^[a-zA-Z0-9 ]{0,40}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [Required]
        public string ModelName { get; set; }
        [RegularExpression("^[a-zA-Z0-9 ]{0,40}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [Required]
        public string MakeName { get; set; }

        //[Required]
        public List<RfIdCardsAssignedsExternal> RfIdCardsAssigneds { get; set; }

        public string UnitNumber { get; set; } = "";
    }
    public class RfIdCardsAssignedsExternal
    {
        //public long Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
