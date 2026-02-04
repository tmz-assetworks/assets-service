using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class IsActiveDispenserHandler : IRequestHandler<IsActiveDispenserCommand, DispenserResponse>
    {
        private readonly IDispenserRepository _DispenserRepo;
        public IsActiveDispenserHandler(IDispenserRepository DispenserRepository)
        {
            _DispenserRepo = DispenserRepository;
        }
        public async Task<DispenserResponse> Handle(IsActiveDispenserCommand request, CancellationToken cancellationToken)
        {
            var DispenserEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Charger>(request);
            if (DispenserEntitiy is null)
            {
                throw new InvalidOperationException("Issue with mapper");
            }

            var updatedispenser = await _DispenserRepo.IsActiveStatusChangeAsync(DispenserEntitiy, DispenserEntitiy.Id, "Dispenser");
            var mapDispenserResponse = Mapper.Mappers.Map<DispenserResponse>(updatedispenser);
            return mapDispenserResponse;
        }
    }
}
