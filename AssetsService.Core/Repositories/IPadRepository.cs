using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{  
    public interface IPadRepository : IRepository<AssetsService.Core.Entities.Pad>
    {      
        Task<List<GetPadResponse>> GetAllPad();
        Task<List<ListDropDown>> GetAllPadData(int? dispenserId);
        Task<GetPadResponse> GetPadById(long padId);
    }
}
