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
                     PortId = m.PortId,


                     Port = (from obls in _dbContext.Port.Where(x => x.Id == m.PortId)
                                         select new Port
                                         {
                                             Id = obls.Id,
                                             ConnectorId = obls.ConnectorId,
                                             IsActive = obls.IsActive,
                                             CreatedBy = obls.CreatedBy,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                             CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),
                                             IncrementalPower = obls.IncrementalPower,
                                             MaxPower = obls.MaxPower,
                                             MinPower = obls.MinPower,
                                             PortName = obls.PortName,
                                             Power = obls.Power,
                                             PlugType = (from oblss in _dbContext.PlugType.Where(y => y.Id == obls.PlugTypeId)
                                                     select new PlugType
                                                     {
                                                         Id = obls.Id,
                                                         PlugTypeName = oblss.PlugTypeName,
                                                         IsActive = obls.IsActive,
                                                         CreatedBy = obls.CreatedBy,
                                                         ModifiedBy = obls.ModifiedBy,
                                                         ModifiedOn = obls.ModifiedOn,
                                                         CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),

                                                     }).FirstOrDefault(),

                                         }).FirstOrDefault(),
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
                     PortId = m.PortId,


                     Port = (from obls in _dbContext.Port.Where(x => x.Id == m.PortId)
                             select new Port
                             {
                                 Id = obls.Id,
                                 ConnectorId = obls.ConnectorId,
                                 IsActive = obls.IsActive,
                                 CreatedBy = obls.CreatedBy,
                                 ModifiedBy = obls.ModifiedBy,
                                 ModifiedOn = obls.ModifiedOn,
                                 CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),
                                 IncrementalPower = obls.IncrementalPower,
                                 MaxPower = obls.MaxPower,
                                 MinPower = obls.MinPower,
                                 PortName = obls.PortName,
                                 Power = obls.Power,
                                 PlugType = (from oblss in _dbContext.PlugType.Where(y => y.Id == obls.PlugTypeId)
                                             select new PlugType
                                             {
                                                 Id = obls.Id,
                                                 PlugTypeName = oblss.PlugTypeName,
                                                 IsActive = obls.IsActive,
                                                 CreatedBy = obls.CreatedBy,
                                                 ModifiedBy = obls.ModifiedBy,
                                                 ModifiedOn = obls.ModifiedOn,
                                                 CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),

                                             }).FirstOrDefault(),

                             }).FirstOrDefault(),
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
    }
}
