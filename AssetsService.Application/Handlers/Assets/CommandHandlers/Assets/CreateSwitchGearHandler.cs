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
    public class CreateSwitchGearHandler : IRequestHandler<CreateSwitchGearCommand, SwitchGearResponse>
    {
        private readonly ISwitchGearRepository _switchGearRepository;
        public CreateSwitchGearHandler(ISwitchGearRepository switchGearRepository)
        {
            _switchGearRepository = switchGearRepository;
        }
        public async Task<SwitchGearResponse> Handle(CreateSwitchGearCommand request, CancellationToken cancellationToken)
        {
            var switchGearEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.SwitchGear>(request);
            switchGearEntitiy.CreatedOn = DateTime.Now;
            switchGearEntitiy.ModifiedOn = DateTime.Now;
            switchGearEntitiy.ModifiedBy = switchGearEntitiy.CreatedBy;
            SwitchGearResponse dataResponse = new SwitchGearResponse();
            if (switchGearEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            try
            {
                var addSwitchGearResponse = await _switchGearRepository.AddAsync(switchGearEntitiy);
                dataResponse = Mapper.Mappers.Map<SwitchGearResponse>(addSwitchGearResponse);
            }
            catch (Exception ex)
            {
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    dataResponse.Id = -1;
                }
            }
            return dataResponse;
        }
    }
}
