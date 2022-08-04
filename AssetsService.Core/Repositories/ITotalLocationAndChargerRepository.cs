using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{

    public interface ITotalLocationAndChargerRepository : IRepository<TotalLocationAndChargerResponse>
    {
       Task<TotalLocationAndChargerResponse> GetTotalLocationAndCharger();
    }
  
}