using AssetsService.Core.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetsService.Application.Commands.Assets
{
    public class UpdateSwitchGearCommand : IRequest<SwitchGearResponse>
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Id")]
        public long Id { get; set; }

        [StringLength(50, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 50 characters.")]
        [Required]
        public string AssetId { get; set; }
        [Required]
        public string SerialNumber { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid StatusId")]
        [Required]
        public long StatusId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid LocationId")]
        [Required]
        public long LocationId { get; set; }
        [StringLength(20, MinimumLength = 0, ErrorMessage = "SwitchGearName must be fewer than 20 characters.")]
        [Required]
        public string SwitchGearName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
    }
}
