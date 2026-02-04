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
                Charger old = entity as Charger;
                Charger u = _dbContext.Set<Charger>().Find(id);
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
                u.ModifiedBy = old.ModifiedBy;
                u.ModifiedOn = DateTime.Now;
                _dbContext.Entry(u);
            }
            await _dbContext.SaveChangesAsync();
            return entity;
        }



        public async Task<T> IsActiveStatusChangeAsync(T entity, long id, string types)
        {
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "vehicle")
            {
                Vehicle old = entity as Vehicle;
                Vehicle updatingEntity = _dbContext.Set<Vehicle>().Find(id);
                if (updatingEntity != null)
                {
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.Now;
                    _dbContext.Entry(updatingEntity);
                }
            }
            else if (!string.IsNullOrEmpty(types) && types.Equals("dispenser", StringComparison.OrdinalIgnoreCase))
            {
                var old = entity as Charger;

                if (id > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }

                var chargerId = (int)id;
                var updatingEntity = await _dbContext.Set<Charger>().FindAsync(chargerId);

                if (updatingEntity != null)
                {
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.UtcNow;
                }
            }


            else
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "rfidreader")
            {
                RFIDReader old = entity as RFIDReader;
                try
                {

                    RFIDReader updatingEntity = _dbContext.Set<RFIDReader>().Find(id);
                    if (updatingEntity != null)
                    {
                        updatingEntity.IsActive = old.IsActive;
                        updatingEntity.ModifiedBy = old.ModifiedBy;
                        updatingEntity.ModifiedOn = DateTime.Now;
                        _dbContext.Entry(updatingEntity);
                    }
                }
                catch
                {
                    old.Id = 0;
                }

            }
            else
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "pad")
            {
                Pad old = entity as Pad;
                try
                {

                    Pad updatingEntity = _dbContext.Set<Pad>().Find(id);
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.Now;
                    _dbContext.Entry(updatingEntity);
                }
                catch
                {
                    old.Id = 0;
                }
            }
            else
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "subscription")
            {
                SubscriptionPlan old = entity as SubscriptionPlan;
                try
                {

                    SubscriptionPlan updatingEntity = _dbContext.Set<SubscriptionPlan>().Find(id);
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.Now;
                    _dbContext.Entry(updatingEntity);
                }
                catch
                {
                    old.Id = 0;
                }
            }
            else
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "powercabinet")
            {
                PowerCabinet old = entity as PowerCabinet;
                try
                {

                    PowerCabinet updatingEntity = _dbContext.Set<PowerCabinet>().Find(id);
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.Now;
                    _dbContext.Entry(updatingEntity);
                }
                catch
                {
                    old.Id = 0;
                }
            }
            else
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "cable")
            {
                Cable old = entity as Cable;
                try
                {

                    Cable updatingEntity = _dbContext.Set<Cable>().Find(id);
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.Now;
                    _dbContext.Entry(updatingEntity);
                }
                catch
                {
                    old.Id = 0;
                }
            }
            else
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "switchgears")
            {
                SwitchGear old = entity as SwitchGear;
                try
                {

                    SwitchGear updatingEntity = _dbContext.Set<SwitchGear>().Find(id);
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.Now;
                    _dbContext.Entry(updatingEntity);
                }
                catch
                {
                    old.Id = 0;
                }
            }
            else
            if (!string.IsNullOrEmpty(types) && types.ToLower() == "modem")
            {
                Modem old = entity as Modem;
                try
                {

                    Modem updatingEntity = _dbContext.Set<Modem>().Find(id);
                    updatingEntity.IsActive = old.IsActive;
                    updatingEntity.ModifiedBy = old.ModifiedBy;
                    updatingEntity.ModifiedOn = DateTime.Now;
                    _dbContext.Entry(updatingEntity);
                }
                catch
                {
                    old.Id = 0;
                }
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
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity, long id, string types)
        {
            if (types == "PAD")
            {
                Pad newPad = entity as Pad;
                try
                {
                    var entry = _dbContext.Set<Pad>().Find(id);

                    newPad.CreatedBy = entry.CreatedBy;
                    newPad.CreatedOn = entry.CreatedOn;

                    _dbContext.Entry(entry).CurrentValues.SetValues(newPad);
                }
                catch (Exception ex)
                {
                    if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                    {
                        newPad.Id = -1;
                    }
                    else
                    {
                        newPad.Id = 0;
                    }
                }

            }
            if (types == "SwitchGear")
            {
                SwitchGear newSwitchGear = entity as SwitchGear;
                try
                {
                    var entry = _dbContext.Set<SwitchGear>().Find(id);

                    newSwitchGear.CreatedBy = entry.CreatedBy;
                    newSwitchGear.CreatedOn = entry.CreatedOn;

                    _dbContext.Entry(entry).CurrentValues.SetValues(newSwitchGear);
                }
                catch (Exception ex)
                {
                    if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                    {
                        newSwitchGear.Id = -1;
                    }
                    else
                    {
                        newSwitchGear.Id = 0;
                    }
                }

            }
            else
                if (types == "powercabinet")
            {
                PowerCabinet newPowerCabinet = entity as PowerCabinet;
                try
                {
                    var entry = _dbContext.Set<PowerCabinet>().Find(id);

                    newPowerCabinet.CreatedBy = entry.CreatedBy;
                    newPowerCabinet.CreatedOn = entry.CreatedOn;

                    _dbContext.Entry(entry).CurrentValues.SetValues(newPowerCabinet);
                }
                catch
                {
                    newPowerCabinet.Id = 0;
                }

            }
            else
                if (types == "modem")
            {
                Modem newModem = entity as Modem;
                try
                {
                    var entry = _dbContext.Set<Modem>().Find(id);

                    newModem.CreatedBy = entry.CreatedBy;
                    newModem.CreatedOn = entry.CreatedOn;

                    _dbContext.Entry(entry).CurrentValues.SetValues(newModem);
                }
                catch
                {
                    newModem.Id = 0;
                }

            }
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
                u.IsActive = false;
                _dbContext.Entry(u);

            }
            else if (types.ToLower() == "VEHICLEMAKE".ToLower())
            {
                VehicleMake old = entity as VehicleMake;
                VehicleMake u = _dbContext.Set<VehicleMake>().Find(id);
                u.IsActive = false;
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
            else if (types.ToLower() == "PAD".ToLower())
            {
                Pad old = entity as Pad;
                Pad u = _dbContext.Set<Pad>().Find(id);
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
            }

        }

    }
}
