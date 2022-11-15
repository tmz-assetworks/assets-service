using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class UpdateSwitchGearHandler : IRequestHandler<UpdateSwitchGearCommand, SwitchGearResponse>
    {
        private readonly ISwitchGearRepository _switchGearRepository;
        public UpdateSwitchGearHandler(ISwitchGearRepository switchGearRepository)
        {
            _switchGearRepository = switchGearRepository;
        }
        public async Task<SwitchGearResponse> Handle(UpdateSwitchGearCommand request, CancellationToken cancellationToken)
        {
            var switchGearEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.SwitchGear>(request);
            if (switchGearEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            switchGearEntitiy.ModifiedOn = DateTime.Now;
            var updateSwitchGear = _switchGearRepository.UpdateAsync(switchGearEntitiy, request.Id, "SwitchGear");
            var mapSwitchGearResponse = Mapper.Mappers.Map<SwitchGearResponse>(updateSwitchGear.Result);
            return mapSwitchGearResponse;
        }
    }
}
