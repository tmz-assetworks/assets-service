using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;

namespace AssetsService.Core.Repositories
{
    public interface IRFIdRepository : IRepository<RFIDReader>
    {
       
        Task<RFIDReaderDetails> GetByIdRfIdReader(long rfId);
        Task<PagedList<RFIDReaderDetails>> GetAllRfIdReader(RfIdReaderRequest rfIdReaderRequest);
        Task<List<AssetsService.Core.Entities.RFIDReader>> GetAllRfIdReaderData(RfIdReaderDataRequest rfIdReaderRequest);
        Task<RFIDReader> GetByIdRfIdReaderData(long Id);

    }
}
