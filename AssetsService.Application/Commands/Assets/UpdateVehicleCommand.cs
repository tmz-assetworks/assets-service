using System.ComponentModel.DataAnnotations;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses.Assets;
using MediatR;
namespace AssetsService.Application.Commands.Assets
{
    public class UpdateVehicleCommand : IRequest<CreateVehicleResponse>
    {
        public long Id { get; set; }
        [RegularExpression("^[a-zA-Z0-9]{1,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Vin must be fewer than 50 characters.")]        
        public string? VIN { get; set; }
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
        //  public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModelYear { get; set; }                                            // i.e 2022,2023,2024                     
        [RegularExpression("^[a-zA-Z0-9 -/]{0,40}$", ErrorMessage = "Only Alphabets , Numbers and -/ allowed.")]        
        public string? ModelName { get; set; }
        [RegularExpression("^[a-zA-Z0-9 -/]{0,40}$", ErrorMessage = "Only Alphabets , Numbers and -/ allowed.")]        
        public string? MakeName { get; set; }
        [Required]
        public string UnitNumber { get; set; }
        public string? AssetId { get; set; }
        public List<RfIdCardsAssigned> RfIdCardsAssigneds { get; set; }
    }
    public class RfIdCardsAssigned
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }


}
