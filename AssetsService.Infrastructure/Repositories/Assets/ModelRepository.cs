using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssetsService.Core.Response.ModelResponse;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class ModelRepository : Repository<AssetsService.Core.Entities.Model>, IModelRepository
    {
        public ModelRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {
            #pragma warning disable
        }
        public async Task<List<Model>> GetAllModel()
        {
            return await _dbContext.Model
                 .Select(m => new Model
                 {
                     Id = m.Id,
                     ConnectorCount = m.ConnectorCount,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     IsActive = m.IsActive,
                     ManufactureId = m.ManufactureId,
                     ModelName = m.ModelName,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     Protocol = (from obls in _dbContext.Protocol.Where(x => x.Id == m.ProtocolId)
                                     select new Protocol
                                     {
                                         Id = obls.Id,
                                         ProtocolName = obls.ProtocolName,
                                         IsActive = obls.IsActive,
                                         CreatedBy = obls.CreatedBy,
                                         CreatedOn = obls.CreatedOn,
                                         ModifiedBy = obls.ModifiedBy,
                                         ModifiedOn = obls.ModifiedOn,

                                     }).FirstOrDefault(),
                     Level = (from obls in _dbContext.Level.Where(x => x.Id == m.LevelId)
                                    select new Level
                                    {
                                        Id = obls.Id,
                                        LevelRank = obls.LevelRank,
                                        IsActive = obls.IsActive,
                                        CreatedBy = obls.CreatedBy,
                                        CreatedOn = obls.CreatedOn,
                                        ModifiedBy = obls.ModifiedBy,
                                        ModifiedOn = obls.ModifiedOn,

                                    }).FirstOrDefault(),

                     
                 })
                 .ToListAsync();
        }

        public async Task<List<Model>> GetAllModelData(ModelDataRequest rFIDReaderRequest)
        {
            return _dbContext.Model
                 .Select(m => new Model
                 {
                     Id = m.Id,
                     ModelName = m.ModelName,
                 }).Where(m => m.ModelName != "").OrderBy(m => m.ModelName).ToList();
        }
        public async Task<Model> GetAllModelById(long id)
        {

            return  _dbContext.Model
                 .Select(m => new Model
                 {
                     Id = m.Id,
                     ConnectorCount = m.ConnectorCount,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     IsActive = m.IsActive,
                     ManufactureId = m.ManufactureId,
                     ModelName = m.ModelName,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     Protocol = (from obls in _dbContext.Protocol.Where(x => x.Id == m.ProtocolId)
                                 select new Protocol
                                 {
                                     Id = obls.Id,
                                     ProtocolName = obls.ProtocolName,
                                     IsActive = obls.IsActive,
                                     CreatedBy = obls.CreatedBy,
                                     CreatedOn = obls.CreatedOn,
                                     ModifiedBy = obls.ModifiedBy,
                                     ModifiedOn = obls.ModifiedOn,

                                 }).FirstOrDefault(),
                     Level = (from obls in _dbContext.Level.Where(x => x.Id == m.LevelId)
                              select new Level
                              {
                                  Id = obls.Id,
                                  LevelRank = obls.LevelRank,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),


                 })
                 .Where(x => x.Id == id).FirstOrDefault();

        }
     public async Task<List<ModelList>> GetAllModelList()
        {
            return _dbContext.Model
                 .Select(m => new Core.Response.ModelList
                 {
                     Id = m.Id,
                     ModelName = m.ModelName
                 }).Where(m => m.ModelName != "").OrderBy(m => m.ModelName).ToList<Core.Response.ModelList>();            
        }
    }
}
