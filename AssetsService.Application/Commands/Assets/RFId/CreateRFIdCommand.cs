using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets.RFId
{
    public class CreateRFIdCommand : IRequest<RFIDReader>
    {
        [Required(ErrorMessage = "Please provide the AssetId value.")]
        [StringLength(50, ErrorMessage = "AssetId must be fewer than 50 characters.")]
        public string AssetId { get; set; }
      
        [StringLength(20, ErrorMessage = "SerialNumber must be fewer than 20 characters.")]
        [Required(ErrorMessage = "Please provide the SerialNumber value.")]
       public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Please provide the LocationId value.")]
        [Range(1, long.MaxValue, ErrorMessage = "Please provide the StatusId value.")]
        public long LocationId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "Please provide the StatusId value.")]
        public long StatusId { get; set; }

        [Required(ErrorMessage = "Please provide the CardReader value.")]
        [StringLength(20,ErrorMessage = "CardReader must be fewer than 20 characters.")]
        public string CardReader { get; set; }

        [Required(ErrorMessage = "Please provide the MakeMasterId value.")]
        [Range(1, long.MaxValue, ErrorMessage = "Please provide the MakeMasterId value.")]
        public long MakeMasterId { get; set; }

        [Required(ErrorMessage = "Please provide the ModelId value.")]
        [Range(1,long.MaxValue, ErrorMessage = "Please provide the ModelId value.")]
        public long ModelId { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public long WarrantyDuration { get; set; }
        [Required(ErrorMessage = "Please provide the value of CreatedBy.")]
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
