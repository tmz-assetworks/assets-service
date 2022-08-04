using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Repositories;
using AssetsService.Core.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class CreateModelHandler : IRequestHandler<CreateModelCommand, ModelResponse>
    {
        private readonly IModelRepository _ModelRepo;

        public CreateModelHandler(IModelRepository ModelRepository)
        {
            _ModelRepo = ModelRepository;
        }
        public async Task<ModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var ModelEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Model>(request);
            if (ModelEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            ModelEntitiy.IsActive = true;
            var addModelResponse = await _ModelRepo.AddAsync(ModelEntitiy);
            var mapModelResponse = Mapper.Mappers.Map<ModelResponse>(addModelResponse);
            return mapModelResponse;
        }
    }
}
