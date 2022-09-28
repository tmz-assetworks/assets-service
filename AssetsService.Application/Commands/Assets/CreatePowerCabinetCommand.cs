using AssetsService.Application.Responses.Assets;
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
    public class CreatePowerCabinetCommand : IRequest<PowerCabinetResponse>
    {
        [StringLength(50, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 50 characters.")]
        [Required]
        public string AssetId { get; set; }

        //[StringLength(20, MinimumLength = 0, ErrorMessage = "BreakerRating must be fewer than 20 characters.")]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter valid DcPortQuantityRating")]
        [Required]
        public double BreakerRating { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid DcPortQuantityRating")]
        [Required]
        public int DcPortQuantityRating { get; set; }

        [Required]
        public DateTime InstallationDate { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid MakeMasterId")]
        public long MakeMasterId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ModelId")]
        public long ModelId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PeakCurrent Can only be between 1 to 20 characters")]
        public int PeakCurrent { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "SerialNumber must be fewer than 20 characters.")]
        public string SerialNumber { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "ServiceVolts Can only be between 1 to 20 characters")]
        public long ServiceVolts { get; set; }
        public bool IsActive { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid StatusId")]
        public long StatusId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid LocationId")]
        public long LocationId { get; set; }

        public long WarrantyDuration { get; set; }

        [Required]
        public DateTime WarrantyExpiryDate { get; set; }

        [Required]
        public DateTime WarrantyStartDate { get; set; }
    }
}