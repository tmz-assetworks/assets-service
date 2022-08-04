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
    public class UpdateModelHandler : IRequestHandler<UpdateModelCommand, ModelResponse>
    {
        private readonly IModelRepository _ModelRepo;

        public UpdateModelHandler(IModelRepository ModelRepository)
        {
            _ModelRepo = ModelRepository;
        }

        public async Task<ModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var ModelEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Model>(request);
            if (ModelEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updateModel = _ModelRepo.UpdateAsync(ModelEntitiy, request.Id, "MODEL");
            var mapModelResponse = Mapper.Mappers.Map<ModelResponse>(updateModel.Result);
            return mapModelResponse;
        }
    }
}
