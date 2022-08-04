using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateModemHandler : IRequestHandler<CreateModemCommand, ModemResponse>
    {
        private readonly IModemRepository _modemRepo;

        public CreateModemHandler(IModemRepository modemRepository)
        {
            _modemRepo = modemRepository;
        }
        public async Task<ModemResponse> Handle(CreateModemCommand request, CancellationToken cancellationToken)
        {
            var modemEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Modem>(request);
            if (modemEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var addModemResponse = await _modemRepo.AddAsync(modemEntitiy);
            var mapModemResponse = Mapper.Mappers.Map<ModemResponse>(addModemResponse);
            return mapModemResponse;
        }
    }
}
