using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{

    

    public class GetDispensersDetailHandler : IRequestHandler<GetDispensersDetailQuery, PagedList<DispensersDetail>>
    {
        private readonly IDispenserRepository _dispenserRepo;

        public GetDispensersDetailHandler(IDispenserRepository dispenserRepo)
        {
            this._dispenserRepo = dispenserRepo;
        }

        public async Task<PagedList<DispensersDetail>> Handle(GetDispensersDetailQuery request, CancellationToken cancellationToken)
        {
            return (PagedList<DispensersDetail>)await _dispenserRepo.GetDispensersDetail(request._dispensersDetailRequest);
        }
    }
}
