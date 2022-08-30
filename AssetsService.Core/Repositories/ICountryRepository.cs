using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses.Assets;

namespace AssetsService.Core.Repositories.Assets
{


    public interface ICountryRepository : IRepository<CountryData>
    {

        Task<List<CountryData>> GetAllCountry();
        Task<List<StateData>> GetStateByCountryId(long id);
        Task<List<CityData>> GetCityByStateId(long id);

    }
}
