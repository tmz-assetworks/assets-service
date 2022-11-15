using AssetsService.Core.PagingHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class AllDispenserResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<GetAllDispenserResponse> Data { get; set; }
        public List<PortTypeResponse> PortType { get; set; }
        public PaginationResponse paginationResponse { get; set; }
        public AllDispenserResponse()
        {
            Data = new List<GetAllDispenserResponse>();
        }
    }
    public class GetDispenserByIdResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<GetDispenserResponse> Data { get; set; }
        public GetDispenserByIdResponse()
        {
            Data = new List<GetDispenserResponse>();
        }
    }
    public class PortTypeResponse
    {
        public int Count { get; set; }
        public string PortType { get; set; }
        public string Color { get; set; }
    }
    public class GetDispenserResponse
    {
        public long Id { get; set; }
        public string AssetId { get; set; }
        public string ChargeBoxId { get; set; }
        public string EndPointUrl { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwareSerialNumber { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }    
        public long MakeMasterId { get; set; }
        public string Make { get; set; }
        public long ModelId { get; set; }
        public string Model { get; set; }
        public long ModemId { get; set; }
        public string ModemSerialNumber { get; set; }
        public string MeterType { get; set; }
        public bool MultiplePorts { get; set; }
        public string SerialNumber { get; set; }
        public string PingSchedule { get; set; }
        public bool FleetStation { get; set; }
        public string ReadingSchedule { get; set; }
        public string PowerCabinetSerialNumber { get; set; }
        public long RFIDReaderId { get; set; }
        public string RFIDReader { get; set; }
        public long PowerCabinetId { get; set; }
        public long DispenserStatusId { get; set; }
        public long PadId { get; set; }
        public string PadName { get; set; }
        public long CableId { get; set; }
        public string CableSerialNumber { get; set; }
        public long SwitchGearId { get; set; }
        public string SwitchGearName { get; set; }
        public string ProtocolName { get; set; }
        public string Status { get; set; }
        public string PortType { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsAutomatic { get; set; }
        public DateTime InstallationDate { get; set; }
        public List<PortResponse> PortCommmand { get; set; }
    }
    public class GetAllDispenserResponse
    {
        public long Id { get; set; }
        public string AssetId { get; set; }
        public string ChargeBoxId { get; set; }
        public string EndPointUrl { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwareSerialNumber { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public long MakeMasterId { get; set; }
        public string Make { get; set; }
        public long ModelId { get; set; }
        public string Model { get; set; }
        public long ModemId { get; set; }
        public string ModemSerialNumber { get; set; }
        public string MeterType { get; set; }
        public bool MultiplePorts { get; set; }
        public string SerialNumber { get; set; }
        public string PingSchedule { get; set; }
        public bool FleetStation { get; set; }
        public string ReadingSchedule { get; set; }
        public string PowerCabinetSerialNumber { get; set; }
        public long RFIDReaderId { get; set; }
        public string RFIDReader { get; set; }
        public long PowerCabinetId { get; set; }
        public long DispenserStatusId { get; set; }
        public long PadId { get; set; }
        public string PadName { get; set; }
        public long CableId { get; set; }
        public string CableSerialNumber { get; set; }
        public long SwitchGearId { get; set; }
        public string SwitchGearName { get; set; }
        public string ProtocolName { get; set; }
        public string Status { get; set; }
        public string PortType { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsAutomatic { get; set; }
    }
    public class PortResponse
    {
        public long PortId { get; set; }
        public long ConnectorId { get; set; }
        public long ConnectorType { get; set; }
        public string CreatedBy { get; set; }
        public long IncrementalPower { get; set; }
        public bool IsActive { get; set; }
        public long MaxPower { get; set; }
        public long MinPower { get; set; }
        public long PlugTypeId { get; set; }
        public string PortName { get; set; }
        public long Power { get; set; }
    }
    public class DispensersRequest : QueryStringParameters
    {
        public string operatorId { get; set; }
    }
}
