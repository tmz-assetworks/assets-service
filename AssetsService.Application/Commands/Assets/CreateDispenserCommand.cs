using AssetsService.Application.Responses.Assets;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateDispenserCommand : DispenserCommandBase, IRequest<DispenserResponse>
    {
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "AssetId must be fewer than 20 characters.")]
        public string AssetId { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "ChargeBoxId must be fewer than 100 characters.")]
        public string ChargeBoxId { get; set; } = string.Empty;

        [StringLength(20, MinimumLength = 0, ErrorMessage = "SimCardMSIDN must be fewer than 20 characters")]
        public string? SimCardMSIDN { get; set; }
        public long? ModemId { get; set; } = 0;    // 07/11/2022
        [StringLength(20, MinimumLength = 0, ErrorMessage = "MeterType must be fewer than 20 characters.")]
        public string MeterType { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 0, ErrorMessage = "PingSchedule must be fewer than 20 characters.")]
        public string PingSchedule { get; set; } = string.Empty;
        [Required]
        public bool FleetStation { get; set; }        // PrivateStation changed to FleetStation  07/11/2022
        [StringLength(20, MinimumLength = 0, ErrorMessage = "ReadingSchedule must be fewer than 20 characters.")]
        public string ReadingSchedule { get; set; } = string.Empty;
        public long? RFIdReaderId { get; set; } = 0;

        public long? PowerCabinetId { get; set; } = 0;

        public long? PadId { get; set; } = 0;

        public long? CableId { get; set; } = 0;
        public long? SwitchGearId { get; set; } = 0;

        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "ProtocolName must be fewer than 20 characters.")]
        public string ProtocolName { get; set; } = string.Empty;
        [Required]
        public string CreatedBy { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; }
        public DateTime InstallationDate { get; set; }
        public string? OEMOrderNumber { get; set; }
        public DateTime? DeactivationDate { get; set; }

        [Required]
        public List<PortCommand>? PortCommand { get; set; }
    }
    public class PortCommand : PortCommandBase
    {
        public long? Id { get; set; }
        [Required]
        public long PlugTypeId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "PortName must be fewer than 20 characters.")]
        public string PortName { get; set; } = string.Empty;
        [Required]
        public string Power { get; set; } = string.Empty;
    }

    public abstract class DispenserCommandBase
    {
        [StringLength(20, MinimumLength = 0, ErrorMessage = "EndPointUrl must be fewer than 20 characters.")]
        public string EndPointUrl { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 0, ErrorMessage = "FirmwareVersion must be fewer than 20 characters.")]
        public string FirmwareVersion { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "HardwareSerialNumber must be fewer than 100 characters.")]
        public string HardwareSerialNumber { get; set; } = string.Empty;
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Location Id")]
        public long LocationId { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 \\-]{0,40}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string MakeName { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^[a-zA-Z0-9 \\-]{0,40}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string ModelName { get; set; } = string.Empty;
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }

    public abstract class PortCommandBase
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Connector Id")]
        public int ConnectorId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ConnectorType Id")]
        public long ConnectorType { get; set; }
        [Required]
        public string IncrementalPower { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string MaxPower { get; set; } = string.Empty;
        [Required]
        public string MinPower { get; set; } = string.Empty;

    }
}
