using System.Dynamic;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;


namespace AssetsService.Infrastructure.Repositories.Assets
{

    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext) : base(_dbContext)
        {

        }
        public async Task<StatusVehicleresponcse> GetAllVehicle(GetAllVehicleRequest getAllVehicleRequest)
        {
            StatusVehicleresponcse statusVehicleresponcse = new StatusVehicleresponcse();
            List<Vehicle> result = new List<Vehicle>();
            try
            {
                if (string.IsNullOrEmpty(getAllVehicleRequest.SearchParam) == true)
                {

                    result = await _dbContext.Vehicle

                      .Select(m => new Vehicle
                      {
                          Id = m.Id,
                          VIN = m.VIN,
                          LicencePlate = m.LicencePlate,
                          Department = m.Department,
                          DomicileLocation = m.DomicileLocation,
                          VehicleMacAddress = m.VehicleMacAddress,
                          IsActive = m.IsActive,
                          CreatedBy = m.CreatedBy,
                          CreatedOn = m.CreatedOn,
                          ModifiedBy = m.ModifiedBy,
                          ModifiedOn = m.ModifiedOn,
                          ModelYear = m.ModelYear,
                          VehicleModelId = m.VehicleModelId,
                          VehicleMakeId = m.VehicleMakeId,

                          VehicleModel = (from obls in _dbContext.VehicleModel.Where(x => x.Id == m.VehicleModelId)
                                          select new VehicleModel
                                          {
                                              Id = obls.Id,
                                              Name = obls.Name,
                                              IsActive = obls.IsActive,
                                              CreatedBy = obls.CreatedBy,
                                              CreatedOn = obls.CreatedOn,
                                              ModifiedBy = obls.ModifiedBy,
                                              ModifiedOn = obls.ModifiedOn,

                                          }).FirstOrDefault(),
                          VehicleMake = (from obls in _dbContext.VehicleMake.Where(x => x.Id == m.VehicleMakeId)
                                         select new VehicleMake
                                         {
                                             Id = obls.Id,
                                             Name = obls.Name,
                                             IsActive = obls.IsActive,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,

                                         }).FirstOrDefault(),

                          vehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.VehicleId == m.Id && x.IsActive == true)
                                         select new VehicleRFID
                                         {
                                             Id = obls.Id,
                                             VehicleId = obls.VehicleId,
                                             Name = obls.Name,
                                             IsActive = obls.IsActive,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,

                                         }).ToList(),
                      })
                     .OrderByDescending(a => a.Id).ToListAsync();


                }
                else
                    result = await _dbContext.Vehicle.Where(d => d.VIN.ToLower().Contains(getAllVehicleRequest.SearchParam.ToLower()))
                          .Select(m => new Vehicle
                          {
                              Id = m.Id,
                              VIN = m.VIN,
                              LicencePlate = m.LicencePlate,
                              Department = m.Department,
                              DomicileLocation = m.DomicileLocation,
                              VehicleMacAddress = m.VehicleMacAddress,
                              IsActive = m.IsActive,
                              CreatedBy = m.CreatedBy,
                              CreatedOn = m.CreatedOn,
                              ModifiedBy = m.ModifiedBy,
                              ModifiedOn = m.ModifiedOn,
                              ModelYear = m.ModelYear,
                              VehicleModelId = m.VehicleModelId,
                              VehicleMakeId = m.VehicleMakeId,
                              VehicleModel = (from obls in _dbContext.VehicleModel.Where(x => x.Id == m.VehicleModelId)
                                              select new VehicleModel
                                              {
                                                  Id = obls.Id,
                                                  Name = obls.Name,
                                                  IsActive = obls.IsActive,
                                                  CreatedBy = obls.CreatedBy,
                                                  CreatedOn = obls.CreatedOn,
                                                  ModifiedBy = obls.ModifiedBy,
                                                  ModifiedOn = obls.ModifiedOn,

                                              }).FirstOrDefault(),
                              VehicleMake = (from obls in _dbContext.VehicleMake.Where(x => x.Id == m.VehicleMakeId)
                                             select new VehicleMake
                                             {
                                                 Id = obls.Id,
                                                 Name = obls.Name,
                                                 IsActive = obls.IsActive,
                                                 CreatedBy = obls.CreatedBy,
                                                 CreatedOn = obls.CreatedOn,
                                                 ModifiedBy = obls.ModifiedBy,
                                                 ModifiedOn = obls.ModifiedOn,

                                             }).FirstOrDefault(),

                              vehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.VehicleId == m.Id && m.IsActive == true)

                                             select new VehicleRFID
                                             {
                                                 Id = obls.Id,
                                                 Name = obls.Name,
                                                 IsActive = obls.IsActive,
                                                 CreatedBy = obls.CreatedBy,
                                                 VehicleId = obls.VehicleId,
                                                 CreatedOn = obls.CreatedOn,
                                                 ModifiedBy = obls.ModifiedBy,
                                                 ModifiedOn = obls.ModifiedOn,

                                             }).ToList(),

                          })
                         .OrderByDescending(a => a.Id).ToListAsync();
            }catch(Exception ex)
            {
                ;
            }
            statusVehicleresponcse.data = PagedList<Vehicle>.ToPagedList(result,
        getAllVehicleRequest.PageNumber,
        getAllVehicleRequest.PageSize);
            statusVehicleresponcse.Active = result.Where(m => m.IsActive == true).Count().ToString();
            statusVehicleresponcse.Inactive = result.Where(m => m.IsActive == false).Count().ToString();
            return (statusVehicleresponcse);
        }
        public async Task<VehicleDTO> GetVehicleById(long Id)
        {
            return _dbContext.Vehicle.Select(m => new VehicleDTO
            {
                Id = m.Id,
                VIN = m.VIN,
                LicencePlate = m.LicencePlate,
                Department = m.Department,
                DomicileLocation = m.DomicileLocation,
                VehicleMacAddress = m.VehicleMacAddress,
                IsActive = m.IsActive,
                //CreatedBy = m.CreatedBy,
                //CreatedOn = m.CreatedOn,
                //ModifiedBy = m.ModifiedBy,
                //ModifiedOn = m.ModifiedOn,
                ModelYear = m.ModelYear,
                VehicleModelId = m.VehicleModelId,
                VehicleMakeId = m.VehicleMakeId,
                //VehicleModelYear = m.VehicleModelYear.Name,
                VehicleModelName = m.VehicleModel.Name,
                VehicleMakeName = m.VehicleMake.Name,
                vehicleRFIDIds = m.vehicleRFID.Select(m => new VehicleRFIDId
                {

                    Id = m.Id,
                    Name = m.Name,
                    IsActive = m.IsActive

                }).ToList(),

            }).Where(m => m.Id == Id).FirstOrDefault();

        }
        public async Task<Vehicle> GetVehicleInfoById(long Id)
        {
            DateTime currentDateTime = DateTime.Now;
            try
            {
                var data = _dbContext.Vehicle
                     .Select(m => new Vehicle
                     {
                         Id = m.Id,
                         VIN = m.VIN,
                         LicencePlate = m.LicencePlate,
                         Department = m.Department,
                         DomicileLocation = m.DomicileLocation,
                         VehicleMacAddress = m.VehicleMacAddress,
                         IsActive = m.IsActive,
                         CreatedBy = m.CreatedBy,
                         CreatedOn = m.CreatedOn,
                         ModifiedBy = m.ModifiedBy,
                         ModifiedOn = m.ModifiedOn,
                         ModelYear = m.ModelYear,
                         VehicleModelId = m.VehicleModelId,
                         VehicleMakeId = m.VehicleMakeId,
                         //CustomerId = m.CustomerId,
                        //  SubscriptionPlanId = m.SubscriptionPlanId,
                         VehicleModel = (from obls in _dbContext.VehicleModel.Where(x => x.Id == m.VehicleModelId)
                                         select new VehicleModel
                                         {
                                             Id = obls.Id,
                                             Name = obls.Name,
                                             IsActive = obls.IsActive,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                         }).FirstOrDefault(),
                         VehicleMake = (from obls in _dbContext.VehicleMake.Where(x => x.Id == m.VehicleMakeId)
                                        select new VehicleMake
                                        {
                                            Id = obls.Id,
                                            Name = obls.Name,
                                            IsActive = obls.IsActive,
                                            CreatedBy = obls.CreatedBy,
                                            CreatedOn = obls.CreatedOn,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,

                                        }).FirstOrDefault(),
                         vehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.VehicleId == m.Id)

                                        select new VehicleRFID
                                        {
                                            Id = obls.Id,
                                            Name = obls.Name,
                                            IsActive = obls.IsActive,
                                            CreatedBy = obls.CreatedBy,
                                            VehicleId = obls.VehicleId,
                                            CreatedOn = obls.CreatedOn,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,
                                        }).ToList(),
                        
                     }).Where(x => x.Id == Id).FirstOrDefault();

                if (data != null)
                {
                    string[] vehicleRFIDs = _dbContext.VehicleRFID.Where(x => x.VehicleId == x.Id && x.IsActive==true).Select(v => v.Name.ToString()).ToArray();

                    data.applicableSubscriptionPlans = new List<ApplicableSubscriptionPlan>();
                    data.applicableSubscriptionPlans = _dbContext.SubscriptionPlan.Where(s => s.SubscriptionsValue == data.ModelYear.ToString() && s.ValidFrom <= currentDateTime && s.ValidTo >= currentDateTime || (s.SubscriptionsValue == data.VehicleModel.Name  && s.ValidFrom <= currentDateTime && s.ValidTo >= currentDateTime)
                    ||( s.SubscriptionsValue == data.VIN && s.ValidFrom <= currentDateTime && s.ValidTo >= currentDateTime) || (s.SubscriptionsValue == data.VehicleMake.Name && s.ValidFrom <= currentDateTime && s.ValidTo >= currentDateTime) || (vehicleRFIDs.Contains(s.SubscriptionsValue)) && s.ValidFrom <= currentDateTime && s.ValidTo >= currentDateTime
                    && s.IsActive == true).Select(s => new ApplicableSubscriptionPlan
                    {
                        RfIdNumbers = data.vehicleRFID != null ? String.Join(',', data.vehicleRFID.Select(s => s.Name)).ToString() : "",
                        SubscriptionPlanName = s.SubscriptionPlanName,
                        SubscriptionsValue = s.SubscriptionsValue,
                        ValidFrom = s.ValidFrom,
                        ValidTo = s.ValidTo,
                        Type = s.SubscriptionPlanType.PlanTypeName,
                    }).ToList();
                }

                return data;
            }
            catch (Exception ex)
            {
                ;
            }
            return new Vehicle();
        }
        public async Task<CreateVehicleResponse> CreateVehicle(Vehicle cv)
        {
            CreateVehicleResponse createVehicleResponse = new CreateVehicleResponse();
            VehicleRFID vehicleRFID = new VehicleRFID();
            try
            {
                //cv.SubscriptionPlanId = 3;  // TODO 
                cv.ModifiedBy = cv.CreatedBy;
                cv.CreatedOn = DateTime.Now;
                cv.ModifiedOn = DateTime.Now;
                cv.IsActive = true;

                _dbContext.Vehicle.Add(cv);
                _dbContext.SaveChanges();
                cv.vehicleRFID = _dbContext.VehicleRFID.Where(r => r.VehicleId == cv.Id).ToList();
                createVehicleResponse.VIN = cv.VIN;
                createVehicleResponse.id = cv.Id;
                return createVehicleResponse;
            }
            catch (Exception ex)
            {
            }
            return createVehicleResponse;
        }

        public async Task<CreateVehicleResponse> UpdateVehicle(Vehicle cv)
        {
            CreateVehicleResponse createVehicleResponse = new CreateVehicleResponse();
            try
            {
                cv.ModifiedOn = DateTime.Now;
                _dbContext.Vehicle.Update(cv);
                _dbContext.SaveChanges();
                cv.vehicleRFID = _dbContext.VehicleRFID.Where(r => r.VehicleId == cv.Id).ToList();
                createVehicleResponse.VIN = cv.VIN;
                createVehicleResponse.id = cv.Id;
                createVehicleResponse.DomicileLocation = cv.DomicileLocation;
                createVehicleResponse.Department = cv.Department;
                createVehicleResponse.VehicleMacAddress = cv.VehicleMacAddress;
                createVehicleResponse.LicencePlate = cv.LicencePlate;
                createVehicleResponse.ModelYear = cv.ModelYear;
                createVehicleResponse.VehicleMakeId = cv.VehicleMakeId;
                createVehicleResponse.VehicleModelId = cv.VehicleModelId;
                createVehicleResponse.ModelYear = cv.ModelYear;
                createVehicleResponse.CreatedBy = cv.CreatedBy;
                createVehicleResponse.CreatedOn = cv.CreatedOn;
                createVehicleResponse.rfids = cv.vehicleRFID.Select(m => new Rfids
                {
                    Id = m.Id,
                    Name = m.Name,
                    IsActive = m.IsActive

                }).ToList();
                return createVehicleResponse;
            }
            catch (Exception ex)
            {
            }
            return createVehicleResponse;
        }

        public async Task<Vehicle> GetByIdVehicleData(long Id)
        {
            return _dbContext.Vehicle.FirstOrDefault(m => m.Id == Id);
        }

        public async Task<VehicleRFID> GetVehicleRFIDDetails(long Id)
        {
            return _dbContext.VehicleRFID.FirstOrDefault(m => m.Id == Id);
        }
        public async Task<VehicleRFID> GetVehicleRFIDDetailsByName(string RfIdName)
        {

            return _dbContext.VehicleRFID.FirstOrDefault(m => m.Name.ToLower() == RfIdName.ToLower());
        }
        public async Task<List<ListDropDown>> GetVehicleModelDDLList()
        {
            var data = _dbContext.VehicleModel.ToList()
               .Select(m => new ListDropDown
               {
                   Id = m.Id,
                   Name = m.Name,
                   IsActive = m.IsActive,
               }).ToList();
            return data;
        }

        public async Task<List<ListDropDown>> GetVehicleModelYearDDLList()
        {
            var data = _dbContext.VehicleModelYear.ToList().Select(m => new ListDropDown

            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive,
            }).ToList();
            return data;
        }
        public async Task<VehicleListData> GetVehicleList(GetAllVehicleRequest getAllVehicleRequest)
        {
            VehicleListData vehicleListData = new VehicleListData();
            List<VehicleDTO> result = new List<VehicleDTO>();
            if (string.IsNullOrEmpty(getAllVehicleRequest.SearchParam) == true)
            {
                result = _dbContext.Vehicle.Select(m => new VehicleDTO
                {
                    Id = m.Id,
                    VIN = m.VIN,
                    LicencePlate = m.LicencePlate,
                    Department = m.Department,
                    DomicileLocation = m.DomicileLocation,
                    VehicleMacAddress = m.VehicleMacAddress,
                    IsActive = m.IsActive,
                    ModifiedOn = m.ModifiedOn,
                    ModelYear = m.ModelYear,
                    VehicleModelId = m.VehicleModelId,
                    VehicleModelName = m.VehicleModel.Name,
                    VehicleMakeId = m.VehicleMakeId,
                    VehicleMakeName = m.VehicleMake.Name,
                    vehicleRFIDName = m.vehicleRFID != null ? String.Join(',', m.vehicleRFID.Where(m => m.IsActive == true).Select(s => s.Name)) : "",

                    vehicleRFIDIds = m.vehicleRFID.Where(m => m.IsActive == true).Select(m => new VehicleRFIDId
                    {
                        Id = m.Id,
                        Name = m.Name,
                        IsActive = m.IsActive
                    }).ToList()
                }).OrderByDescending(m => m.ModifiedOn).ToList<VehicleDTO>();
            }
            else
                result = _dbContext.Vehicle.Where(d => d.VIN.ToLower().Contains(getAllVehicleRequest.SearchParam.ToLower()))

                        .Select(m => new VehicleDTO
                        {
                            Id = m.Id,
                            VIN = m.VIN,
                            LicencePlate = m.LicencePlate,
                            Department = m.Department,
                            DomicileLocation = m.DomicileLocation,
                            VehicleMacAddress = m.VehicleMacAddress,
                            IsActive = m.IsActive,
                            ModifiedOn = m.ModifiedOn,
                            ModelYear = m.ModelYear,                           
                            VehicleModelId = m.VehicleModelId,
                            VehicleModelName = m.VehicleModel.Name,
                            VehicleMakeId = m.VehicleMakeId,
                            VehicleMakeName = m.VehicleMake.Name,
                            vehicleRFIDName = m.vehicleRFID != null ? String.Join(',', m.vehicleRFID.Where(m => m.IsActive == true).Select(s => s.Name)) : "",
                            vehicleRFIDIds = m.vehicleRFID.Where(m => m.IsActive == true).Select(m => new VehicleRFIDId
                            {
                                Id = m.Id,
                                Name = m.Name,
                                IsActive = m.IsActive
                            }).ToList()
                        }).OrderByDescending(m => m.ModifiedOn).ToList<VehicleDTO>();

            var dataResult = PagedList<VehicleDTO>.ToPagedList(result,
         getAllVehicleRequest.PageNumber,
         getAllVehicleRequest.PageSize);
            vehicleListData.data = dataResult;
            vehicleListData.Active = _dbContext.Vehicle.Where(m => m.IsActive == true).Count();
            vehicleListData.InActive = _dbContext.Vehicle.Where(m => m.IsActive == false).Count();
            return vehicleListData;
        }
        public async Task<List<ListDropDown>> GetVehicleMakeDDLList()
        {
            var data = _dbContext.VehicleMake.ToList().Select(m => new ListDropDown
            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive

            }).ToList();
            return data;
        }

    }
}
