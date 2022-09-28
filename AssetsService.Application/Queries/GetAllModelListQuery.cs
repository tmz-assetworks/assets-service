using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{
    public class GetAllModelListQuery  : IRequest<List<ModelList>>
    {
    }
}