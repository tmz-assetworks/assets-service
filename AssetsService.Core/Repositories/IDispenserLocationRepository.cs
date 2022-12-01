using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface IDispenserLocationRepository : IRepository<DispenserLocationResponse>
    {
        Task<DispenserLocationResponse> GetDispenserByLocationsId(DispenserLocationRequest dispenserLocationRequest);
    }
}
