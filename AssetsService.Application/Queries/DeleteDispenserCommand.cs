using MediatR;

namespace AssetsService.Application.Queries
{
    public record DeleteDispenserCommandById(int DispenserId) : IRequest<bool>;
}
