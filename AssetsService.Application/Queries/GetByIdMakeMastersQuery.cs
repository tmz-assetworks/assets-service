using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetByIdMakeMastersQuery : IRequest<MakeMaster>
    {
        public long Id { get; set; }
        public GetByIdMakeMastersQuery(int id)
        {
            Id = id;
        }
    
    }
}
