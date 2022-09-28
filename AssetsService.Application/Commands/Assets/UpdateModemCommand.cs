using System.ComponentModel.DataAnnotations;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{

    public class UpdateModemCommand : IRequest<Modem>
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string ModifiedBy { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 50 characters.")]
        [Required]
        public string AssetId { get; set; }

        [StringLength(50, MinimumLength = 0, ErrorMessage = "carrier must be fewer than 50 characters.")]
        [Required]
        public string Carrier { get; set; }
        [Required]
        public DateTime InstallationDate { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid MakeMasterId")]
        public long MakeMasterId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ModelId")]
        public long ModelId { get; set; }
        [Required]
        public string SimNumber { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid StatusId")]
        public virtual long StatusId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ModemTypeId")]
        public long ModemTypeId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid LocationId")]
        public long LocationId { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "ImeiNumber must be fewer than 50 characters.")]
        [Required]
        public string ImeiNumber { get; set; }
        //[RegularExpression(@"^[\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}}$", ErrorMessage = "Only Number  and dot are allowed.")]
        public string IpAddress { get; set; }
        public long WarrantyDuration { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime WarrantyExpiryDate { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime WarrantyStartDate { get; set; }
        public bool IsActive { get; set; }

    }
}