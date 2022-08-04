using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{


    public class UpdatePowerCabinetHandler : IRequestHandler<UpdatePowerCabinetCommand, PowerCabinetResponse>
    {
        private readonly IPowerCabinetRepository _PowerCabinetRepo;

        public UpdatePowerCabinetHandler(IPowerCabinetRepository PowerCabinetRepository)
        {
            _PowerCabinetRepo = PowerCabinetRepository;
        }


        public async Task<PowerCabinetResponse> Handle(UpdatePowerCabinetCommand request, CancellationToken cancellationToken)
        {
            var PowerCabinetEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.PowerCabinet>(request);
            if (PowerCabinetEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatePowerCabinet = _PowerCabinetRepo.UpdateAsync(PowerCabinetEntitiy, PowerCabinetEntitiy.Id);
            var mapUserResponse = Mapper.Mappers.Map<PowerCabinetResponse>(updatePowerCabinet.Result);
            return mapUserResponse;
        }

    }
}


