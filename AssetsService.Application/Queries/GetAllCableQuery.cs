using AssetsService.Core.PagingHelper;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetAllCableQuery : IRequest<PagedList<AssetsService.Core.Entities.Cable>>
    {
        public GetAllCableRequest GtAllCableRequest {get; set;}
        public GetAllCableQuery(GetAllCableRequest getAllCableRequest)
        {
            this.GtAllCableRequest = getAllCableRequest;

        }
        

    }
}
