using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdRFIdHandler : IRequestHandler<GetByIdRfIdReaderQuery, RFIDReaderDetails>
    {
        private readonly IRFIdRepository _rFIdRepository;
        public GetByIdRFIdHandler(IRFIdRepository rFIdRepository)
        {
            _rFIdRepository = rFIdRepository;
        }
        public async Task<RFIDReaderDetails> Handle(GetByIdRfIdReaderQuery request, CancellationToken cancellationToken)
        {
            return (RFIDReaderDetails)await _rFIdRepository.GetByIdRfIdReader(request.Id);
        }
    }
}
