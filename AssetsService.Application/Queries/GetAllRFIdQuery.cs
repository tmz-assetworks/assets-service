using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetAllRFIdQuery : IRequest<PagedList<RFIDReaderDetails>>
    {
        public RfIdReaderRequest rfIdReaderRequest { get; set; }
        public GetAllRFIdQuery(RfIdReaderRequest _rfIdReaderRequest)
        {
           this.rfIdReaderRequest = _rfIdReaderRequest;
        }
    } 
}
