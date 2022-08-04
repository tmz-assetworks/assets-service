using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetByIdPadQuery : IRequest<Pad>
    {
        public long Id { get; set; }
        public GetByIdPadQuery(int id)
        {
            Id = id;
        }
    }

}
