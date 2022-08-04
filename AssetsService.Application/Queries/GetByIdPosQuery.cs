using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Queries
{
   public class GetByIdPosQuery : IRequest<Pos>
    {
        public long Id { get; set; }
        public GetByIdPosQuery(int id)
        {
            Id = id;
        }
    }
}



