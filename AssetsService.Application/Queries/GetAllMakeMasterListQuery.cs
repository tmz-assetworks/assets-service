using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{
    public class GetAllMakeMasterListQuery  : IRequest<List<MakeMasterList>>
    {
    }
}