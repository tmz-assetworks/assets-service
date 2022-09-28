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
                var cableEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Cable>(request);
                if (cableEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                  cableEntitiy.CreatedOn = DateTime.Now;
                  cableEntitiy.ModifiedOn = DateTime.Now;

                var updateCable = await _cableRepo.Updatecable(cableEntitiy);
               return (updateCable);
            }

        }
    }
