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
        public class UpdateCableHandler : IRequestHandler<UpdateCableCommand, CableResponse>
        {
            private readonly ICableRepository _cableRepo;

            public UpdateCableHandler(ICableRepository cableRepository)

            {
                _cableRepo = cableRepository;
            }

            public async Task<CableResponse> Handle(UpdateCableCommand request, CancellationToken cancellationToken)
            {
                var cableEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Cable>(request);
                if (cableEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }

                var updateCable = _cableRepo.UpdateAsync(cableEntitiy, request.Id, "CABLE");
                var mapCableResponse = Mapper.Mappers.Map<CableResponse>(updateCable.Result);
                return mapCableResponse;
            }

        }
    }
