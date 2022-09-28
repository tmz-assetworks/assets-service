using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using AssetsService.Core.Response;
using AssetsService.Core.PagingHelper;
using AssetsService.Infrastructure.EnumData;
using AssetsService.Infrastructure.Helpers;
using static AssetsService.Core.Response.GetDispenserStatusResponse;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class DispenserRepository : Repository<AssetsService.Core.Entities.Dispenser>, IDispenserRepository
    {
        string JSONString = string.Empty;
        TokenBase _tokenBase;
        public DispenserRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext, TokenBase tokenBase) : base(dbContext)
        {
            this._tokenBase = tokenBase;
        }
        async Task<List<PlugTypeResponseData>> IDispenserRepository.GetAllPlugType(string userId)
        {
            var data = _dbContext.PlugType.ToList()
             .Select(m => new PlugTypeResponseData
             {
                 Id = m.Id,
                 PlugTypeName = m.PlugTypeName
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
        public Task<List<Dispenser>> GetAllDispenser()
        {
            return _dbContext.Dispenser.Join(_dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id)), m => m.LocationId, n => n.LocationId,
                (m, n) => new Dispenser
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
                    PrivateStation = m.PrivateStation,
                    ReadingSchedule = m.ReadingSchedule,
                    SerialNumber = m.SerialNumber,
                    ChargeBoxId = m.ChargeBoxId,
                    ModelId = m.ModelId,
                    DispenserStatus = (from oblu in _dbContext.DispenserStatus.Where(x => x.Id == m.DispenserStatusId)
                                       select new DispenserStatus
                                       {
                                           Id = oblu.Id,
                                           DispenserStatusName = oblu.DispenserStatusName,
                                           CreatedBy = oblu.CreatedBy,
                                           CreatedOn = oblu.CreatedOn,
                                           IsActive = oblu.IsActive,
                                           ModifiedBy = oblu.ModifiedBy,
                                           ModifiedOn = oblu.ModifiedOn,
                                       }).FirstOrDefault(),

                    MakeMaster = (from obls in _dbContext.MakeMaster.Where(x => x.Id == m.MakeMasterId)
                                  select new MakeMaster
                                  {
                                      Id = obls.Id,
                                      Name = obls.Name
                                  }).FirstOrDefault(),
                    Model = (from obls in _dbContext.Model.Where(x => x.Id == m.ModelId)
                             select new Model
                             {
                                 Id = obls.Id,
                                 ModelName = obls.ModelName,
                             }).FirstOrDefault(),
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
                                    // NetworkId = obls.NetworkId,
                                    ///    NetworkName = obls.NetworkName,
                                    LocationName = obls.LocationName,
                                    ///  SubNetworkId = obls.SubNetworkId,
                                    /// SubNetworkName = obls.SubNetworkName,
                                    TimeZone = obls.TimeZone,

                                    LocationAddress = (from oblt in _dbContext.LocationAddress.Where(x => x.Id == obls.LocationAddressId)
                                                       select new LocationAddress
                                                       {
                                                           Id = oblt.Id,
                                                           AddressLine1 = oblt.AddressLine1,
                                                           AddressLine2 = oblt.AddressLine2,

                                                           CityId = oblt.CityId,
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
                }).ToListAsync();
        }

        public async Task<Dispenser> GetDispenserByStationId(long stationId)
        {
            stationId = 1;
            Dispenser dispenser = new Dispenser();
            // Dispenser result = _dbContext.Dispenser.FirstOrDefault(d => d.StationId == stationId);

            return dispenser;


        }
        public async Task<AllDispenserResponse> GetAllDispensers(DispensersRequest getAllDispenserRequest)
        {
            int countTotal = 0;
            var result = await (from p in _dbContext.Port
                                join dispenser in _dbContext.Dispenser
                                on p.DispenserId equals dispenser.Id
                                select new PortTypeResponse
                                {
                                    PortType = p.Connector.ConnectorType,
                                    Color = p.Connector.Color
                                }).GroupBy(x => new { x.PortType })
                .Select(y => new PortTypeResponse()
                {
                    PortType = y.Key.PortType,
                    Count = y.Count(),
                    Color = y.Min(n => n.Color)
                }).ToListAsync<PortTypeResponse>();
            for (int i = 0; i < result.Count; i++)
            {
                countTotal += result[i].Count;
            }
            result.Add(new PortTypeResponse()
            {
                Count = countTotal,
                PortType = "Total Ports",
                Color = ConnectorColor.TotalPorts.GetEnumDisplayName()
            });
            var results = (from dispenser in _dbContext.Dispenser
                           select new GetAllDispenserResponse
                           {
                               Id = dispenser.Id,
                               AssetId = dispenser.AssetId,
                               ChargeBoxId = dispenser.ChargeBoxId,
                               LocationId = dispenser.LocationId,
                               LocationName = dispenser.Location.LocationName,
                               EndPointUrl = dispenser.EndPointUrl,
                               FirmwareVersion = dispenser.FirmwareVersion,
                               HardwareSerialNumber = dispenser.HardwareSerialNumber,
                               MeterType = dispenser.MeterType,
                               MultiplePorts = dispenser.MultiplePorts,
                               PingSchedule = dispenser.PingSchedule,
                               PrivateStation = dispenser.PrivateStation,
                               ReadingSchedule = dispenser.ReadingSchedule,
                               MakeMasterId = dispenser.MakeMasterId,
                               Make = dispenser.MakeMaster != null ? dispenser.MakeMaster.Name : "",
                               ModelId = (long)dispenser.ModelId,
                               Model = dispenser.Model != null ? dispenser.Model.ModelName : "",
                               ModemId = (long)dispenser.ModemId,
                               ModemSerialNumber = dispenser.Modem != null ? dispenser.Modem.SerialNumber : "",
                               RFIDReaderId = (long)dispenser.RFIDReaderId,
                               RFIDReader = dispenser.RFIDReader != null ? dispenser.RFIDReader.CardReader : "",
                               DispenserStatusId = dispenser.DispenserStatusId,
                               PowerCabinetId = (long)dispenser.PowerCabinetId,
                               Status = dispenser.DispenserStatus != null ? dispenser.DispenserStatus.DispenserStatusName : "",
                               PowerCabinetSerialNumber = dispenser.PowerCabinet.SerialNumber,
                               SerialNumber = dispenser.SerialNumber,
                               PortType = String.Join(",", dispenser.Ports.Where(p => p.DispenserId == dispenser.Id).Select(s => s.Connector.ConnectorType)),
                               PadId = (long)dispenser.PadId,
                               PadName = dispenser.Pad.PadName,
                               ProtocolName = dispenser.ProtocolName,
                               ModifiedOn = (DateTime)dispenser.ModifiedOn,
                               IsActive = dispenser.IsActive,
                               IsAutomatic = dispenser.IsAutomatic,
                           }).OrderByDescending(m => m.ModifiedOn).ToList<GetAllDispenserResponse>();
            if (results.Count > 0 && !string.IsNullOrEmpty(getAllDispenserRequest.SearchParam))
            {
                results = results.Where(m => m.ChargeBoxId.ToLower().Contains(getAllDispenserRequest.SearchParam.ToLower())).ToList();
            }
            var dataResult = PagedList<GetAllDispenserResponse>.ToPagedList(results,
            getAllDispenserRequest.PageNumber,
            getAllDispenserRequest.PageSize);

            AllDispenserResponse response = new AllDispenserResponse()
            {
                Data = dataResult,
                PortType = result,
                StatusCode = 200,
                StatusMessage = dataResult.Count > 0 ? "Record Found" : "Record not found.",
            };
            response.paginationResponse = new Core.PagingHelper.PaginationResponse
            {
                TotalCount = dataResult.TotalCount,
                PageSize = dataResult.PageSize,
                CurrentPage = dataResult.CurrentPage,
                TotalPages = dataResult.TotalPages,
                HasNext = dataResult.HasNext,
                HasPrevious = dataResult.HasPrevious
            };
            return response;
        }
        public async Task<GetDispenserResponse> GetDispenserDetailsById(long Id)
        {
            var results = (from p in _dbContext.Port
                           join dispenser in _dbContext.Dispenser
                           on p.DispenserId equals dispenser.Id
                           select new GetDispenserResponse
                           {
                               Id = dispenser.Id,
                               AssetId = dispenser.AssetId,
                               ChargeBoxId = dispenser.ChargeBoxId,
                               LocationId = dispenser.LocationId,
                               LocationName = dispenser.Location.LocationName,
                               EndPointUrl = dispenser.EndPointUrl,
                               FirmwareVersion = dispenser.FirmwareVersion,
                               HardwareSerialNumber = dispenser.HardwareSerialNumber,
                               MeterType = dispenser.MeterType,
                               MultiplePorts = dispenser.MultiplePorts,
                               PingSchedule = dispenser.PingSchedule,
                               PrivateStation = dispenser.PrivateStation,
                               ReadingSchedule = dispenser.ReadingSchedule,
                               MakeMasterId = dispenser.MakeMasterId,
                               Make = dispenser.MakeMaster != null ? dispenser.MakeMaster.Name : "",
                               ModelId = (long)dispenser.ModelId,
                               Model = dispenser.Model != null ? dispenser.Model.ModelName : "",
                               ModemId = (long)dispenser.ModemId,
                               ModemSerialNumber = dispenser.Modem != null ? dispenser.Modem.SerialNumber : "",
                               RFIDReaderId = (long)dispenser.RFIDReaderId,
                               RFIDReader = dispenser.RFIDReader != null ? dispenser.RFIDReader.CardReader : "",
                               DispenserStatusId = dispenser.DispenserStatusId,
                               PowerCabinetId = (long)dispenser.PowerCabinetId,
                               Status = dispenser.DispenserStatus != null ? dispenser.DispenserStatus.DispenserStatusName : "",
                               PowerCabinetSerialNumber = dispenser.PowerCabinet.SerialNumber,
                               SerialNumber = dispenser.SerialNumber,
                               PortType = p.Connector.ConnectorType,
                               PadId = (long)dispenser.PadId,
                               PadName = dispenser.Pad.PadName,
                               ProtocolName = dispenser.ProtocolName,
                               ModifiedOn = (DateTime)dispenser.ModifiedOn,
                               IsActive = dispenser.IsActive,
                               IsAutomatic = dispenser.IsAutomatic,
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
                                                   PlugTypeId = port.PlugTypeId,
                                                   PortName = port.PortName,
                                                   Power = port.Power
                                               }).ToList<PortResponse>()

                           }).FirstOrDefault(d => d.Id == Id);
            return results;
        }
        public async Task<Dispenser> GetDispenserByChargeBoxId(string chargeBoxId)
        {
            var dispenser = _dbContext.Dispenser
                 .Select(m => new Dispenser
                 {
                     LocationId = m.LocationId,
                     DispenserStatusId = m.DispenserStatusId,
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
                     PrivateStation = m.PrivateStation,
                     ReadingSchedule = m.ReadingSchedule,
                     SerialNumber = m.SerialNumber,
                     ChargeBoxId = m.ChargeBoxId,
                     ModelId = m.ModelId,

                     DispenserStatus = (from oblu in _dbContext.DispenserStatus.Where(x => x.Id == m.DispenserStatusId)
                                        select new DispenserStatus
                                        {
                                            Id = oblu.Id,
                                            DispenserStatusName = oblu.DispenserStatusName,
                                            CreatedBy = oblu.CreatedBy,
                                            CreatedOn = oblu.CreatedOn,
                                            IsActive = oblu.IsActive,
                                            ModifiedBy = oblu.ModifiedBy,
                                            ModifiedOn = oblu.ModifiedOn,
                                        }).FirstOrDefault(),
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                 select new Location
                                 {
                                     Id = obls.Id,
                                     LocationName = obls.LocationName,
                                     LocationAddress = obls.LocationAddress
                                 }).FirstOrDefault(),
                     Ports = ((List<Port>)(from obpo in _dbContext.Port.Where(x => x.DispenserId == m.Id)
                                           select new Port
                                           {
                                               Id = obpo.Id,
                                               ConnectorId = obpo.ConnectorId,
                                               Connector = obpo.Connector,
                                               ConnectorType = obpo.ConnectorType,
                                           })),
                 }).Where(d => d.ChargeBoxId.ToLower() == chargeBoxId.ToLower()).FirstOrDefault();
            return dispenser;
        }

        public async Task<List<DispenserByLocationIdResponse>> GetDispenserByLocationId(long locationId)
        {

            List<DispenserByLocationIdResponse> query = (from location in _dbContext.Locations
                                                         join charger in _dbContext.Dispenser
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
                                                             ChargeBoxId = charger.ChargeBoxId,
                                                             SerialNumber = charger.SerialNumber,
                                                             DispenserStatus = charger.DispenserStatus,

                                                             //SerialNumber = charger.st,
                                                             //TODO
                                                             //ChargerStats

                                                         }
                        ).ToList();

            return query.ToList();
        }
        public async Task<List<DispenserStatus>> GetDispenserStatusData(DispenserStatusRequest dispensersDetailRequest)
        {
            return _dbContext.DispenserStatus
                 .Select(m => new DispenserStatus
                 {
                     Id = m.Id,
                     DispenserStatusName = m.DispenserStatusName
                 }).ToList();
        }

        public async Task<Dispenser> GetDispenserById(long dispenserId)
        {
            return _dbContext.Dispenser
                 .Select(m => new Dispenser
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
                     //  NetworkId = m.NetworkId,
                     //  NetworkName = m.NetworkName,
                     PingSchedule = m.PingSchedule,
                     PrivateStation = m.PrivateStation,
                     ReadingSchedule = m.ReadingSchedule,
                     SerialNumber = m.SerialNumber,
                     ChargeBoxId = m.ChargeBoxId,
                     CreatedOn = m.CreatedOn,
                     CreatedBy = m.CreatedBy,
                     ModelId = m.ModelId,
                     DispenserStatus = (from oblu in _dbContext.DispenserStatus.Where(x => x.Id == m.DispenserStatusId)
                                        select new DispenserStatus
                                        {
                                            Id = oblu.Id,
                                            DispenserStatusName = oblu.DispenserStatusName,
                                            CreatedBy = oblu.CreatedBy,
                                            CreatedOn = oblu.CreatedOn,
                                            IsActive = oblu.IsActive,
                                            ModifiedBy = oblu.ModifiedBy,
                                            ModifiedOn = oblu.ModifiedOn,
                                        }).FirstOrDefault(),


                     MakeMaster = (from obls in _dbContext.MakeMaster.Where(x => x.Id == m.MakeMasterId)
                                   select new MakeMaster
                                   {
                                       Id = obls.Id,
                                       Name = obls.Name
                                   }).FirstOrDefault(),
                     Model = (from obls in _dbContext.Model.Where(x => x.Id == m.ModelId)
                              select new Model
                              {
                                  Id = obls.Id,
                                  ModelName = obls.ModelName,
                              }).FirstOrDefault(),
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
        public async Task<List<DispenserByLocationsResponse>> GetDispenserByLocations(List<long> locationIds)
        {
            List<DispenserByLocationsResponse> query = new List<DispenserByLocationsResponse>();
            if (locationIds.Count <= 0)
            {
                query = (from location in _dbContext.Locations
                         join charger in _dbContext.Dispenser
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
                             SerialNumber = charger.SerialNumber,
                             ChargerStatus = charger.DispenserStatus.DispenserStatusName,
                             ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.DispenserId == charger.Id).Select(s => s.Connector.ConnectorType)),
                             DispenserModel = charger.Model.ModelName,
                             ProtocolName = charger.Model.Protocol.ProtocolName,
                             NoofPort = charger.Ports.Count.ToString(),
                             DispenserMake = charger.MakeMaster.Name,


                         }

                           ).ToList<DispenserByLocationsResponse>();


            }
            else
            {
                query = (from location in _dbContext.Locations.Where(x => locationIds.Contains(x.Id))
                         join charger in _dbContext.Dispenser
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
                             SerialNumber = charger.SerialNumber,
                             ChargerStatus = charger.DispenserStatus.DispenserStatusName,
                             ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.DispenserId == charger.Id).Select(s => s.Connector.ConnectorType)),
                             DispenserModel = charger.Model.ModelName,
                             ProtocolName = charger.Model.Protocol.ProtocolName,
                             NoofPort = charger.Ports.Count.ToString(),
                             DispenserMake = charger.MakeMaster.Name,
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
                               join charger in _dbContext.Dispenser
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
                                   SerialNumber = charger.SerialNumber,
                                   ChargerStatus = charger.DispenserStatus.DispenserStatusName,
                                   ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.DispenserId == charger.Id).Select(s => s.Connector.ConnectorType)),
                                   DispenserModel = charger.Model.ModelName,
                                   ProtocolName = charger.Model.Protocol.ProtocolName,
                                   NoofPort = charger.Ports.Count.ToString(),
                                   DispenserMake = charger.MakeMaster.Name,


                               }

                           ).ToListAsync<DispenserByLocationsResponse>();


            }
            else
            {
                query = await (from location in _dbContext.Locations.Where(x => request.locationIds.Contains(x.Id))
                               join charger in _dbContext.Dispenser
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
                                   SerialNumber = charger.SerialNumber,
                                   ChargerStatus = charger.DispenserStatus.DispenserStatusName,
                                   ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.DispenserId == charger.Id).Select(s => s.Connector.ConnectorType)),
                                   DispenserModel = charger.Model.ModelName,
                                   ProtocolName = charger.Model.Protocol.ProtocolName,
                                   NoofPort = charger.Ports.Count.ToString(),
                                   DispenserMake = charger.MakeMaster.Name,
                               }).ToListAsync<DispenserByLocationsResponse>();

            }
            query = query != null ? query.OrderByDescending(a => a.ChargeBoxId).ToList<DispenserByLocationsResponse>() : query;


            if (!string.IsNullOrEmpty(request.SearchParam))
                query = query.Where(d => d.ChargeBoxId.ToLower().Contains(request.SearchParam.ToLower())
             ).ToList<DispenserByLocationsResponse>();
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
            result = (from disp in _dbContext.Dispenser
                      join location in _dbContext.Locations on disp.LocationId equals location.Id
                      join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                       on location.Id equals userMap.LocationId
                      select new DispensersDetail
                      {
                          ChargerBoxId = disp.ChargeBoxId,
                          FaultSince = "",
                          TimeReported = "",
                          LocationId = disp.LocationId,
                          State = location.LocationAddress != null ? location.LocationAddress.StateName : "",
                          ChargerType = "OCPP",
                          LocationContactName = location.LocationName,
                          LocationContactNumber = location.ContactPersonName,


                      }).ToList<DispensersDetail>();
            result = result != null ? result.OrderByDescending(a => a.ChargerName).ToList<DispensersDetail>() : result;


            if (!string.IsNullOrEmpty(dispensersDetailRequest.SearchParam))
                result = result.Where(d => d.ChargerName.ToLower().Contains(dispensersDetailRequest.SearchParam.ToLower())
             ).ToList<DispensersDetail>();
            //  Paging on Records

            var dataResult = PagedList<DispensersDetail>.ToPagedList(result,
              dispensersDetailRequest.PageNumber,
              dispensersDetailRequest.PageSize);

            return Task.FromResult(dataResult);
        }

        public async Task<ChargerResponse> ValidateChargerId(string ChargeBoxId)
        {
            ChargerResponse result = new ChargerResponse();
            Dispenser rus = await _dbContext.Dispenser.FirstOrDefaultAsync(d => d.ChargeBoxId == ChargeBoxId);
            if (rus != null)
            {
                result.Id = rus.Id;
                result.ChargeBoxId = rus.ChargeBoxId;
                result.status = rus.IsActive;

            }

            return result;

        }

        #region Modem DDL
        async Task<List<ListDropDown>> IDispenserRepository.GetModemDDLList(string userId)
        {
            var data = _dbContext.Modem.ToList()
             .Select(m => new ListDropDown
             {
                 Id = m.Id,
                 Name = m.SerialNumber
             }).Where(m => m.Name != "").OrderBy(m => m.Name).ToList();
            return data;
        }
        public Task<Dispenser> UpdateDispenser(Dispenser dispenser)
        {
            try
            {
                List<Port> ports = new List<Port>();

                Dispenser oldDispenser = _dbContext.Dispenser.Find(dispenser.Id);
                oldDispenser.Id = dispenser.Id;
                oldDispenser.ModifiedBy = dispenser.ModifiedBy;
                oldDispenser.ModifiedOn = DateTime.Now;
                oldDispenser.SerialNumber = dispenser.SerialNumber;
                oldDispenser.HardwareSerialNumber = dispenser.HardwareSerialNumber;
                oldDispenser.EndPointUrl = dispenser.EndPointUrl;
                oldDispenser.AssetId = dispenser.AssetId;
                oldDispenser.PadId = dispenser.PadId;
                oldDispenser.ChargeBoxId = dispenser.ChargeBoxId;
                oldDispenser.MakeMasterId = dispenser.MakeMasterId;
                oldDispenser.DispenserStatusId = dispenser.DispenserStatusId;
                oldDispenser.FirmwareVersion = dispenser.FirmwareVersion;
                oldDispenser.IsActive = dispenser.IsActive;
                oldDispenser.MultiplePorts = dispenser.MultiplePorts;
                oldDispenser.ModelId = dispenser.ModelId;
                oldDispenser.IsAutomatic = dispenser.IsAutomatic;
                oldDispenser.LocationId = dispenser.LocationId;
                oldDispenser.MeterType = dispenser.MeterType;
                oldDispenser.ModemId = dispenser.ModemId;
                oldDispenser.PingSchedule = dispenser.PingSchedule;
                oldDispenser.ReadingSchedule = dispenser.ReadingSchedule;
                oldDispenser.PowerCabinetId = dispenser.PowerCabinetId;
                oldDispenser.PrivateStation = dispenser.PrivateStation;
                oldDispenser.RFIDReaderId = dispenser.RFIDReaderId;
                oldDispenser.ProtocolName = dispenser.ProtocolName;
                oldDispenser.Ports= new List<Port>();
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
                        newPort.CreatedOn= DateTime.Now;
                        newPort.Power = newports[j].Power;
                        newPort.ConnectorType = newports[j].ConnectorType;
                        newPort.DispenserId = newports[j].DispenserId;
                        newPort.ConnectorId = newports[j].ConnectorId;
                        newPort.IncrementalPower = newports[j].IncrementalPower;
                        newPort.MaxPower = newports[j].MaxPower;
                        newPort.MinPower = newports[j].MinPower;
                        newPort.PlugTypeId = newports[j].PlugTypeId;
                        newPort.PortName = newports[j].PortName;
                        newPort.ModifiedBy = oldDispenser.ModifiedBy;
                        newPort.ModifiedOn = DateTime.Now;
                        newPort.Id = newports[j].Id;
                        ports.Add(newPort);
                    }
                }
                if(oldPorts.Count() >0)
                {
                    for (int j = 0; j < oldPorts.Count(); j++)
                    {
                        Port port = _dbContext.Port.Find(oldPorts[j].Id);
                        if (port != null)
                        {
                            port.ConnectorType = oldPorts[j].ConnectorType;
                            port.Id = oldPorts[j].Id;
                            port.DispenserId = oldPorts[j].DispenserId;
                            port.IsActive = oldPorts[j].IsActive;
                            port.ConnectorId = oldPorts[j].ConnectorId;
                            port.IncrementalPower = oldPorts[j].IncrementalPower;
                            port.MaxPower = oldPorts[j].MaxPower;
                            port.MinPower = oldPorts[j].MinPower;
                            port.PlugTypeId = oldPorts[j].PlugTypeId;
                            port.Power = oldPorts[j].Power;
                            port.PortName = oldPorts[j].PortName;
                            port.ModifiedBy = dispenser.ModifiedBy;
                            port.ModifiedOn = DateTime.Now;                           
                            ports.Add(port);
                            
                        }
                    }
                    if(ports.Count()> 0)
                    {
                        oldDispenser.Ports = ports;
                    }
                }
                _dbContext.Dispenser.Update(oldDispenser);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                dispenser = new Dispenser();
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    dispenser.Id = -1;
                }
            }
            return Task.FromResult(dispenser);
        }

        #endregion
    }
}



