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

            PowerCabinetResponse powerCabinetResponse = new PowerCabinetResponse();
            try
            {
                var PowerCabinetEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.PowerCabinet>(request);
                if (PowerCabinetEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                PowerCabinetEntitiy.ModifiedOn = DateTime.Now;
                var updatePowerCabinet = _PowerCabinetRepo.UpdateAsync(PowerCabinetEntitiy, PowerCabinetEntitiy.Id, "powercabinet");
                powerCabinetResponse = Mapper.Mappers.Map<PowerCabinetResponse>(updatePowerCabinet.Result);
            }
            catch (Exception ex)
            {
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {

                    powerCabinetResponse.Id = -1;
                }
            }
            return powerCabinetResponse;
        }

    }
}


