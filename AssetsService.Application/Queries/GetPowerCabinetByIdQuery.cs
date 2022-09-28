using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetPowerCabinetByIdQuery : IRequest<GetPowerCabinetResponse>
    {

        public long Id{get ; set;}
        public GetPowerCabinetByIdQuery(long id)
        {
            Id = id;
        }
    }
}