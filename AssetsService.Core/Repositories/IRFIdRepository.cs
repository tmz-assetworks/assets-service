using AssetsService.Core.Repositories.Assets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface IRFIdRepository : IRepository<AssetsService.Core.Entities.RFIDReader>
    {
        Task<List<AssetsService.Core.Entities.RFIDReader>> GetAllRfIdReader();
        Task<AssetsService.Core.Entities.RFIDReader> GetByIdRfIdReader(long rfId);
    }
}
