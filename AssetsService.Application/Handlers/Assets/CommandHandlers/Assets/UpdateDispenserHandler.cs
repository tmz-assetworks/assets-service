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


    public class UpdateDispenserHandler : IRequestHandler<UpdateDispenserCommand, DispenserResponse>
    {
        private readonly IDispenserRepository _DispenserRepo;

        public UpdateDispenserHandler(IDispenserRepository DispenserRepository)
        {
            _DispenserRepo = DispenserRepository;
        }


        public async Task<DispenserResponse> Handle(UpdateDispenserCommand request, CancellationToken cancellationToken)
        {
            var DispenserEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Dispenser>(request);
            if (DispenserEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updateDispenser = _DispenserRepo.UpdateAsync(DispenserEntitiy, DispenserEntitiy.Id);
            var mapUserResponse = Mapper.Mappers.Map<DispenserResponse>(updateDispenser.Result);
            return mapUserResponse;
        }

    }
}


