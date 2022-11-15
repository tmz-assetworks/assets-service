using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetPowerCabinetDataQuery : IRequest<List<GetPowerCabinetResponse>>
    {
        public int? disenserId { get; set; }
        public GetPowerCabinetDataQuery(int?_dispenserId)
        {
            this.disenserId = _dispenserId;
        }
    }
}
