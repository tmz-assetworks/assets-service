using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetRFIdReaderDataQuery : IRequest<List<AssetsService.Core.Entities.RFIDReader>>
    {
        public RfIdReaderDataRequest rfIdReaderRequest { get; set; }
        public GetRFIdReaderDataQuery(RfIdReaderDataRequest _rfIdReaderRequest)
        {
            this.rfIdReaderRequest = _rfIdReaderRequest;
        }
    }
}
