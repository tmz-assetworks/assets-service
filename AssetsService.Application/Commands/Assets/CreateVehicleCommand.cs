using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateVehicleCommand : IRequest<AssetsService.Core.Responses.Assets.CreateVehicleResponse>
    {

        public long Id { get; set; }
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Vin must be fewer than 50 characters.")]
        [Required]
        public string VIN { get; set; }
        [RegularExpression("^[a-zA-Z0-9]{0,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "LicencePlate must be fewer than 50 characters.")]

        public string LicencePlate { get; set; }
        [StringLength(255,MinimumLength = 0 ,ErrorMessage = "Department must be fewer than 255 characters." )]
        public string Department { get; set; }
        [RegularExpression("^[a-zA-Z0-9]{0,25}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(25, MinimumLength = 0, ErrorMessage = "DomicileLocation must be fewer than 50 characters.")]
        public string DomicileLocation { get; set; }
        
        [StringLength(25, MinimumLength = 0, ErrorMessage = "VehicleMacAddress must be fewer than 25 characters.")]
        public string VehicleMacAddress { get; set; }
        public string CreatedBy { get; set; }
        
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid VehicleMOdelYearIdId")]

        [Required]
        public long VehicleModelYearid { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid MakeModelId")]
        [Required]
        public long VehicleModelId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid VehicleMakeId")]
        [Required]
        public long VehicleMakeId { get; set; }
        [Required]
        public List<RfIdCardsAssigneds>  RfIdCardsAssigneds { get; set; }
    }
    public class RfIdCardsAssigneds
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
