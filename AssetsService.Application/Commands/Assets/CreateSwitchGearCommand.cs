using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateSwitchGearCommand : IRequest<SwitchGearResponse>
    {
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
        public string CreatedBy { get; set; }
    }
}
