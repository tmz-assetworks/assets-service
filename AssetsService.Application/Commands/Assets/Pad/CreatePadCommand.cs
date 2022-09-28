using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public partial class CreatePadCommand : IRequest<PadResponse>
    {
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "SerialNumber must be fewer than 20 characters.")]
        public string SerialNumber { get; set; }

        [StringLength(50, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 50 characters.")]
        [Required]
        public string AssetId { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime InstallationDate { get; set; }

        public bool IsActive { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "PadName must be fewer than 20 characters.")]
        [Required]
        public string PadName { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid StatusId")]
        public long StatusId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid LocationId")]
        public long LocationId { get; set; }
    }
}
