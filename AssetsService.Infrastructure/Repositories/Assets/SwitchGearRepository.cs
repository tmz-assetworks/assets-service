using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.DBContext;
using AssetsService.Infrastructure.Helpers;
using AssetsService.Infrastructure.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class SwitchGearRepository : Repository<SwitchGear>, ISwitchGearRepository
    {
        TokenBase _tokenBase;
        public SwitchGearRepository(DBContextCore _dbContext, TokenBase tokenBase) : base(_dbContext)
        {
            this._tokenBase = tokenBase;
        }
        public async Task<GetSwitchGearResponse> GetSwitchGearById(long Id)
        {
            return _dbContext.SwitchGears
     .Select(m => new GetSwitchGearResponse
     {
         Id = m.Id,
          SwitchGearName = m.SwitchGearName,
           IsActive = m.IsActive,
            CreatedBy = m.CreatedBy,
             CreatedOn = m.CreatedOn,
              ModifiedBy = m.ModifiedBy,
               ModifiedOn = m.ModifiedOn,
               AssetId=m.AssetId,
               LocationId=m.LocationId,
               LocationName=m.Location.LocationName,
               SerialNumber=m.SerialNumber,
               StatusId=m.StatusId,
               StatusName=m.Status.StatusName
               
     }).Where(d=> d.Id == Id).FirstOrDefault();
     }
        public async Task<AllSwitchGearResponse> GetAllSwitchGears(SwitchGearRequest switchGearRequest)
        {
            var results = (from p in _dbContext.SwitchGears
                           select new GetSwitchGearResponse
                           {
                               Id = p.Id,
                               SwitchGearName = p.SwitchGearName,
                               IsActive = p.IsActive,
                               CreatedBy = p.CreatedBy,
                               CreatedOn = p.CreatedOn,
                               ModifiedBy = p.ModifiedBy,
                               ModifiedOn = p.ModifiedOn,
                               AssetId = p.AssetId,
                               LocationId = p.LocationId,
                               LocationName = p.Location.LocationName,
                               SerialNumber = p.SerialNumber,
                               StatusId = p.StatusId,
                               StatusName = p.Status.StatusName,
                           }).ToList();
            var dataResult = PagedList<GetSwitchGearResponse>.ToPagedList(results,
            switchGearRequest.PageNumber,
            switchGearRequest.PageSize);

            AllSwitchGearResponse response = new AllSwitchGearResponse()
            {
                Data = dataResult,
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
        async Task<List<ListSwitchGear>> ISwitchGearRepository.GetSwitchGearDLList(string userId, int? dispenserId)
        {
            var switchGearIds = _dbContext.Charger.Where(m => m.Id != dispenserId.Value).Select(m => m.SwitchGearId).ToList();
            var data = _dbContext.SwitchGears.ToList()
             .Select(m => new ListSwitchGear
             {
                 Id = m.Id,
                 SwitchGearName = m.SwitchGearName,
                 IsActive = m.IsActive,
             }).Where(m => m.SwitchGearName != "").Where(x => switchGearIds.All(switchGearIds => switchGearIds != x.Id)).OrderBy(m => m.SwitchGearName).ToList();
            return data;
        }
    }
}
