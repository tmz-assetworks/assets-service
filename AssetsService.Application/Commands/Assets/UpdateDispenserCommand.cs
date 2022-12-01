using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetsService.Application.Commands.Assets
{

    public class UpdateDispenserCommand : IRequest<DispenserResponse>
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 20 characters.")]
        public string AssetId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "ChargeBoxId must be fewer than 20 characters.")]
        public string ChargeBoxId { get; set; }
        [StringLength(20, MinimumLength = 0, ErrorMessage = "EndPointUrl must be fewer than 20 characters.")]
        public string EndPointUrl { get; set; }
        [StringLength(20, MinimumLength = 0, ErrorMessage = "FirmwareVersion must be fewer than 20 characters.")]
        public string FirmwareVersion { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "HardwareSerialNumber must be fewer than 20 characters.")]
        public string HardwareSerialNumber { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Location Id")]
        public long LocationId { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]{0,40}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string MakeName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]{0,40}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string ModelName { get; set; }

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

        [Required]
        public List<UpdatePortCommand>? UpdatePortCommand { get; set; }
    }
    public class UpdatePortCommand
    {
        public long Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Connector Id")]
        public int ConnectorId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ConnectorType Id")]
        public long ConnectorType { get; set; }

        [Required]
        public long IncrementalPower { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public long MaxPower { get; set; }
        [Required]
        public long MinPower { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid PlugType Id")]
        public long PlugTypeId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "PortName must be fewer than 20 characters.")]
        public string PortName { get; set; }
        [Required]
        public long Power { get; set; }
    }
}
