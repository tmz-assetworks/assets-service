using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdRFIdHandler : IRequestHandler<GetByIdRfIdReaderQuery, AssetsService.Core.Entities.RFIDReader>
    {
        private readonly IRFIdRepository _rFIdRepository;
        public GetByIdRFIdHandler(IRFIdRepository rFIdRepository)
        {
            _rFIdRepository = rFIdRepository;
        }
        public async Task<AssetsService.Core.Entities.RFIDReader> Handle(GetByIdRfIdReaderQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.RFIDReader)await _rFIdRepository.GetByIdRfIdReader(Convert.ToInt32(request.Id));
        }
    }
}
