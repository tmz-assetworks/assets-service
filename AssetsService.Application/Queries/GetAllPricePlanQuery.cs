using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetAllPricePlanQuery : IRequest<List<AssetsService.Core.Entities.PricePlan>>
    {

    }
}


