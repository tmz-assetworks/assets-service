using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class UpdateCableHandler : IRequestHandler<UpdateCableCommand, Cable>
    {
        private readonly ICableRepository _cableRepo;

        public UpdateCableHandler(ICableRepository cableRepository)

        {
            _cableRepo = cableRepository;
        }

        public async Task<Cable> Handle(UpdateCableCommand request, CancellationToken cancellationToken)
        {
            Cable updateCable = null;
            var cableEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Cable>(request);
            try
            {
                if (cableEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                cableEntitiy.CreatedOn = DateTime.Now;
                cableEntitiy.ModifiedOn = DateTime.Now;
                updateCable = await _cableRepo.Updatecable(cableEntitiy);
            }
            catch (Exception ex)
            {
                updateCable = new Cable();
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    updateCable.Id = -1;
                }
            }
            return (updateCable);
        }

    }
}
