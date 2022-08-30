using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{

    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {
#pragma warning disable
        }
        public async Task<StatusVehicleresponcse> GetAllVehicle(GetAllVehicleRequest getAllVehicleRequest)
        {
            StatusVehicleresponcse statusVehicleresponcse =new StatusVehicleresponcse();
            List<Vehicle> result = new List<Vehicle>();
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
                      VehicleModelYearid = m.VehicleModelYearid,
                      VehicleModelId = m.VehicleModelId,
                      VehicleMakeId = m.VehicleMakeId,

                      VehicleModelYear = (from obls in _dbContext.VehicleModelYear.Where(x => x.Id == m.VehicleModelYearid)
                                          select new VehicleModelYear
                                          {
                                              Id = obls.Id,
                                              Name = obls.Name,
                                              IsActive = obls.IsActive,
                                              CreatedBy = obls.CreatedBy,
                                              ModifiedBy = obls.ModifiedBy,
                                              ModifiedOn = obls.ModifiedOn,
                                              CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),

                                          }).FirstOrDefault(),
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
                          VehicleModelYearid = m.VehicleModelYearid,
                          VehicleModelId = m.VehicleModelId,
                          VehicleMakeId = m.VehicleMakeId,

                          VehicleModelYear = (from obls in _dbContext.VehicleModelYear.Where(x => x.Id == m.VehicleModelYearid)
                                              select new VehicleModelYear
                                              {
                                                  Id = obls.Id,
                                                  Name = obls.Name,
                                                  IsActive = obls.IsActive,
                                                  CreatedBy = obls.CreatedBy,
                                                  ModifiedBy = obls.ModifiedBy,
                                                  ModifiedOn = obls.ModifiedOn,
                                                  CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),

                                              }).FirstOrDefault(),
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

                      })
                     .OrderByDescending(a => a.Id).ToListAsync();
                    // var avtive = result.Where(m => m.IsActive == true).Count().ToString();
             statusVehicleresponcse.data = PagedList<Vehicle>.ToPagedList(result,
         getAllVehicleRequest.PageNumber,
         getAllVehicleRequest.PageSize);
         statusVehicleresponcse.Active = result.Where(m => m.IsActive == true).Count().ToString();
         statusVehicleresponcse.Inactive = result.Where(m => m.IsActive == false).Count().ToString();
            return (statusVehicleresponcse);
        }

        public async Task<Vehicle> GetVehicleById(long id)
        {
            return _dbContext.Vehicle
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
                     VehicleModelYearid = m.VehicleModelYearid,
                     VehicleModelId = m.VehicleModelId,
                     VehicleMakeId = m.VehicleMakeId,
                     //CustomerId = m.CustomerId,
                     SubscriptionPlanCustomerId = m.SubscriptionPlanCustomerId,
                     VehicleModelYear = (from obls in _dbContext.VehicleModelYear.Where(x => x.Id == m.VehicleModelYearid)
                                         select new VehicleModelYear
                                         {
                                             Id = obls.Id,
                                             Name = obls.Name,
                                             IsActive = obls.IsActive,
                                             CreatedBy = obls.CreatedBy,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                             CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),
                                         }).FirstOrDefault(),
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
                     SubscriptionPlan = (from obls in _dbContext.SubscriptionPlan.Where(x => x.CustomerId == m.SubscriptionPlanCustomerId)
                                         select new SubscriptionPlan
                                         {
                                             CustomerId = obls.CustomerId,
                                             SubscriptionPlanName = obls.SubscriptionPlanName,
                                             SubscriptionsDetails = obls.SubscriptionsDetails,
                                             SubscriptionsValue = obls.SubscriptionsValue,
                                             ValidFrom = obls.ValidFrom,
                                             ValidTo = obls.ValidTo,
                                         }).FirstOrDefault(),
                 }).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
