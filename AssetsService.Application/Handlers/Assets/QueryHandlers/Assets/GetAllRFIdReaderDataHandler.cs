using AssetsService.Application.Queries;
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
    public class GetAllRFIdReaderDataHandler : IRequestHandler<GetRFIdReaderDataQuery, List<AssetsService.Core.Entities.RFIDReader>>
    {
        private readonly IRFIdRepository _rfIdRepository;

        public GetAllRFIdReaderDataHandler(IRFIdRepository rFIdRepository)
        {
            _rfIdRepository = rFIdRepository;
        }
        public async Task<List<AssetsService.Core.Entities.RFIDReader>> Handle(GetRFIdReaderDataQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.RFIDReader>)await _rfIdRepository.GetAllRfIdReaderData(request.rfIdReaderRequest);
        }
    }
}
