using AssetsService.Core.Repositories;
using AssetsService.Core.Entities;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Response;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class MakeMasterRepository : Repository<MakeMaster>, IMakeMasterRepository
    {
        public MakeMasterRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {
#pragma warning disable
        }
        public async Task<List<MakeMaster>> GetAllMakeMaster()
        {
            return await _dbContext.MakeMaster
                 .Select(m => new MakeMaster
                 {
                     Id = m.Id,
                     Name = m.Name,
                     Description = m.Description,
                     IsActive = m.IsActive,
                     CreatedBy = m.CreatedBy,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     CreatedOn = m.CreatedOn == DateTime.MinValue ? DateTime.MinValue : m.CreatedOn,
                 }).Where(m=>m.Name!=null).OrderBy(m=>m.Name).ToListAsync();
        }
        public async Task<MakeMaster> GetAllMakeMasterById(long id)
        {
            return _dbContext.MakeMaster
                 .Select(m => new MakeMaster
                 {
                     Id = m.Id,
                     Name = m.Name,
                     Description = m.Description,
                     IsActive = m.IsActive,
                     CreatedBy = m.CreatedBy,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     CreatedOn = m.CreatedOn == DateTime.MinValue ? DateTime.MinValue : m.CreatedOn,
                 }).Where(x => x.Id == id).FirstOrDefault();
 }
        public async Task<List<MakeMasterList>> GetAllMakeMasterList()
        {

            List<Charger> dsipnser = _dbContext.Charger.ToList();
            var data = _dbContext.Modem.ToList();

            return _dbContext.MakeMaster
                 .Select(m => new Core.Response.MakeMasterList
                 {
                     Id = m.Id,
                     Name = m.Name,
                     IsActive = m.IsActive
                 }).Where(m => m.Name!= "").ToList<Core.Response.MakeMasterList>();
        }
    }
}
