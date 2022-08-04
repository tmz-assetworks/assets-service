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
    public class VehicleMakeRepository : Repository<AssetsService.Core.Entities.VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {
                #pragma warning disable
        }
        public async Task<List<VehicleMake>> GetAllVehicleMake()
        {
            return await _dbContext.VehicleMake
                 .Select(m => new VehicleMake
                 {
                     Id = m.Id,
                     Name = m.Name,
                     IsActive = m.IsActive,
                     CreatedBy = m.CreatedBy,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     CreatedOn = (m.CreatedOn == DateTime.MinValue ? DateTime.MinValue : m.CreatedOn),

                 }).ToListAsync();
        }
        public async Task<VehicleMake> GetByIdVehicleMake(long id)
        {
            return  _dbContext.VehicleMake
                 .Select(m => new VehicleMake
                 {
                     Id = m.Id,
                     Name = m.Name,
                     IsActive = m.IsActive,
                     CreatedBy = m.CreatedBy,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     CreatedOn = (m.CreatedOn == DateTime.MinValue ? DateTime.MinValue : m.CreatedOn),

                 }).Where(x => x.Id == id).FirstOrDefault();
        }

       
    }
}
