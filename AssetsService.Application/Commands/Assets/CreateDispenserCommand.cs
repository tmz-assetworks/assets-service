using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
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
    public class CreateDispenserCommand : IRequest<DispenserResponse>
    {
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
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid MakeMaster Id")]
        public long MakeMasterId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Model Id")]
        public long ModelId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Modem Id")]
        public long ModemId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "MeterType must be fewer than 20 characters.")]
        public string MeterType { get; set; }
        [Required]
        public bool MultiplePorts { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "PingSchedule must be fewer than 20 characters.")]
        public string PingSchedule { get; set; }
        [Required]
        public bool PrivateStation { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "HardwareSerialNumber must be fewer than 20 characters.")]
        public string ReadingSchedule { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "SerialNumber must be fewer than 20 characters.")]
        public string SerialNumber { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid RFIdReader Id")]
        public long RFIdReaderId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid PowerCabinet Id")]
        public long PowerCabinetId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid Pad Id")]
        public long PadId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid DispenserStatus Id")]
        public long DispenserStatusId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "ProtocolName must be fewer than 20 characters.")]
        public string ProtocolName { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsAutomatic { get; set; }
        [Required]
        public List<PortCommand>? PortCommand { get; set; }
    }
    public class PortCommand
    {        
        public long? Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Connector Id")]
        public int ConnectorId { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter valid ConnectorType Id")]
        public long ConnectorType { get; set; }
        
        //[Required]
        //public string CreatedBy { get; set; }

        [Required]
        public long IncrementalPower { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public long MaxPower { get; set; }
        [Required]
        public long MinPower { get; set; }
        [Required]
        public long PlugTypeId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "PortName must be fewer than 20 characters.")]
        public string PortName { get; set; }
        [Required]
        public long Power { get; set; }
    }
}