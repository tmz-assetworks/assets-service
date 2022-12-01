using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.Helpers;
using AssetsService.Infrastructure.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{ 
    public class DispenserByLocationIdRepository: Repository<GetDispenserLocationResponse>, IDispenserLocationRepository
    {
        string JSONString = string.Empty;
        TokenBase _tokenBase;
        public DispenserByLocationIdRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext, TokenBase tokenBase) : base(dbContext)
        {
            this._tokenBase = tokenBase;
        }

        public Task<DispenserLocationResponse> AddAsync(DispenserLocationResponse entity)
        {
            throw new NotImplementedException();
        }

        public Task<DispenserLocationResponse> DeleteActiveAsync(DispenserLocationResponse entity, long id, string types)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DispenserLocationResponse entity)
        {
            throw new NotImplementedException();
        }

        public Task<DispenserLocationResponse> DeleteDispenserAsync(DispenserLocationResponse entity, long id, string types)
        {
            throw new NotImplementedException();
        }

        public Task<DispenserLocationResponse> DeleteLocationAsync(DispenserLocationResponse entity, long id, string types)
        {
            throw new NotImplementedException();
        }

        

        public Task<DispenserLocationResponse> GetDispenserByLocationsId(DispenserLocationRequest dispenserLocationRequest)
        {
            List<GetDispenserLocationResponse> query = new List<GetDispenserLocationResponse>();
            DispenserLocationResponse obj = new DispenserLocationResponse();


            if(_tokenBase.getRole().ToLower()=="admin")
            { 
            query = (from location in _dbContext.Locations.Where(x => dispenserLocationRequest.locationIds.Contains(x.Id))
                     join charger in _dbContext.Charger
                     on location.Id equals charger.LocationId
                     select new GetDispenserLocationResponse
                     {
                         Id = charger.Id,
                         LocationId=location.Id,
                         ChargeBoxId = charger.ChargeBoxId + " (" + location.LocationName + ")",
                     }).ToList<GetDispenserLocationResponse>();
            }
            else
            {
                query = (from location in _dbContext.Locations.Where(x => dispenserLocationRequest.locationIds.Contains(x.Id))
                         join charger in _dbContext.Charger
                         on location.Id equals charger.LocationId

                         join userMap in _dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_tokenBase.getObjectId())).FirstOrDefault().Id))
                        on location.Id equals userMap.LocationId
                         select new GetDispenserLocationResponse
                         {
                             Id = charger.Id,
                             LocationId = location.Id,
                             ChargeBoxId = charger.ChargeBoxId,
                         }).ToList<GetDispenserLocationResponse>();
            }
            obj.Data=query;


            return Task.FromResult(obj);
        }

        public Task<DispenserLocationResponse> IsActiveStatusChangeAsync(DispenserLocationResponse entity, long id, string types)
        {
            throw new NotImplementedException();
        }

        public Task<DispenserLocationResponse> UpdateAsync(DispenserLocationResponse entity, long id, string types)
        {
            throw new NotImplementedException();
        }

        public Task<DispenserLocationResponse> UpdateAsync(DispenserLocationResponse entity, long id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<DispenserLocationResponse>> IRepository<DispenserLocationResponse>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<DispenserLocationResponse> IRepository<DispenserLocationResponse>.GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        Task<DispenserLocationResponse> IRepository<DispenserLocationResponse>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
