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
        public string? SimCardMSIDN { get; set; }
        public string ChargeBoxId { get; set; }
        public string EndPointUrl { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwareSerialNumber { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
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
        public string? OEMOrderNumber { get; set; }
        public DateTime? DeactivationDate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<PortResponse> PortCommmand { get; set; }
    }
    public class GetAllDispenserResponse
    {
        public long Id { get; set; }
        public string AssetId { get; set; }
        public string SimCardMSIDN { get; set; }
        public string ChargeBoxId { get; set; }
        public string EndPointUrl { get; set; }
        public string FirmwareVersion { get; set; }
        public string HardwareSerialNumber { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
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
        public string IncrementalPower { get; set; }
        public bool IsActive { get; set; }
        public string MaxPower { get; set; }
        public string MinPower { get; set; }
        public long PlugTypeId { get; set; }
        public string PortName { get; set; }
        public string Power { get; set; }
    }
    public class DispensersRequest : QueryStringParameters
    {
        public string operatorId { get; set; }
    }
    public class DispenserLocationRequest
    {
        public List<long> locationIds { get; set; }
    }
    public class GetDispenserLocationResponse
    {
        public long Id { get; set; }   
        public long LocationId { get; set; }    
        public string ChargeBoxId { get; set; }
        
    }
    public class DispenserLocationResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<GetDispenserLocationResponse> Data { get; set; }
    }
}
