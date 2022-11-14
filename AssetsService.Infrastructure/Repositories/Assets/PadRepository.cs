using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
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
    public class PadRepository : Repository<AssetsService.Core.Entities.Pad>, IPadRepository
    {
        public PadRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        public async Task<List<GetPadResponse>> GetAllPad()
        {
            return await _dbContext.Pads
                 .Select(m => new GetPadResponse
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     PadName = m.PadName,
                     StatusId = m.StatusId,
                     LocationId = m.LocationId,
                     InstallationDate = m.InstallationDate,
                     IsActive = m.IsActive,
                     SerialNumber = m.SerialNumber,
                     LocationName = m.Location.LocationName,
                     StatusName = m.Status.StatusName

                 }).OrderByDescending(m => m.ModifiedOn)
                 .ToListAsync();
        }
        public async Task<List<ListDropDown>> GetAllPadData(int? dispenserId)
        {
           var dsipnserPadIds = _dbContext.Charger.Where(m => m.Id != dispenserId.Value).Select(m => m.PadId).ToList();
            List<ListDropDown> dataList = _dbContext.Pads
                .Select(m => new ListDropDown
                {
                    Id = m.Id,
                    Name = m.PadName,
                    IsActive = m.IsActive
                }).Where(m => m.Name != "").Where(x => dsipnserPadIds.All(PadId => PadId!=x.Id)).OrderBy(m => m.Name).ToList();
            return dataList;
        }
        public async Task<GetPadResponse> GetPadById(long id)
        {
            return _dbContext.Pads.Where(x => x.Id == id)
                 .Select(m => new GetPadResponse
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     PadName = m.PadName,
                     StatusId = m.StatusId,
                     StatusName = m.Status.StatusName,
                     SerialNumber = m.SerialNumber,
                     InstallationDate = m.InstallationDate,
                     IsActive = m.IsActive,
                     LocationId = m.LocationId,
                     LocationName = m.Location.LocationName

                 }).FirstOrDefault();

        }
    }
}
