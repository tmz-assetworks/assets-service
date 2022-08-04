using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllRFIdHandler : IRequestHandler<GetAllRFIdQuery, List<AssetsService.Core.Entities.RFIDReader>>
    {
        private readonly IRFIdRepository _rfIdRepository;
        public GetAllRFIdHandler(IRFIdRepository rFIdRepository )
        {
            _rfIdRepository = rFIdRepository;
        }

        public async Task<List<RFIDReader>> Handle(GetAllRFIdQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.RFIDReader>)await _rfIdRepository.GetAllRfIdReader();
        }
    }
}
