

using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;

namespace AssetsService.Core.Repositories.Assets
{
    public interface IPowerCabinetRepository : IRepository<AssetsService.Core.Entities.PowerCabinet>
    {

        Task<GetPowerCabinetResponse> GetPowerCabinetById(long powerCabinetId);
        Task<List<GetPowerCabinetResponse>> GetPowerCabinetData();


    }
}