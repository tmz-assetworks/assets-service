using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateDispenserCommand : IRequest<DispenserResponse>
    {
        public string AssetId { get; set; }

        public string Description { get; set; }

        public string EndPointUrl { get; set; }

        public string FirmwareVersion { get; set; }

        public string HardwareSerialNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsAutomatic { get; set; }

        public bool IsDeviceExists { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public long MakeMasterId { get; set; }

        public string MeterType { get; set; }

        public long ModelId { get; set; }

        public bool MultiplePorts { get; set; }

        // public long NetworkId { get; set; }

        // public string NetworkName { get; set; }

        public string PingSchedule { get; set; }

        public bool PrivateStation { get; set; }

        public string ReadingSchedule { get; set; }

        public string SerialNumber { get; set; }

        public long LocationId { get; set; }

        public long StationId { get; set; }

        public string ChargeBoxId { get; set; }

        public string StationName { get; set; }

        // public long SubnetworkId { get; set; }

        // public string SubnetworkName { get; set; }

    }
}