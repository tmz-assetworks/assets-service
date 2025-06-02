using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetsService.Application.Commands.Assets
{

    public class UpdateDispenserCommand : DispenserCommandBase, IRequest<DispenserResponse>
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 20 characters.")]
        public string AssetId { get; set; }

        [StringLength(15, MinimumLength = 0, ErrorMessage = "SimCardMSIDN must be fewer than 15 characters.")]
        public string? SimCardMSIDN { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "ChargeBoxId must be fewer than 100 characters.")]
        public string ChargeBoxId { get; set; } 
        public long? ModemId { get; set; }
        [StringLength(20, MinimumLength = 0, ErrorMessage = "MeterType must be fewer than 20 characters.")]
        public string MeterType { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "PingSchedule must be fewer than 20 characters.")]
        public string PingSchedule { get; set; }
        [Required]
        public bool FleetStation { get; set; }
        [StringLength(20, MinimumLength = 0, ErrorMessage = "ReadingSchedule must be fewer than 20 characters.")]
        public string ReadingSchedule { get; set; }
        //[Required]
        //[StringLength(20, MinimumLength = 0, ErrorMessage = "SerialNumber must be fewer than 20 characters.")]
        //public string SerialNumber { get; set; }          // Removed  11/07/2022

        public long? RFIdReaderId { get; set; }

        public long? PowerCabinetId { get; set; }

        public long? PadId { get; set; }

        public long? CableId { get; set; }

        public long? SwitchGearId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "ProtocolName must be fewer than 20 characters.")]
        public string ProtocolName { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime InstallationDate { get; set; }
        public string? OEMOrderNumber { get; set; }
        public DateTime? DeactivationDate { get; set; }

        [Required]
        public List<UpdatePortCommand>? UpdatePortCommand { get; set; }
    }
    public class UpdatePortCommand: PortCommandBase
    {
        public long Id { get; set; } 
        
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid PlugType Id")]
        public long PlugTypeId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "PortName must be fewer than 20 characters.")]
        public string PortName { get; set; }
        [Required]
        public string Power { get; set; }
    }
}
