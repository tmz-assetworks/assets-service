using AssetsService.Application.Commands.Assets;
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
    public class UpdateModemHandler : IRequestHandler<UpdateModemCommand, ModemResponse>
    {
        private readonly IModemRepository _modemRepo;

        public UpdateModemHandler(IModemRepository modemRepository)
        {
            _modemRepo = modemRepository;
        }


        public async Task<ModemResponse> Handle(UpdateModemCommand request, CancellationToken cancellationToken)
        {
            var modemEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Modem>(request);
            if (modemEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updateModem = _modemRepo.UpdateAsync(modemEntitiy, request.Id, "MODEM");
            var mapModemResponse = Mapper.Mappers.Map<ModemResponse>(updateModem.Result);
            return mapModemResponse;
        }
    }
}

            

