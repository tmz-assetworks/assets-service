using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.EnumData;
using AssetsService.Infrastructure.Helpers;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using static AssetsService.Core.Response.GetDispenserStatusResponse;

namespace AssetsService.Infrastructure.Repositories.Assets
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public class DispenserRepository : Repository<AssetsService.Core.Entities.Charger>, IDispenserRepository
    {
        string JSONString = string.Empty;
        TokenBase _tokenBase;
        public DispenserRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext, TokenBase tokenBase) : base(dbContext)
        {
            this._tokenBase = tokenBase;
        }
        async Task<List<PlugTypeResponseData>> IDispenserRepository.GetAllPlugType(string userId)
        {
            var data = _dbContext.ChargerType.ToList()
             .Select(m => new PlugTypeResponseData
             {
                 Id = m.Id,
                 PlugTypeName = m.ChargerTypeName
             }).ToList();
            return data;
        }
        async Task<List<ConnectorTypeResponseData>> IDispenserRepository.GetConnectorType(string userId)
        {
            var data = _dbContext.Connector.ToList()
             .Select(m => new ConnectorTypeResponseData
             {
                 Id = m.Id,
                 ConnectorTypeName = m.ConnectorType
             }).ToList();
            return data;
        }
        public Task<List<Charger>> GetAllDispenser()
        {
            return _dbContext.Charger.Join(_dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id)), m => m.LocationId, n => n.LocationId,
                (m, n) => new Charger
                {
                    Id = m.Id,
                    SimCardMSIDN = m.SimCardMSIDN,
                    AssetId = m.AssetId,
                    EndPointUrl = m.EndPointUrl,
                    FirmwareVersion = m.FirmwareVersion,
                    HardwareSerialNumber = m.HardwareSerialNumber,
                    IsActive = m.IsActive,
                    IsAutomatic = m.IsAutomatic,
                    MeterType = m.MeterType,
                    MultiplePorts = m.MultiplePorts,
                    PingSchedule = m.PingSchedule,
                    FleetStation = m.FleetStation,
                    ReadingSchedule = m.ReadingSchedule,
                    ChargeBoxId = m.ChargeBoxId,
                    ModelName = m.ModelName,
                    MakeName = m.MakeName,
                    LocationId = m.LocationId,
                    CableId = m.CableId,
                    ModemId = m.ModemId,
                    PadId = m.PadId,
                    RFIDReaderId = m.RFIDReaderId,
                    PowerCabinetId = m.PowerCabinetId,
                    SwitchGearId = m.SwitchGearId,
                    ChargerStatuses = m.ChargerStatuses,
                    InstallationDate = m.InstallationDate,
                    Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                select new Location
                                {
                                    Id = obls.Id,
                                    /// LocationId = obls.LocationId,
                                    ContactPersonName = obls.ContactPersonName,
                                    GlobalTax = obls.GlobalTax,
                                    TotalCapacity = obls.TotalCapacity,
                                    UtilityService = obls.UtilityService,
                                    CreatedBy = obls.CreatedBy,
                                    CreatedOn = obls.CreatedOn,
                                    Description = obls.Description,
                                    IsActive = obls.IsActive,
                                    ModifiedBy = obls.ModifiedBy,
                                    ModifiedOn = obls.ModifiedOn,
                                    AlternateMobileNumber = obls.AlternateMobileNumber,
                                    Email = obls.Email,
                                    LocationName = obls.LocationName,
                                    TimeZone = obls.TimeZone,
                                    LocationAddress = (from oblt in _dbContext.LocationAddress.Where(x => x.Id == obls.LocationAddressId)
                                                       select new LocationAddress
                                                       {
                                                           Id = oblt.Id,
                                                           AddressLine1 = oblt.AddressLine1,
                                                           AddressLine2 = oblt.AddressLine2,

                                                           //CityId = oblt.CityId,
                                                           CityName = oblt.CityName,
                                                           CountryId = oblt.CountryId,
                                                           CountryName = oblt.CityName,
                                                           CreatedBy = oblt.CreatedBy,
                                                           CreatedOn = obls.CreatedOn,
                                                           IsActive = oblt.IsActive,
                                                           LandlineNumber = oblt.LandlineNumber,
                                                           Latitude = oblt.Latitude,
                                                           Longitude = oblt.Longitude,
                                                           ModifiedBy = oblt.ModifiedBy,
                                                           ModifiedOn = oblt.ModifiedOn,
                                                           PinCode = oblt.PinCode,
                                                           StateId = oblt.StateId,
                                                           StateName = oblt.StateName
                                                       }).FirstOrDefault(),

                                    LocationStatus = (from oblu in _dbContext.LocationStatus.Where(x => x.Id == obls.LocationStatusId)
                                                      select new LocationStatus
                                                      {
                                                          Id = oblu.Id,
                                                          LocationStatusName = oblu.LocationStatusName,
                                                          CreatedBy = oblu.CreatedBy,
                                                          CreatedOn = oblu.CreatedOn,
                                                          IsActive = oblu.IsActive,
                                                          ModifiedBy = oblu.ModifiedBy,
                                                          ModifiedOn = oblu.ModifiedOn,

                                                      }).FirstOrDefault(),

                                    LocationSchedule = (from obs in _dbContext.LocationSchedule.Where(x => x.LocationId == obls.Id)
                                                        select new LocationSchedule
                                                        {
                                                            Day = obs.Day,
                                                            StartTime = obs.StartTime,
                                                            EndTime = obs.EndTime,
                                                            CreatedBy = obs.CreatedBy,
                                                            CreatedOn = obs.CreatedOn,
                                                            Id = obs.Id,
                                                            LocationId = obs.LocationId,
                                                            IsActive = obs.IsActive,
                                                            ModifiedBy = obs.ModifiedBy,
                                                            ModifiedOn = obs.ModifiedOn,
                                                        }).ToList(),
                                }).FirstOrDefault(),
                    Pad = (from obls in _dbContext.Pads.Where(x => x.Id == m.PadId)
                           select new Pad
                           {
                               Id = obls.Id,
                               PadName = obls.PadName
                           }).FirstOrDefault(),
                    PowerCabinet = (from obls in _dbContext.PowerCabinet.Where(x => x.Id == m.PowerCabinetId)
                                    select new PowerCabinet
                                    {
                                        Id = obls.Id,

                                    }).FirstOrDefault(),
                    RFIDReader = (from obls in _dbContext.RFIDReaders.Where(x => x.Id == m.RFIDReaderId)
                                  select new RFIDReader
                                  {
                                      Id = obls.Id,

                                  }).FirstOrDefault(),
                }).ToListAsync();
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public async Task<Charger> GetDispenserByStationId(long stationId)
        {
            stationId = 1;
            Charger dispenser = new Charger();
            // Dispenser result = _dbContext.Dispenser.FirstOrDefault(d => d.StationId == stationId);

            return dispenser;


        }

        public async Task<AllDispenserResponse> GetAllDispensers(DispensersRequest dispensersRequest)
        {
            int countTotal = 0;

            // ---------------- PORT TYPE (UNCHANGED) ----------------
            var result = await (from p in _dbContext.Port
                                join dispenser in _dbContext.Charger
                                on p.ChargerId equals dispenser.Id
                                select new PortTypeResponse
                                {
                                    PortType = p.Connector.ConnectorType,
                                    Color = p.Connector.Color
                                })
                .GroupBy(x => new { x.PortType })
                .Select(y => new PortTypeResponse
                {
                    PortType = y.Key.PortType,
                    Count = y.Count(),
                    Color = y.Min(n => n.Color)!
                }).ToListAsync();

            foreach (var r in result)
                countTotal += r.Count;

            result.Add(new PortTypeResponse
            {
                Count = countTotal,
                PortType = "Total Ports",
                Color = ConnectorColor.TotalPorts.GetEnumDisplayName()
            });

            // ---------------- MAIN QUERY (BEST PRACTICE) ----------------
            IQueryable<Charger> query = _dbContext.Charger
                .Include(x => x.Location)
                .Include(x => x.Ports).ThenInclude(p => p.Connector)
                .Include(x => x.ChargerStatuses)
                .Include(x => x.Modem)
                .Include(x => x.RFIDReader)
                .Include(x => x.PowerCabinet)
                .Include(x => x.Pad)
                .Include(x => x.Cable)
                .Include(x => x.SwitchGear);

            // 🔍 SEARCH FILTER
            if (!string.IsNullOrWhiteSpace(dispensersRequest.SearchParam))
            {
                string search = dispensersRequest.SearchParam.ToLower();

                query = query.Where(m =>
                    m.ChargeBoxId.ToLower().Contains(search) ||
                    m.AssetId.ToLower().Contains(search) ||
                    m.MakeName!.ToLower().Contains(search) ||
                    m.ModelName!.ToLower().Contains(search) ||
                    m.SimCardMSIDN!.ToLower().Contains(search) ||
                    m.Location.LocationName.ToLower().Contains(search));
            }

            // 📍 LOCATION FILTER (MULTI-SELECT)
            if (dispensersRequest.LocationIds != null && dispensersRequest.LocationIds.Any())
            {
                query = query.Where(x => dispensersRequest.LocationIds.Contains((int)x.LocationId!));
            }

            // ⚡ ACTIVATION STATUS FILTER
            if (dispensersRequest.ActivationStatus.HasValue)
            {
                bool isActive = dispensersRequest.ActivationStatus.Value == 1;
                query = query.Where(x => x.IsActive == isActive);
            }

            // ---------------- PROJECTION ----------------
            var results = await query
                .OrderByDescending(x => x.ModifiedOn)
                .Select(dispenser => new GetAllDispenserResponse
                {
                    Id = dispenser.Id,
                    AssetId = dispenser.AssetId,
                    SimCardMSIDN = dispenser.SimCardMSIDN ?? "",
                    ChargeBoxId = dispenser.ChargeBoxId,
                    LocationId = (long)dispenser.LocationId!,
                    LocationName = dispenser.Location.LocationName,
                    EndPointUrl = dispenser.EndPointUrl,
                    FirmwareVersion = dispenser.FirmwareVersion,
                    HardwareSerialNumber = dispenser.HardwareSerialNumber,
                    MeterType = dispenser.MeterType!,
                    MultiplePorts = dispenser.MultiplePorts,
                    PingSchedule = dispenser.PingSchedule!,
                    FleetStation = dispenser.FleetStation,
                    ReadingSchedule = dispenser.ReadingSchedule!,
                    MakeName = dispenser.MakeName!,
                    ModelName = dispenser.ModelName!,
                    ModemId = dispenser.ModemId ?? 0,
                    ModemSerialNumber = dispenser.Modem.SerialNumber ?? "",
                    RFIDReaderId = dispenser.RFIDReaderId ?? 0,
                    RFIDReader = dispenser.RFIDReader.CardReader ?? "",
                    PowerCabinetId = dispenser.PowerCabinetId ?? 0,
                    PowerCabinetSerialNumber = dispenser.PowerCabinet.SerialNumber ?? "",
                    Status = dispenser.ChargerStatuses == null || dispenser.ChargerStatuses.Count == 0
                                ? StatusConstants.Offline
                                : dispenser.ChargerStatuses.First().ChargerStatus1
                                    .Replace(StatusConstants.charging, "Busy", StringComparison.OrdinalIgnoreCase)
                                    .Replace(StatusConstants.suspendedev, "Busy", StringComparison.OrdinalIgnoreCase)
                                    .Replace(StatusConstants.suspendedevse, "Busy", StringComparison.OrdinalIgnoreCase)
                                    .Replace(StatusConstants.finishing, "Busy", StringComparison.OrdinalIgnoreCase)
                                    .Replace(StatusConstants.preparing, "Busy", StringComparison.OrdinalIgnoreCase),
                    PortType = string.Join(",",
                                dispenser.Ports.Select(s => s.Connector.ConnectorType)),
                    PadId = dispenser.PadId ?? 0,
                    PadName = dispenser.Pad.PadName ?? "",
                    CableId = dispenser.CableId ?? 0,
                    CableSerialNumber = dispenser.Cable.SerialNumber ?? "",
                    SwitchGearId = dispenser.SwitchGearId ?? 0,
                    SwitchGearName = dispenser.SwitchGear.SwitchGearName ?? "",
                    ProtocolName = dispenser.ProtocolName,
                    ModifiedOn = dispenser.ModifiedOn ?? DateTime.UtcNow,
                    IsActive = dispenser.IsActive,
                    IsAutomatic = dispenser.IsAutomatic
                })
                .ToListAsync();

            // ---------------- PAGINATION ----------------
            var dataResult = PagedList<GetAllDispenserResponse>.ToPagedList(
                results,
                dispensersRequest.PageNumber,
                dispensersRequest.PageSize);

            return new AllDispenserResponse
            {
                Data = dataResult,
                PortType = result,
                StatusCode = 200,
                StatusMessage = dataResult.Any() ? "Record Found" : "Record not found.",
                paginationResponse = new Core.PagingHelper.PaginationResponse
                {
                    TotalCount = dataResult.TotalCount,
                    PageSize = dataResult.PageSize,
                    CurrentPage = dataResult.CurrentPage,
                    TotalPages = dataResult.TotalPages,
                    HasNext = dataResult.HasNext,
                    HasPrevious = dataResult.HasPrevious
                }
            };
        }


        public async Task<GetDispenserResponse> GetDispenserDetailsById(long Id)
        {
            var results = (from p in _dbContext.Port
                           join dispenser in _dbContext.Charger
                           on p.ChargerId equals dispenser.Id
                           select new GetDispenserResponse
                           {
                               Id = dispenser.Id,
                               AssetId = dispenser.AssetId,
                               SimCardMSIDN = dispenser.SimCardMSIDN,
                               ChargeBoxId = dispenser.ChargeBoxId,
                               LocationId = dispenser.LocationId == null ? 0 : (long)dispenser.LocationId,
                               LocationName = dispenser.Location.LocationName,
                               EndPointUrl = dispenser.EndPointUrl,
                               FirmwareVersion = dispenser.FirmwareVersion,
                               HardwareSerialNumber = dispenser.HardwareSerialNumber,
                               MeterType = dispenser.MeterType,
                               MultiplePorts = dispenser.MultiplePorts,
                               PingSchedule = dispenser.PingSchedule,
                               FleetStation = dispenser.FleetStation,
                               ReadingSchedule = dispenser.ReadingSchedule,
                               MakeName = dispenser.MakeName,
                               ModelName = dispenser.ModelName,
                               ModemId = dispenser.ModemId == null ? 0 : (long)dispenser.ModemId,
                               ModemSerialNumber = dispenser.Modem != null ? dispenser.Modem.SerialNumber : "",
                               RFIDReaderId = dispenser.RFIDReaderId == null ? 0 : (long)dispenser.RFIDReaderId,
                               RFIDReader = dispenser.RFIDReader != null ? dispenser.RFIDReader.CardReader : "",
                               PowerCabinetId = dispenser.PowerCabinetId == null ? 0 : (long)dispenser.PowerCabinetId,
                               Status = dispenser.ChargerStatuses == null || dispenser.ChargerStatuses.Count == 0 ? "Offline" :
                                              dispenser.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("Charging", "Busy").Replace("suspendedev", "Busy").Replace("SuspendedEV", "Busy").Replace("suspendedevse", "Busy").Replace("SuspendedEVSE", "Busy")
                                              .Replace("finishing", "Busy").Replace("Finishing", "Busy").Replace("preparing", "Busy").Replace("Preparing", "Busy"),
                               PowerCabinetSerialNumber = dispenser.PowerCabinet.SerialNumber,
                               PortType = p.Connector.ConnectorType,
                               PadId = dispenser.PadId == null ? 0 : (long)dispenser.PadId,
                               PadName = dispenser.Pad.PadName,
                               CableId = dispenser.CableId == null ? 0 : (long)dispenser.CableId,
                               CableSerialNumber = dispenser.Cable.SerialNumber,
                               SwitchGearId = dispenser.SwitchGearId == null ? 0 : (long)dispenser.SwitchGearId,
                               SwitchGearName = dispenser.SwitchGear.SwitchGearName,
                               ProtocolName = dispenser.ProtocolName,
                               ModifiedOn = (DateTime)dispenser.ModifiedOn,
                               IsActive = dispenser.IsActive,
                               IsAutomatic = dispenser.IsAutomatic,
                               InstallationDate = (DateTime)dispenser.InstallationDate,
                               OEMOrderNumber = dispenser.OEMOrderNumber,
                               DeactivationDate = dispenser.DeactivationDate,
                               Latitude = dispenser.Latitude,
                               Longitude = dispenser.Longitude,
                               PortCommmand = (from port in dispenser.Ports.ToList()
                                               select new PortResponse
                                               {
                                                   PortId = port.Id,
                                                   ConnectorId = port.ConnectorId,
                                                   ConnectorType = port.ConnectorType,
                                                   CreatedBy = port.CreatedBy,
                                                   IncrementalPower = port.IncrementalPower,
                                                   IsActive = port.IsActive,
                                                   MaxPower = port.MaxPower,
                                                   MinPower = port.MinPower,
                                                   PlugTypeId = port.ChargerTypeId,
                                                   PortName = port.PortName,
                                                   Power = port.Power
                                               }).ToList<PortResponse>()

                           }).FirstOrDefault(d => d.Id == Id);
            return results;
        }
        public async Task<Charger> GetDispenserByChargeBoxId(string chargeBoxId)
        {
            var dispenser = _dbContext.Charger
                 .Select(m => new Charger
                 {
                     LocationId = m.LocationId,
                     Id = m.Id,
                     AssetId = m.AssetId,
                     EndPointUrl = m.EndPointUrl,
                     FirmwareVersion = m.FirmwareVersion,
                     HardwareSerialNumber = m.HardwareSerialNumber,
                     IsActive = m.IsActive,
                     IsAutomatic = m.IsAutomatic,
                     MeterType = m.MeterType,
                     MultiplePorts = m.MultiplePorts,
                     PingSchedule = m.PingSchedule,
                     FleetStation = m.FleetStation,
                     ReadingSchedule = m.ReadingSchedule,
                     ChargeBoxId = m.ChargeBoxId,
                     ModelName = m.ModelName,
                     CableId = m.CableId,
                     MakeName = m.MakeName,
                     ModemId = m.ModemId,
                     CreatedBy = m.CreatedBy,
                     ChargerStatuses = m.ChargerStatuses,
                     InstallationDate = m.InstallationDate,
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                 select new Location
                                 {
                                     Id = obls.Id,
                                     LocationName = obls.LocationName,
                                     LocationAddress = obls.LocationAddress
                                 }).FirstOrDefault(),
                     Ports = ((List<Port>)(from obpo in _dbContext.Port.Where(x => x.ChargerId == m.Id)
                                           select new Port
                                           {
                                               Id = obpo.Id,
                                               ConnectorId = obpo.ConnectorId,
                                               Connector = obpo.Connector,
                                               ConnectorType = obpo.ConnectorType,
                                               ChargerType = (from ob in _dbContext.ChargerType.Where(x => x.Id == obpo.ChargerTypeId)
                                                              select new ChargerType
                                                              {
                                                                  ChargerTypeName = ob.ChargerTypeName
                                                              }).FirstOrDefault(),
                                           })),
                 }).Where(d => d.ChargeBoxId.ToLower() == chargeBoxId.ToLower()).FirstOrDefault();
            return dispenser;
        }

        public async Task<List<DispenserByLocationIdResponse>> GetDispenserByLocationId(long locationId)
        {

            List<DispenserByLocationIdResponse> query = (from location in _dbContext.Locations
                                                         join charger in _dbContext.Charger
                                                         on location.Id equals charger.LocationId
                                                         join address in _dbContext.LocationAddress
                                                         on location.LocationAddressId equals address.Id
                                                         join Status in _dbContext.LocationStatus
                                                         on location.LocationStatusId equals Status.Id
                                                         where location.Id.Equals(locationId)
                                                         select new DispenserByLocationIdResponse
                                                         {
                                                             ChargerId = charger.Id,
                                                             LocationId = locationId,
                                                             LocationName = location.LocationName,
                                                             ContactPersonName = location.ContactPersonName,
                                                             AddressLine1 = address.AddressLine1,
                                                             LocationStatusName = Status.LocationStatusName,
                                                             LocationStatusId = location.LocationStatusId,
                                                             ChargeBoxId = charger.ChargeBoxId
                                                         }
                        ).ToList();

            return query.ToList();
        }
        public async Task<List<ChargerStatus>> GetDispenserStatusData(DispenserStatusRequest dispensersDetailRequest)
        {
            return _dbContext.ChargerStatuses
                 .Select(m => new ChargerStatus
                 {
                     Id = m.Id,
                     ChargerStatus1 = m.ChargerStatus1
                 }).ToList();
        }

        public async Task<Charger> GetDispenserById(long dispenserId)
        {
            return _dbContext.Charger
                 .Select(m => new Charger
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     EndPointUrl = m.EndPointUrl,
                     FirmwareVersion = m.FirmwareVersion,
                     HardwareSerialNumber = m.HardwareSerialNumber,
                     IsActive = m.IsActive,
                     IsAutomatic = m.IsAutomatic,
                     MeterType = m.MeterType,
                     MultiplePorts = m.MultiplePorts,
                     PingSchedule = m.PingSchedule,
                     FleetStation = m.FleetStation,
                     ReadingSchedule = m.ReadingSchedule,
                     ChargeBoxId = m.ChargeBoxId,
                     CreatedOn = m.CreatedOn,
                     CreatedBy = m.CreatedBy,
                     ModelName = m.ModelName,
                     MakeName = m.MakeName,
                     LocationId = m.LocationId,
                     CableId = m.CableId,
                     ModemId = m.ModemId,
                     PadId = m.PadId,
                     RFIDReaderId = m.RFIDReaderId,
                     PowerCabinetId = m.PowerCabinetId,
                     SwitchGearId = m.SwitchGearId,
                     ChargerStatuses = m.ChargerStatuses,
                     InstallationDate = m.InstallationDate,
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                 select new Location
                                 {
                                     Id = obls.Id,
                                     LocationName = obls.LocationName,
                                 }).FirstOrDefault(),
                     Pad = (from obls in _dbContext.Pads.Where(x => x.Id == m.PadId)
                            select new Pad
                            {
                                Id = obls.Id,
                                PadName = obls.PadName,
                            }).FirstOrDefault(),
                 }).Where(x => x.Id == dispenserId).FirstOrDefault();
        }
        public async Task<List<DispenserByLocationsResponse>> GetDispenserByLocations(List<long> locationIds, string? chargeBoxId)
        {
            List<DispenserByLocationsResponse> query = new List<DispenserByLocationsResponse>();
            if (chargeBoxId != null && chargeBoxId != "")
            {
                query = (from location in _dbContext.Locations
                         join charger in _dbContext.Charger.Where(x => x.ChargeBoxId.Equals(chargeBoxId))
                         on location.Id equals charger.LocationId
                         join address in _dbContext.LocationAddress
                         on location.LocationAddressId equals address.Id
                         join Status in _dbContext.LocationStatus
                         on location.LocationStatusId equals Status.Id
                         join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                         on location.Id equals userMap.LocationId
                         select new DispenserByLocationsResponse
                         {
                             DispenserId = charger.Id,
                             LocationId = location.Id,
                             LocationName = location.LocationName,
                             ContactPersonName = location.ContactPersonName,
                             AddressLine1 = address.AddressLine1,
                             LocationStatusName = Status.LocationStatusName,
                             LocationStatusId = location.LocationStatusId,
                             ChargeBoxId = charger.ChargeBoxId,
                             ChargerStatus = "",
                             ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.ChargerId == charger.Id).Select(s => s.Connector.ConnectorType)),
                             DispenserModel = charger.ModelName,
                             ProtocolName = charger.ProtocolName,
                             NoofPort = charger.Ports.Count.ToString(),
                             DispenserMake = charger.MakeName,


                         }

                          ).ToList<DispenserByLocationsResponse>();
            }
            else
            if (locationIds.Count <= 0)
            {
                query = (from location in _dbContext.Locations
                         join charger in _dbContext.Charger
                         on location.Id equals charger.LocationId
                         join address in _dbContext.LocationAddress
                         on location.LocationAddressId equals address.Id
                         join Status in _dbContext.LocationStatus
                         on location.LocationStatusId equals Status.Id
                         join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                         on location.Id equals userMap.LocationId
                         select new DispenserByLocationsResponse
                         {
                             DispenserId = charger.Id,
                             LocationId = location.Id,
                             LocationName = location.LocationName,
                             ContactPersonName = location.ContactPersonName,
                             AddressLine1 = address.AddressLine1,
                             LocationStatusName = Status.LocationStatusName,
                             LocationStatusId = location.LocationStatusId,
                             ChargeBoxId = charger.ChargeBoxId,
                             ChargerStatus = "",
                             ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.ChargerId == charger.Id).Select(s => s.Connector.ConnectorType)),
                             DispenserModel = charger.ModelName,
                             ProtocolName = charger.ProtocolName,
                             NoofPort = charger.Ports.Count.ToString(),
                             DispenserMake = charger.MakeName,


                         }

                           ).ToList<DispenserByLocationsResponse>();


            }
            else
            {
                query = (from location in _dbContext.Locations.Where(x => locationIds.Contains(x.Id))
                         join charger in _dbContext.Charger
                         on location.Id equals charger.LocationId
                         join address in _dbContext.LocationAddress
                         on location.LocationAddressId equals address.Id
                         join Status in _dbContext.LocationStatus
                         on location.LocationStatusId equals Status.Id
                         join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                        on location.Id equals userMap.LocationId
                         select new DispenserByLocationsResponse
                         {
                             DispenserId = charger.Id,
                             LocationId = location.Id,
                             LocationName = location.LocationName,
                             ContactPersonName = location.ContactPersonName,
                             AddressLine1 = address.AddressLine1,
                             LocationStatusName = Status.LocationStatusName,
                             LocationStatusId = location.LocationStatusId,
                             ChargeBoxId = charger.ChargeBoxId,
                             ChargerStatus = charger.ChargerStatuses == null || charger.ChargerStatuses.Count == 0 ? "Offline" :
                                                  charger.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("Charging", "Busy").Replace("suspendedev", "Busy").Replace("SuspendedEV", "Busy").Replace("suspendedevse", "Busy").Replace("SuspendedEVSE", "Busy")
                                                  .Replace("finishing", "Busy").Replace("Finishing", "Busy").Replace("preparing", "Busy").Replace("Preparing", "Busy"),
                             ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.ChargerId == charger.Id).Select(s => s.Connector.ConnectorType)),
                             DispenserModel = charger.ModelName,
                             ProtocolName = charger.ProtocolName,
                             NoofPort = charger.Ports.Count.ToString(),
                             DispenserMake = charger.MakeName,
                         }).ToList<DispenserByLocationsResponse>();

            }
            return query;
        }
        public async Task<PagedList<DispenserByLocationsResponse>> GetLocationDispensers(LocationDispensersRequest request)
        {
            List<DispenserByLocationsResponse> query = new List<DispenserByLocationsResponse>();
            if (request.locationIds.Count <= 0)
            {
                query = await (from location in _dbContext.Locations
                               join charger in (request.SearchParam == null && request.SearchParam == "") ? _dbContext.Charger :
                               _dbContext.Charger.Where(d => d.ChargeBoxId.ToLower().Contains(request.SearchParam.ToLower()))
                               on location.Id equals charger.LocationId
                               join address in _dbContext.LocationAddress
                               on location.LocationAddressId equals address.Id
                               join Status in _dbContext.LocationStatus
                               on location.LocationStatusId equals Status.Id
                               join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                               on location.Id equals userMap.LocationId
                               select new DispenserByLocationsResponse
                               {
                                   DispenserId = charger.Id,
                                   LocationId = location.Id,
                                   LocationName = location.LocationName,
                                   ContactPersonName = location.ContactPersonName,
                                   AddressLine1 = address.AddressLine1,
                                   LocationStatusName = Status.LocationStatusName,
                                   LocationStatusId = location.LocationStatusId,
                                   ChargeBoxId = charger.ChargeBoxId,
                                   ChargerStatus = charger.ChargerStatuses == null || charger.ChargerStatuses.Count == 0 ? "Offline" :
                                                  charger.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("Charging", "Busy").Replace("suspendedev", "Busy").Replace("SuspendedEV", "Busy").Replace("suspendedevse", "Busy").Replace("SuspendedEVSE", "Busy")
                                                  .Replace("finishing", "Busy").Replace("Finishing", "Busy").Replace("preparing", "Busy").Replace("Preparing", "Busy"),
                                   ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.ChargerId == charger.Id).Select(s => s.Connector.ConnectorType)),
                                   DispenserModel = charger.ModelName,
                                   ProtocolName = charger.ProtocolName,
                                   NoofPort = charger.Ports.Count.ToString(),
                                   DispenserMake = charger.MakeName,
                               }

                           ).ToListAsync<DispenserByLocationsResponse>();


            }
            else
            {
                query = await (from location in _dbContext.Locations.Where(x => request.locationIds.Contains(x.Id))
                               join charger in (request.SearchParam == null && request.SearchParam == "") ? _dbContext.Charger :
                               _dbContext.Charger.Where(d => d.ChargeBoxId.ToLower().Contains(request.SearchParam.ToLower()))
                               on location.Id equals charger.LocationId
                               join address in _dbContext.LocationAddress
                               on location.LocationAddressId equals address.Id
                               join Status in _dbContext.LocationStatus
                               on location.LocationStatusId equals Status.Id
                               join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                              on location.Id equals userMap.LocationId
                               select new DispenserByLocationsResponse
                               {
                                   DispenserId = charger.Id,
                                   LocationId = location.Id,
                                   LocationName = location.LocationName,
                                   ContactPersonName = location.ContactPersonName,
                                   AddressLine1 = address.AddressLine1,
                                   LocationStatusName = Status.LocationStatusName,
                                   LocationStatusId = location.LocationStatusId,
                                   ChargeBoxId = charger.ChargeBoxId,
                                   ChargerStatus = charger.ChargerStatuses == null || charger.ChargerStatuses.Count == 0 ? "Offline" :
                                                  charger.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("Charging", "Busy").Replace("suspendedev", "Busy").Replace("SuspendedEV", "Busy").Replace("suspendedevse", "Busy").Replace("SuspendedEVSE", "Busy")
                                                  .Replace("finishing", "Busy").Replace("Finishing", "Busy").Replace("preparing", "Busy").Replace("Preparing", "Busy"),
                                   ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.ChargerId == charger.Id).Select(s => s.Connector.ConnectorType)),
                                   DispenserModel = charger.ModelName,
                                   ProtocolName = charger.ProtocolName,
                                   NoofPort = charger.Ports.Count.ToString(),
                                   DispenserMake = charger.MakeName,
                               }).ToListAsync<DispenserByLocationsResponse>();

            }
            query = query != null ? query.OrderByDescending(a => a.ChargeBoxId).ToList<DispenserByLocationsResponse>() : query;

            //  Paging on Records

            var dataResult = PagedList<DispenserByLocationsResponse>.ToPagedList(query,
              request.PageNumber,
              request.PageSize);

            return Task.FromResult(dataResult).Result;
        }

        /// <summary>
        /// Get Chargers Details List
        /// </summary>
        /// <param name="dispensersDetailRequest"></param>
        /// <returns></returns>
        public Task<PagedList<DispensersDetail>> GetDispensersDetail(DispensersDetailRequest dispensersDetailRequest)
        {
            List<DispensersDetail> result = new List<DispensersDetail>();
            result = (from disp in (dispensersDetailRequest.SearchParam == null && dispensersDetailRequest.SearchParam == "") ? _dbContext.Charger :
                      _dbContext.Charger.Where(d => d.ChargeBoxId.ToLower().Contains(dispensersDetailRequest.SearchParam.ToLower()))
                      join location in _dbContext.Locations on disp.LocationId equals location.Id
                      join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                       on location.Id equals userMap.LocationId
                      select new DispensersDetail
                      {
                          ChargerBoxId = disp.ChargeBoxId,
                          TimeReported = disp.ChargerStatuses == null ? "" :
                          disp.ChargerStatuses.ToList().Where(x => x.ConnectorStatus.ToLower() == "faulted").ToList().Count == 0 ? "" :
                          disp.ChargerStatusHistories.Where(x => x.ConnectorStatus.ToLower() == "faulted").OrderByDescending(m => m.Id).FirstOrDefault().CreatedOn.Value.ToString("d-MM-yyyy h:mm"),
                          FaultSince = disp.ChargerStatuses.ToList().Where(x => x.ConnectorStatus.ToLower() == "faulted").ToList().Count == 0 ? "" :
                          (DateTime.Now - disp.ChargerStatusHistories.Where(x => x.ConnectorStatus.ToLower() == "faulted").OrderByDescending(m => m.Id).FirstOrDefault().CreatedOn).Value.Hours.ToString() + " hours",
                          LocationId = disp.LocationId == null ? 0 : (long)disp.LocationId,
                          State = location.LocationAddress != null ? location.LocationAddress.StateName : "",
                          ChargerType = "OCPP",
                          LocationContactName = location.LocationName,
                          LocationContactNumber = location.ContactPersonNumber,
                      }).ToList<DispensersDetail>();

            result = result != null ? result.OrderByDescending(a => a.ChargerName).ToList<DispensersDetail>() : result;

            //  Paging on Records

            var dataResult = PagedList<DispensersDetail>.ToPagedList(result,
              dispensersDetailRequest.PageNumber,
              dispensersDetailRequest.PageSize);

            return Task.FromResult(dataResult);
        }

        public async Task<ChargerResponse> ValidateChargerId(string ChargeBoxId)
        {
            ChargerResponse result = new ChargerResponse();
            Charger rus = await _dbContext.Charger.FirstOrDefaultAsync(d => d.ChargeBoxId == ChargeBoxId);
            if (rus != null)
            {
                result.Id = rus.Id;
                result.ChargeBoxId = rus.ChargeBoxId;
                result.status = rus.IsActive;

            }

            return result;

        }

        #region Modem DDL
        async Task<List<ListDropDown>> IDispenserRepository.GetModemDDLList(string userId, int? dispenserId)
        {
            List<Charger> dsipnser = _dbContext.Charger.Where(m => m.Id != dispenserId.Value).ToList();
            var data = _dbContext.Modem.ToList()
             .Select(m => new ListDropDown
             {
                 Id = m.Id,
                 Name = m.SerialNumber,
                 IsActive = m.IsActive
             }).Where(m => m.Name != "").Where(x => dsipnser.All(p2 => p2.ModemId != x.Id)).OrderBy(m => m.Name).ToList();
            return data;
        }
        public Task<Charger> UpdateDispenser(Charger dispenser)
        {
            try
            {
                List<Port> ports = new List<Port>();

                Charger oldDispenser = _dbContext.Charger.Find(dispenser.Id);
                oldDispenser.Id = dispenser.Id;
                oldDispenser.ModifiedBy = dispenser.ModifiedBy;
                oldDispenser.SimCardMSIDN = dispenser.SimCardMSIDN;
                oldDispenser.ModifiedOn = DateTime.Now;
                oldDispenser.HardwareSerialNumber = dispenser.HardwareSerialNumber;
                oldDispenser.EndPointUrl = dispenser.EndPointUrl;
                oldDispenser.AssetId = dispenser.AssetId;
                oldDispenser.PadId = dispenser.PadId;
                oldDispenser.ChargeBoxId = dispenser.ChargeBoxId;
                oldDispenser.MakeName = dispenser.MakeName;
                oldDispenser.FirmwareVersion = dispenser.FirmwareVersion;
                oldDispenser.CableId = dispenser.CableId;
                oldDispenser.SwitchGearId = dispenser.SwitchGearId;
                oldDispenser.IsActive = dispenser.IsActive;
                oldDispenser.MultiplePorts = dispenser.MultiplePorts;
                oldDispenser.ModelName = dispenser.ModelName;
                oldDispenser.IsAutomatic = dispenser.IsAutomatic;
                oldDispenser.LocationId = dispenser.LocationId;
                oldDispenser.MeterType = dispenser.MeterType;
                oldDispenser.ModemId = dispenser.ModemId;
                oldDispenser.PingSchedule = dispenser.PingSchedule;
                oldDispenser.ReadingSchedule = dispenser.ReadingSchedule;
                oldDispenser.PowerCabinetId = dispenser.PowerCabinetId;
                oldDispenser.FleetStation = true;
                oldDispenser.RFIDReaderId = dispenser.RFIDReaderId;
                oldDispenser.ProtocolName = dispenser.ProtocolName;
                oldDispenser.InstallationDate = dispenser.InstallationDate;
                oldDispenser.OEMOrderNumber = dispenser.OEMOrderNumber;
                oldDispenser.DeactivationDate = dispenser.DeactivationDate;
                oldDispenser.Latitude = dispenser.Latitude;
                oldDispenser.Longitude = dispenser.Longitude;
                oldDispenser.Ports = new List<Port>();
                List<Port> oldPorts = dispenser.Ports.Where(m => m.Id > 0).ToList();
                var newports = dispenser.Ports.Where(m => m.Id == 0).ToList();
                if (newports.Count() > 0)
                {
                    Port newPort = null;

                    for (int j = 0; j < newports.Count(); j++)
                    {
                        newPort = new Port();
                        newPort.IsActive = true;
                        newPort.CreatedBy = oldDispenser.CreatedBy;
                        newPort.CreatedOn = DateTime.Now;
                        newPort.Power = newports[j].Power;
                        newPort.ConnectorType = newports[j].ConnectorType;
                        newPort.ChargerId = newports[j].ChargerId;
                        newPort.ConnectorId = newports[j].ConnectorId;
                        newPort.IncrementalPower = newports[j].IncrementalPower;
                        newPort.MaxPower = newports[j].MaxPower;
                        newPort.MinPower = newports[j].MinPower;
                        newPort.ChargerTypeId = newports[j].ChargerTypeId;
                        newPort.PortName = newports[j].PortName;
                        newPort.ModifiedBy = oldDispenser.ModifiedBy;
                        newPort.ModifiedOn = DateTime.Now;
                        newPort.Id = newports[j].Id;
                        ports.Add(newPort);
                    }
                }
                if (oldPorts.Count() > 0)
                {
                    for (int j = 0; j < oldPorts.Count(); j++)
                    {
                        Port port = _dbContext.Port.Find(oldPorts[j].Id);
                        if (port != null)
                        {
                            port.ConnectorType = oldPorts[j].ConnectorType;
                            port.Id = oldPorts[j].Id;
                            port.ChargerId = oldPorts[j].ChargerId;
                            port.IsActive = true;
                            port.ConnectorId = oldPorts[j].ConnectorId;
                            port.IncrementalPower = oldPorts[j].IncrementalPower;
                            port.MaxPower = oldPorts[j].MaxPower;
                            port.MinPower = oldPorts[j].MinPower;
                            port.ChargerTypeId = oldPorts[j].ChargerTypeId;
                            port.Power = oldPorts[j].Power;
                            port.PortName = oldPorts[j].PortName;
                            port.ModifiedBy = dispenser.ModifiedBy;
                            port.ModifiedOn = DateTime.Now;
                            ports.Add(port);

                        }
                    }
                    if (ports.Count() > 0)
                    {
                        oldDispenser.Ports = ports;
                    }
                }
                _dbContext.Charger.Update(oldDispenser);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                dispenser = new Charger();
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    dispenser.Id = -1;
                }
            }
            return Task.FromResult(dispenser);
        }
        public async Task<bool> DeleteDispenserById(int dispenserId)
        {
            await using var transaction =
                await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.ChargerConfigurations
                    .Where(x => x.ChargerId == dispenserId)
                    .ExecuteDeleteAsync();

                await _dbContext.ChargerStatuses
                    .Where(x => x.ChargerId == dispenserId)
                    .ExecuteDeleteAsync();

                await _dbContext.Port
                    .Where(x => x.ChargerId == dispenserId)
                    .ExecuteDeleteAsync();

                await _dbContext.Charger
                    .Where(x => x.Id == dispenserId)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(x => x.IsDeleted, true)
                        .SetProperty(x => x.DeletedAtUtc, DateTime.UtcNow));

                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        #endregion

    }
}



