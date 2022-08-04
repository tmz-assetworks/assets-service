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

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class DeleteCableHandler : IRequestHandler<DeleteCableCommand, CableResponse>
    {
        private readonly ICableRepository _CableRepo;
        public DeleteCableHandler(ICableRepository CableRepository)
        {
            _CableRepo = CableRepository;
        }
        public async Task<CableResponse> Handle(DeleteCableCommand request, CancellationToken cancellationToken)
        {
            var cableEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Cable>(request);
            if (cableEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatecable = _CableRepo.DeleteActiveAsync(cableEntitiy, cableEntitiy.Id, "CABLE");
            var mapcustomerResponse = Mapper.Mappers.Map<CableResponse>(updatecable.Result);
            
            return mapcustomerResponse;
        }
    }
}
