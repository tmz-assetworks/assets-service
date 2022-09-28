using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses.Assets;

namespace AssetsService.Core.Repositories.Assets
{

    
    public interface ICableRepository : IRepository<AssetsService.Core.Entities.Cable>
    {
        //custom operations here
        //Task<IEnumerable<AssetsService.Core.Entities.Cable>> GetEmployeeById(int cableId);

        Task<PagedList<Cable>> GetAllCable(GetAllCableRequest gtAllCableRequest);
        Task<CableData> GetByIdCable(long id);
        Task<CreateCableResponse> CreateCable(Cable cable);
        Task<Cable>Updatecable(Cable cable);

}}
