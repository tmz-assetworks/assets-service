using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class DeleteDispenserHandler : IRequestHandler<DeleteDispenserCommand, DispenserResponse>
    {
         private readonly IDispenserRepository _DispenserRepo;

        public DeleteDispenserHandler(IDispenserRepository DispenserRepository)
        {
            _DispenserRepo = DispenserRepository;
        }
        public async Task<DispenserResponse> Handle(DeleteDispenserCommand request, CancellationToken cancellationToken)
        {
            var DispenserEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Dispenser>(request);
            if (DispenserEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatedispenser = _DispenserRepo.DeleteDispenserAsync(DispenserEntitiy, DispenserEntitiy.Id,"Dispenser");
            var mapDispenserResponse = Mapper.Mappers.Map<DispenserResponse>(updatedispenser.Result);
            return mapDispenserResponse;
        }
    }
}