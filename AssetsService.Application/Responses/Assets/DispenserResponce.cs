using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Application.Responses.Assets
{
    public class DispenserQueryResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<AssetsService.Core.Entities.Charger> data { get; set; }
    }
    /// <summary>
    /// Create Dispenser response class
    /// </summary>


    public class AllDispenserQueryResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<Charger> data { get; set; }

    }
    public class DispenserByChargeBoxIdResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<AssetsService.Core.Entities.Charger> data { get; set; }
    }
    public class DispenserStatusData
    {
        public long Id { get; set; }
        public string ChargeBoxId { get; set; }

        public string DispenserStatus { get; set; }
    }
    public class DispenserResponse
    {
        /// <summary>
        /// Gets or Sets AssetId
        /// </summary>
        public long Id { get; set; }
        public string AssetId { get; set; }
        public string ChargeBoxId { get; set; }
        public string EndPointUrl { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwareSerialNumber { get; set; }
        public long LocationId { get; set; }
        public long MakeMasterId { get; set; }
        public long ModelId { get; set; }
        public long ModemId { get; set; }
        public string MeterType { get; set; }
        public bool MultiplePorts { get; set; }
        public string PingSchedule { get; set; }
        public bool PrivateStation { get; set; }
        public string ReadingSchedule { get; set; }
        public string SerialNumber { get; set; }
        public long RFIdReaderId { get; set; }
        public long PowerCabinetId { get; set; }
        public long PadId { get; set; }
        public long CableId { get; set; }
        public long SwitchGearId { get; set; }
        public long DispenserStatusId { get; set; }
        public string ProtocolName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsAutomatic { get; set; }
        public DateTime InstallationDate { get; set; }
    }
}