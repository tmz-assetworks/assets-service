using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetDispenserDetailByIdQuery : IRequest<GetDispenserResponse>
    {

        public long Id { get; set; }
        public GetDispenserDetailByIdQuery(long id)
        {
            Id = id;
        }
    }
}
