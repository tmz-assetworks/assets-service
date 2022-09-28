using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using AssetsService.Core.Responses.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateCableHandler : IRequestHandler<CreateCableCommand, CreateCableResponse>
    {
        private readonly ICableRepository _cableRepo;

        public CreateCableHandler(ICableRepository cableRepository)
        {
            _cableRepo = cableRepository;
        }
        public async Task<CreateCableResponse> Handle(CreateCableCommand request, CancellationToken cancellationToken)
        {
            CreateCableResponse createCableResponse = new CreateCableResponse(); 
            var cableEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Cable>(request);
            cableEntitiy.CreatedOn = DateTime.Now;
            cableEntitiy.ModifiedOn = DateTime.Now;
            if (cableEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
           // cableEntitiy.IsActive = true;
           // cableEntitiy.AssetId = "";
           // cableEntitiy.ModifiedBy = cableEntitiy.CreatedBy;
           // cableEntitiy.ModifiedBy = "";
            //cableEntitiy.CreatedBy = "";
            createCableResponse = await _cableRepo.CreateCable(cableEntitiy);

            return createCableResponse;
        }
    }
}
