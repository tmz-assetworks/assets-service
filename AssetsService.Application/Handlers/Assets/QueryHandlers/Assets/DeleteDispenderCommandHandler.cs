using AssetsService.Application.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class DeleteDispenserCommandHandler : IRequestHandler<DeleteDispenserCommandById, bool>
    {
        private readonly IDispenserRepository _repo;
        public DeleteDispenserCommandHandler(IDispenserRepository repo)
        {
            _repo = repo;
        }
        public Task<bool> Handle(DeleteDispenserCommandById request, CancellationToken cancellationToken)
        {
            return _repo.DeleteDispenserById(request.DispenserId);
        }
    }
}
