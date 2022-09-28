using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{
     public class GetAllDepartmentListQuery  : IRequest<List<AllDepartmentList>>
    {
    }

}