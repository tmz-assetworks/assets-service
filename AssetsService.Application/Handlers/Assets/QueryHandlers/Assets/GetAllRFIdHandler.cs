using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
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
    public class GetAllRFIdHandler : IRequestHandler<GetAllRFIdQuery, PagedList<RFIDReaderDetails>>
    {
        private readonly IRFIdRepository _rfIdRepository;
        public GetAllRFIdHandler(IRFIdRepository rFIdRepository)
        {
            _rfIdRepository = rFIdRepository;
        }

        public async Task<PagedList<RFIDReaderDetails>> Handle(GetAllRFIdQuery request, CancellationToken cancellationToken)
        {
            return (PagedList<RFIDReaderDetails>)await _rfIdRepository.GetAllRfIdReader(request.rfIdReaderRequest);
        }
    }

}
