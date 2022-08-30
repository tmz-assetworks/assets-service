using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class CountryRepository : Repository<CountryData>, ICountryRepository
    {
        public CountryRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext) : base(_dbContext)
        {

        }

        public async Task<List<CountryData>> GetAllCountry()
        {
            List<CountryData> res = new List<CountryData>();

            res = (from v in _dbContext.Country
                   select new CountryData
                   {
                       Id = v.Id,
                       CountryName = v.CountryName,
                       CreatedBy = v.CreatedBy,
                       CreatedOn = v.CreatedOn,
                       ModifiedBy = v.ModifiedBy,
                       ModifiedOn = v.ModifiedOn,
                       StateData = (from s in _dbContext.State.Where(x => x.CountryId == v.Id)
                                    select new StateData
                                    {
                                        Id = s.Id,
                                        CountryId = s.CountryId,
                                        StateName = s.StateName,
                                        CreatedBy = s.CreatedBy,
                                        CreatedOn = s.CreatedOn,
                                        ModifiedBy = s.ModifiedBy,
                                        ModifiedOn = s.ModifiedOn,
                                        CityData = (from c in _dbContext.City.Where(x => x.StateId == s.Id)
                                                    select new CityData
                                                    {
                                                        Id = c.Id,
                                                        StateId = c.StateId,
                                                        CityName = c.CityName,
                                                        CreatedBy = c.CreatedBy,
                                                        CreatedOn = c.CreatedOn,
                                                        ModifiedBy = c.ModifiedBy,
                                                        ModifiedOn = c.ModifiedOn,

                                                    }).ToList(),
                                    }).ToList(),
                   }).ToList();

            return res;
        }

        public async Task<List<StateData>> GetStateByCountryId(long id)
        {
            return await Task.Factory.StartNew<List<StateData>>(() =>
             {
                 return (from country in _dbContext.Country
                         join state in _dbContext.State on country.Id equals state.CountryId
                         select new StateData
                         {
                             Id = state.Id,
                             CountryId = state.CountryId,
                             StateName = state.StateName,
                             CreatedBy = state.CreatedBy,
                             CreatedOn = state.CreatedOn,
                             ModifiedBy = state.ModifiedBy,
                             ModifiedOn = state.ModifiedOn,
                         }).ToList<StateData>();
             });
        }

        public async Task<List<CityData>> GetCityByStateId(long id)
        {
             return await Task.Factory.StartNew<List<CityData>>(() =>
             {
                 return (from state in _dbContext.State
                         join city in _dbContext.City on state.Id equals city.StateId
                         select new CityData
                         {
                             Id = city.Id,
                             StateId = city.StateId,
                             CityName = city.CityName,
                             CreatedBy = city.CreatedBy,
                             CreatedOn = city.CreatedOn,
                             ModifiedBy = city.ModifiedBy,
                             ModifiedOn = city.ModifiedOn,
                         }).ToList<CityData>();
             });
        }
    }
}