using AssetsService.Application.Responses.Assets;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{

       public class GetDispensersDetailQuery : IRequest<PagedList<DispensersDetail>>
    {
        public DispensersDetailRequest _dispensersDetailRequest = null;
        public GetDispensersDetailQuery(DispensersDetailRequest dispensersDetailRequest)
        {
            this._dispensersDetailRequest = dispensersDetailRequest;
        }
    }


    }
