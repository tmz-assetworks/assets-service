using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
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
    public class UpdateModemHandler : IRequestHandler<UpdateModemCommand, Modem>
    {
        private readonly IModemRepository _modemRepo;

        public UpdateModemHandler(IModemRepository modemRepository)
        {
            _modemRepo = modemRepository;
        }


        public async Task<Modem> Handle(UpdateModemCommand request, CancellationToken cancellationToken)
        {
            var modemEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Modem>(request);
            if (modemEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            modemEntitiy.CreatedOn = DateTime.Now;
            modemEntitiy.ModifiedOn = DateTime.Now;
            var updateModem = _modemRepo.UpdateAsync(modemEntitiy, request.Id, "modem");
            var mapModemResponse = Mapper.Mappers.Map<Modem>(updateModem.Result);
            return mapModemResponse;
        }
    }
}

            

