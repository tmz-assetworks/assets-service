using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetByIdRfIdReaderQuery : IRequest<RFIDReaderDetails>
    {
        public long Id { get; set; }
        public GetByIdRfIdReaderQuery(int id)
        {
            Id = id;
        }
    }
}
