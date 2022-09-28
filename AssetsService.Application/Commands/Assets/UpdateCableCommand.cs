using System.ComponentModel.DataAnnotations;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses;
using AssetsService.Core.Responses.Assets;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{

    public class UpdateCableCommand : IRequest<Cable>
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Id")]
        public long Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 50 characters.")]
        public string AssetId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid MakeMasterId")]
        public long MakeMasterId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ModelId")]
        public long ModelId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid LocationId")]
        public long LocationId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid StatusId")]
        public long StatusId { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "SerialNumber must be fewer than 20 characters.")]
        [Required]
        public string SerialNumber { get; set; }
        public bool IsActive { get; set; }
        public long WarrantyDuration { get; set; }

        [Required]
        public DateTime WarrantyExpiryDate { get; set; }

        [Required]
        public DateTime WarrantyStartDate { get; set; }

        [Required]
        public string ModifiedBy { get; set; }
    }
}
