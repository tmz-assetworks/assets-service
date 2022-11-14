using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{
     public class GetAllUnitListQuery  : IRequest<List<AllUnitList>>
    {
    }

}