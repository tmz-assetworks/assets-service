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
    public class PadRepository : Repository<AssetsService.Core.Entities.Pad>, IPadRepository
    {
        public PadRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        public async Task<List<Pad>> GetAllPad()
        {
            return await _dbContext.Pads
                 .Select(m => new Pad
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     Description = m.Description,
                     InsertDate = m.InsertDate,
                     Latitude = m.Latitude,
                     Longitude = m.Longitude,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     NetworkId = m.NetworkId,
                     NetworkName = m.NetworkName,
                     PadName = m.PadName,
                     StatusId = m.StatusId,
                     SubNetworkId = m.SubNetworkId,
                     SubNetworkName = m.SubNetworkName,
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == m.StatusId)
                                select new Status
                                {
                                    Id = obls.Id,
                                    StatusName = obls.StatusName,
                                    CreatedBy = obls.CreatedBy,
                                    CreatedOn = obls.CreatedOn,
                                    ModifiedBy = obls.ModifiedBy,
                                    ModifiedOn = obls.ModifiedOn,
                                    IsActive = obls.IsActive,
                                }).FirstOrDefault(),
                 })
                 .ToListAsync();
        }

        public async Task<Pad> GetPadById(long id)
        {
            return _dbContext.Pads
                 .Select(m => new Pad
                 {
                     Id=m.Id,
                     AssetId = m.AssetId,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     Description = m.Description,
                     InsertDate = m.InsertDate,
                     Latitude = m.Latitude,
                     Longitude = m.Longitude,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     NetworkId = m.NetworkId,
                     NetworkName = m.NetworkName,
                     PadName = m.PadName,
                     StatusId = m.StatusId,
                     SubNetworkId = m.SubNetworkId,
                     SubNetworkName = m.SubNetworkName,
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == m.StatusId)
                               select new Status
                               {
                                   Id = obls.Id,
                                   StatusName = obls.StatusName,
                                   CreatedBy = obls.CreatedBy,
                                   CreatedOn = obls.CreatedOn,
                                   ModifiedBy = obls.ModifiedBy,
                                   ModifiedOn = obls.ModifiedOn,
                                   IsActive = obls.IsActive,
                               }).FirstOrDefault(),
                 }).Where(x => x.Id == id).FirstOrDefault();

        }
    } }
