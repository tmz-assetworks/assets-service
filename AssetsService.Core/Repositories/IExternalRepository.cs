using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface IExternalRepository : IRepository<Vehicle>
    {
        Task<CreateVehicleResponseExternal> CreateNewVehicle(Vehicle vehicle);
    }
}
