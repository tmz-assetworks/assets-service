using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{
     public class GetAllPriceTypeListQuery  : IRequest<List<AllPriceTypeList>>
    {
    }

}