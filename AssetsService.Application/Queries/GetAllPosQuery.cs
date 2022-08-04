using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetAllPosQuery : IRequest<List<AssetsService.Core.Entities.Pos>>
    {

    }
}


