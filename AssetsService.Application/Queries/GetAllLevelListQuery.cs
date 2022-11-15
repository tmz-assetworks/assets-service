using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{
     public class GetAllLevelListQuery  : IRequest<List<AllLevelList>>
    {
    }

}