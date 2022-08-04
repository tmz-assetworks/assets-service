using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
   
    public class GetByIdCablesQuery : IRequest<Cable>
    {
        public long Id { get; set; }
        public GetByIdCablesQuery(int id)
        {
            Id = id;
        }
    }
}
