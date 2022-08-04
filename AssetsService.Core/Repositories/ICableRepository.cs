using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;


namespace AssetsService.Core.Repositories.Assets
{

    
    public interface ICableRepository : IRepository<AssetsService.Core.Entities.Cable>
    {
        //custom operations here
        //Task<IEnumerable<AssetsService.Core.Entities.Cable>> GetEmployeeById(int cableId);

        Task<List<Cable>> GetAllCable();
        Task<Cable> GetByIdCable(long id);

}}
