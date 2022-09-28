using System.ComponentModel.DataAnnotations;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses;
using AssetsService.Core.Responses.Assets;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateCableCommand : IRequest<CreateCableResponse>
    {
        [StringLength(50, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 50 characters.")]
        [Required]
        public string AssetId { get; set; }

        [Required]
        public string CreatedBy { get; set; }


        [Required]
        public long MakeMasterId { get; set; }


        [Required]
        public long ModelId { get; set; }

        [Required]
        public long LocationId { get; set; }

        [Required]
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
    }
}
