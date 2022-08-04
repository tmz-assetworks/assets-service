using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateDispenserHandler : IRequestHandler<CreateDispenserCommand, DispenserResponse>
    {
        private readonly IDispenserRepository _dispenserRepo;

        public CreateDispenserHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepo = dispenserRepository;
        }
        public async Task<DispenserResponse> Handle(CreateDispenserCommand request, CancellationToken cancellationToken)
        {
            var dispenserEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Dispenser>(request);
            if (dispenserEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            dispenserEntitiy.IsActive = true;//set newly created customer as a active
            var addDispenserResponse = await _dispenserRepo.AddAsync(dispenserEntitiy);
            var mapDispenserResponse = Mapper.Mappers.Map<DispenserResponse>(addDispenserResponse);
            return mapDispenserResponse;
        }

    }
}