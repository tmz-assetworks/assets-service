using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{

    public class VehicleRepository : Repository<AssetsService.Core.Entities.Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {
            #pragma warning disable 
        }
        public async Task<List<Vehicle>> GetAllVehicle()
        {
            return await _dbContext.Vehicle
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
                     vehicleRFIDid = m.vehicleRFIDid,


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

                     VehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.Id == m.vehicleRFIDid)
                                    select new VehicleRFID
                                    {
                                        Id = obls.Id,
                                        Name = obls.Name,
                                        IsActive = obls.IsActive,
                                        CreatedBy = obls.CreatedBy,
                                        CreatedOn = obls.CreatedOn,
                                        ModifiedBy = obls.ModifiedBy,
                                        ModifiedOn = obls.ModifiedOn,

                                    }).FirstOrDefault(),
                 })
                 .ToListAsync();
        }

        public async Task<Vehicle> GetAllVehicleById(long id)
        {
            return  _dbContext.Vehicle
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
                     vehicleRFIDid = m.vehicleRFIDid,


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

                     VehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.Id == m.vehicleRFIDid)
                                    select new VehicleRFID
                                    {
                                        Id = obls.Id,
                                        Name = obls.Name,
                                        IsActive = obls.IsActive,
                                        CreatedBy = obls.CreatedBy,
                                        CreatedOn = obls.CreatedOn,
                                        ModifiedBy = obls.ModifiedBy,
                                        ModifiedOn = obls.ModifiedOn,

                                    }).FirstOrDefault(),
                 }).Where(x => x.Id == id).FirstOrDefault();
                 
        }
    }
}
