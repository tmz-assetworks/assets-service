using AssetsService.Core.Entities;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.EnumData;
using AssetsService.Infrastructure.Helpers;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;


namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class LocationRepository : Repository<AssetsService.Core.Entities.Location>, ILocationRepository
    {
        string JSONString = string.Empty;
        TokenBase _tokenBase;
        public LocationRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext, TokenBase tokenBase) : base(dbContext)
        {
            _tokenBase = tokenBase;
        }
        public async Task<AssetsService.Core.Entities.Location> GetLocationById(long locationId)
        {
            return _dbContext.Locations.Where(t => t.Id == locationId)
                 .Select(m => new Location
                 {
                     Id = m.Id,
                     ContactPersonName = m.ContactPersonName,
                     ContactPersonNumber = m.ContactPersonNumber,
                     GlobalTax = m.GlobalTax,
                     TotalCapacity = m.TotalCapacity,
                     UtilityService = m.UtilityService,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     Description = m.Description,
                     IsActive = m.IsActive,
                     AlternateMobileNumber = m.AlternateMobileNumber,
                     Email = m.Email,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     DepartmentName = m.DepartmentName,
                     LocationStatusId = m.LocationStatusId,
                     LocationAddressId = m.LocationAddressId,
                     FuelProtectType = m.FuelProtectType,

                     LocationName = m.LocationName,

                     TimeZone = m.TimeZone,

                     LocationAddress = (from obls in _dbContext.LocationAddress.Where(x => x.Id == m.LocationAddressId)
                                        select new LocationAddress
                                        {
                                            Id = obls.Id,
                                            AddressLine1 = obls.AddressLine1,
                                            AddressLine2 = obls.AddressLine2,
                                            //CityId = obls.CityId,
                                            CityName = obls.CityName,
                                            CountryId = obls.CountryId,
                                            CountryName = obls.CountryName,
                                            CreatedBy = obls.CreatedBy,
                                            CreatedOn = obls.CreatedOn,
                                            IsActive = obls.IsActive,
                                            LandlineNumber = obls.LandlineNumber,
                                            Latitude = obls.Latitude,
                                            Longitude = obls.Longitude,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,
                                            PinCode = obls.PinCode,
                                            StateId = obls.StateId,
                                            StateName = obls.StateName
                                        }).FirstOrDefault(),

                     LocationStatus = (from obls in _dbContext.LocationStatus.Where(x => x.Id == m.LocationStatusId)
                                       select new LocationStatus
                                       {
                                           Id = obls.Id,
                                           LocationStatusName = obls.LocationStatusName,
                                           CreatedBy = obls.CreatedBy,
                                           CreatedOn = obls.CreatedOn,
                                           IsActive = obls.IsActive,
                                           ModifiedBy = obls.ModifiedBy,
                                           ModifiedOn = obls.ModifiedOn,
                                       }).FirstOrDefault(),   
                     LocationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == m.Id)
                                         select new LocationSchedule
                                         {
                                             Day = obls.Day,
                                             StartTime = obls.StartTime,
                                             EndTime = obls.EndTime,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             Id = obls.Id,
                                             LocationId = obls.LocationId,
                                             IsActive = obls.IsActive,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                             IsOpenAlldays = obls.IsOpenAlldays
                                         }).ToList(),
                     OperatorUserMapper = (from obls in _dbContext.OperatorUserMapper.Where(x => x.LocationId == m.Id)
                                           select new OperatorUserMapper
                                           {
                                               UserId = obls.UserId,
                                               CreatedBy = obls.CreatedBy,
                                               CreatedOn = obls.CreatedOn,
                                               Id = obls.Id,
                                               LocationId = obls.LocationId,
                                               IsActive = obls.IsActive,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                           }).ToList(),

                 }).ToList().FirstOrDefault();
        }
        public async Task<List<Location>> GetAllLocation()
        {
            if (_tokenBase.getRole().ToLower() == "operator")
            {
                return _dbContext.Locations
               .Join(_dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id)), m => m.Id, n => n.LocationId, (m, n) => new Location
               {
                   Id = m.Id,
                   ContactPersonName = m.ContactPersonName,
                   GlobalTax = m.GlobalTax,
                   TotalCapacity = m.TotalCapacity,
                   UtilityService = m.UtilityService,
                   CreatedBy = m.CreatedBy,
                   CreatedOn = m.CreatedOn,
                   Description = m.Description,
                   IsActive = m.IsActive,
                   AlternateMobileNumber = m.AlternateMobileNumber,
                   Email = m.Email,
                   ModifiedBy = m.ModifiedBy,
                   ModifiedOn = m.ModifiedOn,
                   DepartmentName = m.DepartmentName,
                   LocationStatusId = m.LocationStatusId,
                   LocationAddressId = m.LocationAddressId,
                   FuelProtectType = m.FuelProtectType,

                   LocationName = m.LocationName,

                   TimeZone = m.TimeZone,

                   LocationAddress = (from obls in _dbContext.LocationAddress.Where(x => x.Id == m.LocationAddressId)
                                      select new LocationAddress
                                      {
                                          Id = obls.Id,
                                          AddressLine1 = obls.AddressLine1,
                                          AddressLine2 = obls.AddressLine2,

                                          //CityId = obls.CityId,
                                          CityName = obls.CityName,
                                          CountryId = obls.CountryId,
                                          CountryName = obls.CountryName,
                                          CreatedBy = obls.CreatedBy,
                                          CreatedOn = obls.CreatedOn,
                                          IsActive = obls.IsActive,
                                          LandlineNumber = obls.LandlineNumber,
                                          Latitude = obls.Latitude,
                                          Longitude = obls.Longitude,
                                          ModifiedBy = obls.ModifiedBy,
                                          ModifiedOn = obls.ModifiedOn,
                                          PinCode = obls.PinCode,
                                          StateId = obls.StateId,
                                          StateName = obls.StateName
                                      }).FirstOrDefault(),

                   LocationStatus = (from obls in _dbContext.LocationStatus.Where(x => x.Id == m.LocationStatusId)
                                     select new LocationStatus
                                     {
                                         Id = obls.Id,
                                         LocationStatusName = obls.LocationStatusName,
                                         CreatedBy = obls.CreatedBy,
                                         CreatedOn = obls.CreatedOn,
                                         IsActive = obls.IsActive,
                                         ModifiedBy = obls.ModifiedBy,
                                         ModifiedOn = obls.ModifiedOn,

                                     }).FirstOrDefault(),
                   LocationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == m.Id)
                                       select new LocationSchedule
                                       {
                                           Day = obls.Day,
                                           StartTime = obls.StartTime,
                                           EndTime = obls.EndTime,
                                           CreatedBy = obls.CreatedBy,
                                           CreatedOn = obls.CreatedOn,
                                           Id = obls.Id,
                                           LocationId = obls.LocationId,
                                           IsActive = obls.IsActive,
                                           ModifiedBy = obls.ModifiedBy,
                                           ModifiedOn = obls.ModifiedOn,
                                           IsOpenAlldays = obls.IsOpenAlldays
                                       }).ToList(),
                   OperatorUserMapper = (from obls in _dbContext.OperatorUserMapper.Where(x => x.LocationId == m.Id)
                                         select new OperatorUserMapper
                                         {
                                             UserId = obls.UserId,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             Id = obls.Id,
                                             LocationId = obls.LocationId,
                                             IsActive = obls.IsActive,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                         }).ToList(),

               }).ToList<Location>();
            }
            else
                return _dbContext.Locations
                     .Select(m => new Location
                     {
                         Id = m.Id,
                         ContactPersonName = m.ContactPersonName,
                         GlobalTax = m.GlobalTax,
                         TotalCapacity = m.TotalCapacity,
                         UtilityService = m.UtilityService,
                         CreatedBy = m.CreatedBy,
                         CreatedOn = m.CreatedOn,
                         Description = m.Description,
                         IsActive = m.IsActive,
                         AlternateMobileNumber = m.AlternateMobileNumber,
                         Email = m.Email,
                         ModifiedBy = m.ModifiedBy,
                         ModifiedOn = m.ModifiedOn,
                         DepartmentName = m.DepartmentName,
                         LocationStatusId = m.LocationStatusId,
                         LocationAddressId = m.LocationAddressId,
                         FuelProtectType = m.FuelProtectType,

                         LocationName = m.LocationName,

                         TimeZone = m.TimeZone,

                         LocationAddress = (from obls in _dbContext.LocationAddress.Where(x => x.Id == m.LocationAddressId)
                                            select new LocationAddress
                                            {
                                                Id = obls.Id,
                                                AddressLine1 = obls.AddressLine1,
                                                AddressLine2 = obls.AddressLine2,

                                                //CityId = obls.CityId,
                                                CityName = obls.CityName,
                                                CountryId = obls.CountryId,
                                                CountryName = obls.CountryName,
                                                CreatedBy = obls.CreatedBy,
                                                CreatedOn = obls.CreatedOn,
                                                IsActive = obls.IsActive,
                                                LandlineNumber = obls.LandlineNumber,
                                                Latitude = obls.Latitude,
                                                Longitude = obls.Longitude,
                                                ModifiedBy = obls.ModifiedBy,
                                                ModifiedOn = obls.ModifiedOn,
                                                PinCode = obls.PinCode,
                                                StateId = obls.StateId,
                                                StateName = obls.StateName
                                            }).FirstOrDefault(),

                         LocationStatus = (from obls in _dbContext.LocationStatus.Where(x => x.Id == m.LocationStatusId)
                                           select new LocationStatus
                                           {
                                               Id = obls.Id,
                                               LocationStatusName = obls.LocationStatusName,
                                               CreatedBy = obls.CreatedBy,
                                               CreatedOn = obls.CreatedOn,
                                               IsActive = obls.IsActive,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                           }).FirstOrDefault(),                         

                         LocationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == m.Id)
                                             select new LocationSchedule
                                             {
                                                 Day = obls.Day,
                                                 StartTime = obls.StartTime,
                                                 EndTime = obls.EndTime,
                                                 CreatedBy = obls.CreatedBy,
                                                 CreatedOn = obls.CreatedOn,
                                                 Id = obls.Id,
                                                 LocationId = obls.LocationId,
                                                 IsActive = obls.IsActive,
                                                 ModifiedBy = obls.ModifiedBy,
                                                 ModifiedOn = obls.ModifiedOn,
                                                 IsOpenAlldays = obls.IsOpenAlldays
                                             }).ToList(),
                         OperatorUserMapper = (from obls in _dbContext.OperatorUserMapper.Where(x => x.LocationId == m.Id)
                                               select new OperatorUserMapper
                                               {
                                                   UserId = obls.UserId,
                                                   CreatedBy = obls.CreatedBy,
                                                   CreatedOn = obls.CreatedOn,
                                                   Id = obls.Id,
                                                   LocationId = obls.LocationId,
                                                   IsActive = obls.IsActive,
                                                   ModifiedBy = obls.ModifiedBy,
                                                   ModifiedOn = obls.ModifiedOn,
                                               }).ToList(),

                     }).ToList<Location>();

        }

        public async Task<Location> GetByIdLocation(long locationId)
        {
            return _dbContext.Locations.Where(t => t.Id == locationId)
                 .Select(m => new Location
                 {
                     Id = m.Id,
                     ContactPersonName = m.ContactPersonName,
                     ContactPersonNumber = m.ContactPersonNumber,
                     GlobalTax = m.GlobalTax,
                     TotalCapacity = m.TotalCapacity,
                     UtilityService = m.UtilityService,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     Description = m.Description,
                     Email = m.Email,
                     AlternateMobileNumber = m.AlternateMobileNumber,
                     IsActive = m.IsActive,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     DepartmentName = m.DepartmentName,
                     LocationStatusId = m.LocationStatusId,
                     LocationAddressId = m.LocationAddressId,
                     FuelProtectType = m.FuelProtectType,
                     LocationId = m.LocationId,
                     LocationName = m.LocationName,

                     TimeZone = m.TimeZone,

                     LocationAddress = (from obls in _dbContext.LocationAddress.Where(x => x.Id == m.LocationAddressId)
                                        select new LocationAddress
                                        {
                                            Id = obls.Id,
                                            AddressLine1 = obls.AddressLine1,
                                            AddressLine2 = obls.AddressLine2,
                                            //CityId = obls.CityId,
                                            CityName = obls.CityName,
                                            CountryId = obls.CountryId,
                                            CountryName = obls.CountryName,
                                            CreatedBy = obls.CreatedBy,
                                            CreatedOn = obls.CreatedOn,
                                            IsActive = obls.IsActive,
                                            LandlineNumber = obls.LandlineNumber,
                                            Latitude = obls.Latitude,
                                            Longitude = obls.Longitude,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,
                                            PinCode = obls.PinCode,
                                            StateId = obls.StateId,
                                            StateName = obls.StateName
                                        }).FirstOrDefault(),

                     LocationStatus = (from obls in _dbContext.LocationStatus.Where(x => x.Id == m.LocationStatusId)
                                       select new LocationStatus
                                       {
                                           Id = obls.Id,
                                           LocationStatusName = obls.LocationStatusName,
                                           CreatedBy = obls.CreatedBy,
                                           CreatedOn = obls.CreatedOn,
                                           IsActive = obls.IsActive,
                                           ModifiedBy = obls.ModifiedBy,
                                           ModifiedOn = obls.ModifiedOn,

                                       }).FirstOrDefault(),
                     LocationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == m.Id)
                                         select new LocationSchedule
                                         {
                                             Day = obls.Day,
                                             StartTime = obls.StartTime,
                                             EndTime = obls.EndTime,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             Id = obls.Id,
                                             LocationId = obls.LocationId,
                                             IsActive = obls.IsActive,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                             IsOpenAlldays=obls.IsOpenAlldays
                                         }).ToList(),
                     OperatorUserMapper = (from obls in _dbContext.OperatorUserMapper.Where(x => x.LocationId == m.Id)
                                           select new OperatorUserMapper
                                           {
                                               UserId = obls.UserId,
                                               CreatedBy = obls.CreatedBy,
                                               CreatedOn = obls.CreatedOn,
                                               Id = obls.Id,
                                               LocationId = obls.LocationId,
                                               IsActive = obls.IsActive,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                           }).ToList()

                 }).Where(m => m.Id == locationId).FirstOrDefault();

            //}).FirstOrDefault();


        }

        public Task<List<LocationsDispenser>> GetLocationsDispenserformap(List<long> Id)
        {
            // return null
            List<LocationsDispenser> result = new List<LocationsDispenser>();
            if (Id.Count <= 0 || Id == null)
            {
                result = (from location in _dbContext.Locations
                          join charger in _dbContext.Charger
                          on location.Id equals charger.LocationId
                          join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                          on location.Id equals userMap.LocationId
                          select new LocationsDispenser
                          {
                              CityName = location.LocationAddress.CityName,
                              CountryName = location.LocationAddress.CountryName,
                              StateName = location.LocationAddress.StateName,
                              locationId = location.Id,
                              Latitude = location.LocationAddress.Latitude,
                              Longitude = location.LocationAddress.Longitude,
                              LocationName = location.LocationName,
                              DispenserId = charger.Id,
                              ChargeBoxid = charger.ChargeBoxId,
                              status = charger.ChargerStatuses == null || charger.ChargerStatuses.Count == 0 ? "Offline" :
                                charger.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("suspendedev", "Busy").Replace("uspendedevse", "Busy")
                              .Replace("finishing", "Busy").Replace("preparing", "Busy"),

                          }).ToList<LocationsDispenser>();
            }
            else
            {
                result = (from location in _dbContext.Locations.Where(x => Id.Contains(x.Id))
                          join charger in _dbContext.Charger
                          on location.Id equals charger.LocationId
                          join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                         on location.Id equals userMap.LocationId
                          select new LocationsDispenser
                          {
                              CityName = location.LocationAddress.CityName,
                              CountryName = location.LocationAddress.CountryName,
                              StateName = location.LocationAddress.StateName,
                              locationId = location.Id,
                              Latitude = location.LocationAddress.Latitude,
                              Longitude = location.LocationAddress.Longitude,
                              LocationName = location.LocationName,
                              DispenserId = charger.Id,
                              status = charger.ChargerStatuses == null || charger.ChargerStatuses.Count == 0 ? "Offline" :
                               charger.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("suspendedev", "Busy").Replace("uspendedevse", "Busy")
                              .Replace("finishing", "Busy").Replace("preparing", "Busy"),
                              ChargeBoxid = charger.ChargeBoxId
                          }).ToList<LocationsDispenser>();
            }


            return Task.FromResult(result);
        }

        public Task<PagedList<LocationsDispenserDetails>> GetLocationsDispenserDetails(LocationDispenserRequest locationDispenserRequest)
        {
            List<LocationsDispenserDetails> result = new List<LocationsDispenserDetails>();
            if (locationDispenserRequest.LocationIds.Count <= 0 || locationDispenserRequest.LocationIds == null)
            {
                result = (from location in (locationDispenserRequest.SearchParam==null && locationDispenserRequest.SearchParam=="")? _dbContext.Locations:
                           _dbContext.Locations.Where(d => d.LocationName.ToLower().Contains(locationDispenserRequest.SearchParam.ToLower()))
                          join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                         on location.Id equals userMap.LocationId
                          select new LocationsDispenserDetails
                          {
                              Address = location.LocationAddress.AddressLine1 + " " + location.LocationAddress.AddressLine2,

                              locationId = location.Id,

                              CreatedOn = location.CreatedOn,

                              LocationName = location.LocationName,

                              status = location.LocationStatus.LocationStatusName,
                              NoofPort = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id)
                                          join port in _dbContext.Port
                              on charger.Id equals port.ChargerId
                                          select new Port
                                          {
                                              ChargerId = charger.Id
                                          }).ToList<Port>().Count.ToString(),
                              Available = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id && x.ChargerStatuses != null && x.ChargerStatuses.ToList().Count > 0)
                                           join Status in _dbContext.ChargerStatuses.Where(s => s.ConnectorStatus== "Available")
                              on charger.Id equals Status.ChargerId   //"Available")
                                           select new LocationsDispenserStatus
                                           {
                                               Id = charger.Id,
                                               Status= charger.ChargerStatuses.ToList()[0].ConnectorStatus
                                           }
                                           ).ToList()
                                           .Count.ToString(),
                              Connected = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id && x.ChargerStatuses != null && x.ChargerStatuses.ToList().Count > 0)
                                           join Status in _dbContext.ChargerStatuses.Where(s => s.ConnectorStatus == "Unavailable")
                                            on charger.Id equals Status.ChargerId
                                           select new LocationsDispenserStatus
                                           {
                                               Id = charger.Id,
                                               Status = charger.ChargerStatuses.ToList()[0].ConnectorStatus
                                           }
                                           ).ToList()
                                           .Count.ToString(),
                              Faulted = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id && x.ChargerStatuses != null && x.ChargerStatuses.ToList().Count > 0)
                                         join Status in _dbContext.ChargerStatuses.Where(s => s.ConnectorStatus == "Faulted")
                                          on charger.Id equals Status.ChargerId
                                         select new LocationsDispenserStatus
                                         {
                                             Id = charger.Id,
                                             Status = charger.ChargerStatuses.ToList()[0].ConnectorStatus
                                         }
                                           ).ToList()
                                           .Count.ToString(),
                              ContactNo = location.ContactPersonNumber.ToString(),
                              ContactName = location.ContactPersonName.ToString(),

                          }).ToList<LocationsDispenserDetails>();
            }
            else
            {
                result = (from location in (locationDispenserRequest.SearchParam == null && locationDispenserRequest.SearchParam == "") ? _dbContext.Locations.Where(x => locationDispenserRequest.LocationIds.Contains(x.Id)) :
                           _dbContext.Locations.Where(d => d.LocationName.ToLower().Contains(locationDispenserRequest.SearchParam.ToLower()) && locationDispenserRequest.LocationIds.Contains(d.Id))

                          join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                         on location.Id equals userMap.LocationId
                          select new LocationsDispenserDetails
                          {
                              Address = location.LocationAddress.AddressLine1 + " " + location.LocationAddress.AddressLine2,

                              locationId = location.Id,

                              LocationName = location.LocationName,
                              CreatedOn = location.CreatedOn,

                              status = location.LocationStatus.LocationStatusName,
                              NoofPort = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id)
                                          join port in _dbContext.Port
                              on charger.Id equals port.ChargerId
                                          select new Port
                                          {
                                              ChargerId = charger.Id
                                          }).ToList<Port>().Count.ToString(),
                              Available = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id && x.ChargerStatuses != null && x.ChargerStatuses.ToList().Count > 0)
                                           join Status in _dbContext.ChargerStatuses.Where(s => s.ConnectorStatus == "Available")
                              on charger.Id equals Status.ChargerId   //"Available")
                                           select new LocationsDispenserStatus
                                           {
                                               Id = charger.Id,
                                               Status = charger.ChargerStatuses.ToList()[0].ConnectorStatus
                                           }
                                           ).ToList()
                                           .Count.ToString(),
                              Connected = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id && x.ChargerStatuses != null && x.ChargerStatuses.ToList().Count > 0)
                                           join Status in _dbContext.ChargerStatuses.Where(s => s.ConnectorStatus == "Unavailable")
                                            on charger.Id equals Status.ChargerId
                                           select new LocationsDispenserStatus
                                           {
                                               Id = charger.Id,
                                               Status = charger.ChargerStatuses.ToList()[0].ConnectorStatus
                                           }
                                           ).ToList()
                                           .Count.ToString(),
                              Faulted = (from charger in _dbContext.Charger.Where(x => x.LocationId == location.Id && x.ChargerStatuses != null && x.ChargerStatuses.ToList().Count > 0)
                                         join Status in _dbContext.ChargerStatuses.Where(s => s.ConnectorStatus == "Faulted")
                                          on charger.Id equals Status.ChargerId
                                         select new LocationsDispenserStatus
                                         {
                                             Id = charger.Id,
                                             Status = charger.ChargerStatuses.ToList()[0].ConnectorStatus
                                         }
                                           ).ToList()
                                           .Count.ToString(),
                              ContactNo = location.ContactPersonNumber.ToString(),
                              ContactName = location.ContactPersonName.ToString(),


                          }).ToList<LocationsDispenserDetails>();
            }
            result = result != null ? result.OrderByDescending(a => a.locationId).ToList() : result;
            
            //Paging on Records           

            var dataResult = PagedList<LocationsDispenserDetails>.ToPagedList(result,
              locationDispenserRequest.PageNumber,
              locationDispenserRequest.PageSize);
            return Task.FromResult(dataResult);
        }
        public async Task<List<Core.Response.LocationData>> GetAllLocationName()
        {

            return _dbContext.Locations
                 .Select(m => new Core.Response.LocationData
                 {
                     Id = m.Id,
                     LocationName = m.LocationName
                 }).Where(m => m.LocationName != "").OrderBy(m => m.LocationName).ToList<Core.Response.LocationData>();
        }
        public Task<List<LocationDispenserForLocation>> GetLocationsDispenserForLocation(List<long> Id)
        {
            List<LocationDispenserForLocation> result = new List<LocationDispenserForLocation>();
            if (Id.Count <= 0)
            {
                result = (from location in _dbContext.Locations
                          join charger in _dbContext.Charger
                          on location.Id equals charger.LocationId
                          join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                          on location.Id equals userMap.LocationId
                          select new LocationDispenserForLocation
                          {
                              locationId = location.Id,
                              DispenserId = charger.Id,
                              ChargeBoxId = charger.ChargeBoxId,
                              ProtocolName = charger.ProtocolName,
                              ChargerStatus = charger.ChargerStatuses == null || charger.ChargerStatuses.Count == 0 ? "Offline" :
                               charger.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("suspendedev", "Busy").Replace("uspendedevse", "Busy")
                              .Replace("finishing", "Busy").Replace("preparing", "Busy"),
                              NoofPort = charger.Ports.Where(t => t.ChargerId.Equals(charger.Id)).ToList().Count == 0 ? "0" : charger.Ports.Where(t => t.ChargerId.Equals(charger.Id)).ToList().Count.ToString(),
                              DispenserMake = charger.MakeName,
                              DispenserModel = charger.ModelName,
                              ConnectorType = _dbContext.Port.FirstOrDefault(p => p.ChargerId == charger.Id).Connector.ConnectorType,
                              
                          }).ToList<LocationDispenserForLocation>();
            }
            else
            {
                result = (from location in _dbContext.Locations.Where(x => Id.Contains(x.Id))
                          join charger in _dbContext.Charger
                          on location.Id equals charger.LocationId
                          join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                          on location.Id equals userMap.LocationId
                          select new LocationDispenserForLocation
                          {
                              locationId = location.Id,
                              DispenserId = charger.Id,
                              ChargeBoxId = charger.ChargeBoxId,
                              ProtocolName = charger.ProtocolName,
                              ChargerStatus = charger.ChargerStatuses == null || charger.ChargerStatuses.Count == 0 ? "Offline" :
                                charger.ChargerStatuses.ToList()[0].ChargerStatus1.Replace("charging", "Busy").Replace("suspendedev", "Busy").Replace("uspendedevse", "Busy")
                              .Replace("finishing", "Busy").Replace("preparing", "Busy"),
                              NoofPort = charger.Ports.Where(t => t.ChargerId.Equals(charger.Id)).ToList().Count == 0 ? "0" : charger.Ports.Where(t => t.ChargerId.Equals(charger.Id)).ToList().Count.ToString(),
                              DispenserMake = charger.MakeName,
                              DispenserModel = charger.ModelName,
                              ConnectorType = _dbContext.Port.FirstOrDefault(p => p.ChargerId == charger.Id).Connector.ConnectorType,
                             
                          }).ToList<LocationDispenserForLocation>();
            }
            return Task.FromResult(result);
        }

        public async Task<Locationalist> GetLocationList(LocationListRequst LocationListRequst)
        {
            Locationalist locationalist = new Locationalist();
            List<LocationsData> result = new List<LocationsData>();
            result = await (from location in string.IsNullOrEmpty(LocationListRequst.SearchParam) ? _dbContext.Locations : _dbContext.Locations.Where(d => d.LocationName.ToLower().Contains(LocationListRequst.SearchParam.ToLower()))
                            join address in _dbContext.LocationAddress
                            on location.LocationAddressId equals address.Id
                            join Status in _dbContext.LocationStatus
                            on location.LocationStatusId equals Status.Id
                            select new LocationsData
                            {
                                Id = location.Id,
                                LocationId = location.LocationId,
                                ContactPersonName = location.ContactPersonName,
                                ContactPersonNumber = location.ContactPersonNumber,
                                TotalCapacity = location.TotalCapacity,
                                UtilityService = location.UtilityService,
                                Description = location.Description,
                                LocationName = location.LocationName,
                                AddressLine1 = address.AddressLine1,
                                AddressLine2 = address.AddressLine2,
                                LocationStatusName = Status.LocationStatusName,
                                Latitude = address.Latitude,
                                Longitude = address.Longitude,
                                CityName = address.CityName,
                                CountryName = address.CountryName,
                                StateName = address.StateName,
                                NumberOfCharger = _dbContext.Charger.Where(x => x.LocationId == location.Id).AsQueryable().Count(),
                                PinCode = address.PinCode,
                                ModifiedOn = location.ModifiedOn,
                                IsActive = location.IsActive,
                                locationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == location.Id)
                                                    select new LocationSchedule
                                                    {
                                                        Day = obls.Day,
                                                        StartTime = obls.StartTime,
                                                        EndTime = obls.EndTime,
                                                        CreatedBy = obls.CreatedBy,
                                                        CreatedOn = obls.CreatedOn,
                                                        Id = obls.Id,
                                                        LocationId = obls.LocationId,
                                                        IsActive = obls.IsActive,
                                                        ModifiedBy = obls.ModifiedBy,
                                                        ModifiedOn = obls.ModifiedOn,
                                                        IsOpenAlldays = obls.IsOpenAlldays
                                                    }).ToList(),
                            }).OrderByDescending(a => a.ModifiedOn).ToListAsync();
            locationalist.data = PagedList<LocationsData>.ToPagedList(result,
            LocationListRequst.PageNumber,
            LocationListRequst.PageSize);
            locationalist.TotalLocation = _dbContext.Locations.Count().ToString(); //result.Count().ToString();
            locationalist.Live = _dbContext.Locations.Where(m => m.LocationStatus.LocationStatusName == "Live").Count().ToString();//result.Where(m => m.LocationStatusName == "Live").Count().ToString();
            locationalist.UnderMaintenance = _dbContext.Locations.Where(m => m.LocationStatus.LocationStatusName == "Under Maintenance").Count().ToString();//result.Where(m => m.LocationStatusName == "Under Maintenance").Count().ToString();
            locationalist.Upcomming = _dbContext.Locations.Where(m => m.LocationStatus.LocationStatusName == "Upcoming").Count().ToString();//result.Where(m => m.LocationStatusName == "Upcoming").Count().ToString();
            return (locationalist);
        }

        public async Task<List<AllLocationStatuss>> GetAllLocationStatus()
        {
            List<AllLocationStatuss> result = new List<AllLocationStatuss>();
            result = _dbContext.LocationStatus
                                         .Select(obls => new AllLocationStatuss
                                         {
                                             Id = obls.Id,
                                             LocationStatusName = obls.LocationStatusName,
                                         }).Where(m => m.LocationStatusName != "").OrderBy(m => m.LocationStatusName).ToList();
            return (result);
        }

        public async Task<Location> CreateLocation(Location location)
        {
            try
            {
                _dbContext.Locations.Add(location);
                _dbContext.SaveChanges();
                //  return (location);

            }
            catch (Exception ex)
            {

                // return (ex.Message.ToString());

            }
            return (location);

        }

        public async Task<List<AllDepartmentList>> GetAllDepartmentList()
        {
            List<AllDepartmentList> result = new List<AllDepartmentList>();
            result = _dbContext.Department
                                         .Select(obls => new AllDepartmentList
                                         {
                                             Id = obls.Id,
                                             DepartmentName = obls.DepartmentName

                                         }).Where(m => m.DepartmentName != "").OrderBy(m => m.DepartmentName).ToList();
            return (result);
        }

        public async Task<Location> UpdateLocation(Location location)
        {
            try
            {

                Location oldLocation = _dbContext.Locations.Find(location.Id);
                oldLocation.LocationAddress = _dbContext.LocationAddress.Where(x => x.Id == oldLocation.LocationAddressId).FirstOrDefault();
                oldLocation.DepartmentName = location.DepartmentName;
                oldLocation.LocationStatusId = location.LocationStatusId;
                oldLocation.ContactPersonName = location.ContactPersonName;
                oldLocation.ContactPersonNumber = location.ContactPersonNumber;
                // oldLocation.Department = location.Department;
                oldLocation.Description = location.Description;
                oldLocation.LocationName = location.LocationName;
                oldLocation.Email = location.Email;
                oldLocation.TotalCapacity = location.TotalCapacity;
                oldLocation.LocationId = location.LocationId;
                oldLocation.UtilityService = location.UtilityService;
                oldLocation.ModifiedBy = location.ModifiedBy;
                oldLocation.ModifiedOn = DateTime.Now;
                oldLocation.LocationAddress.Id = location.LocationAddressId;
                oldLocation.LocationAddress.PinCode = location.LocationAddress.PinCode;
                oldLocation.LocationAddress.AddressLine1 = location.LocationAddress.AddressLine1;
                oldLocation.LocationAddress.AddressLine2 = location.LocationAddress.AddressLine2;
                oldLocation.LocationAddress.Latitude = location.LocationAddress.Latitude;
                oldLocation.LocationAddress.Longitude = location.LocationAddress.Longitude;
                oldLocation.LocationAddress.CityName = location.LocationAddress.CityName;
                oldLocation.LocationAddress.StateName = location.LocationAddress.StateName;
                oldLocation.LocationAddress.CountryName = location.LocationAddress.CountryName;
                oldLocation.LocationAddress.StateId = location.LocationAddress.StateId;
                oldLocation.LocationAddress.CountryId = location.LocationAddress.CountryId;
                oldLocation.LocationAddress.ModifiedBy = location.LocationAddress.ModifiedBy;
                
                oldLocation.LocationAddress.ModifiedOn = DateTime.Now;
                for (int i = 0; i < location.LocationSchedule.Count(); i++)
                {
                    LocationSchedule oldLocationSchedule = _dbContext.LocationSchedule.Find(location.LocationSchedule.ToList()[i].Id);
                    if (oldLocationSchedule != null)
                    {
                        LocationSchedule newls = location.LocationSchedule.ToList()[i];
                        oldLocationSchedule.Day = newls.Day;
                        oldLocationSchedule.ModifiedBy = newls.ModifiedBy;
                        oldLocationSchedule.ModifiedOn = DateTime.Now;
                        oldLocationSchedule.StartTime = newls.StartTime;
                        oldLocationSchedule.EndTime = newls.EndTime;
                        oldLocationSchedule.IsOpenAlldays = newls.IsOpenAlldays;
                    }
                }
               _dbContext.Update(oldLocation);                
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
            }
            return (location);
        }
    }
}
