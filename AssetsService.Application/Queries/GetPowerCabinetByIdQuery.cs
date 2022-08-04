using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetPowerCabinetByIdQuery : IRequest<PowerCabinet>
    {

        public long Id{get ; set;}
        public GetPowerCabinetByIdQuery(long id)
        {
            Id = id;
        }
    }
}