using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AssetsService.Infrastructure.DBContext.DBContextCore _dbContext;

        public Repository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity, long id, string types)
        {
            throw new NotImplementedException();
        }

        public async Task<T> DeleteDispenserAsync(T entity, long id, string types)
        {
            if (types == "Dispenser")
            {
                Dispenser old = entity as Dispenser;
                Dispenser u = _dbContext.Set<Dispenser>().Find(id);
                u.IsActive = old.IsActive;
                _dbContext.Entry(u);

            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteLocationAsync(T entity, long id, string types)
        {
            if (types == "Location")
            {
                Location old = entity as Location;
                Location u = _dbContext.Set<Location>().Find(id);
                u.IsActive = old.IsActive;
                _dbContext.Entry(u);
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity, long id, string types)

        {

            var entry = _dbContext.Set<T>().Find(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entity;



        }
        public async Task<T> DeleteActiveAsync(T entity, long id, string types)
        {
            if (types.ToLower() == "CABLE".ToLower())
            {
                Cable old = entity as Cable;
                Cable u = _dbContext.Set<Cable>().Find(id);
                u.IsActive = old.IsActive;
                _dbContext.Entry(u);

            }
            else if (types.ToLower() == "VEHICLE".ToLower())
            {
                Vehicle old = entity as Vehicle;
                Vehicle u = _dbContext.Set<Vehicle>().Find(id);
                u.IsActive = old.IsActive;
                _dbContext.Entry(u);

            }
            else if (types.ToLower() == "VEHICLEMAKE".ToLower())
            {
                VehicleMake old = entity as VehicleMake;
                VehicleMake u = _dbContext.Set<VehicleMake>().Find(id);
                u.IsActive = old.IsActive;
                _dbContext.Entry(u);

            }
            else if (types.ToLower() == "MAKEMASTER".ToLower())
            {
                MakeMaster old = entity as MakeMaster;
                MakeMaster u = _dbContext.Set<MakeMaster>().Find(id);
                u.IsActive = old.IsActive;
                _dbContext.Entry(u);

            }
            else if (types.ToLower() == "MODEL".ToLower())
            {
                Model old = entity as Model;
                Model u = _dbContext.Set<Model>().Find(id);
                u.IsActive = old.IsActive;
                _dbContext.Entry(u);

            }
            await _dbContext.SaveChangesAsync();
            return entity;

            
        }
        public async Task<T> UpdateAsync(T entity, long id)
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();

                {
                    var entry = _dbContext.Set<T>().Find(id);
                    _dbContext.Entry(entry).CurrentValues.SetValues(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;


                    return entity;


                }

            }
    }
}
