using AssetsService.Application.Commands.Assets;
using AssetsService.Core.ConstantResponse;
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
            try
            {
                var cableEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Cable>(request);
                cableEntitiy.CreatedOn = DateTime.Now;
                cableEntitiy.ModifiedOn = DateTime.Now;
                
                createCableResponse = await _cableRepo.CreateCable(cableEntitiy);
            }
            catch (Exception ex)
            {                
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    createCableResponse.Id = -1;
                }
                
                   
            }
            return createCableResponse;
        }
    }
}
