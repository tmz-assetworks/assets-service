using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreatePowerCabinetHandler : IRequestHandler<CreatePowerCabinetCommand, PowerCabinetResponse>
    {
        private readonly IPowerCabinetRepository _powerCabinetRepo;

        public CreatePowerCabinetHandler(IPowerCabinetRepository PowerCabinetRepository)
        {
            _powerCabinetRepo = PowerCabinetRepository;
        }
        public async Task<PowerCabinetResponse> Handle(CreatePowerCabinetCommand request, CancellationToken cancellationToken)
        {
            var PowerCabinetEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.PowerCabinet>(request);
            if (PowerCabinetEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var addPowerCabinetResponse = await _powerCabinetRepo.AddAsync(PowerCabinetEntitiy);
            var mapPowerCabinetResponse = Mapper.Mappers.Map<PowerCabinetResponse>(addPowerCabinetResponse);
            return mapPowerCabinetResponse;
        }

    }
}