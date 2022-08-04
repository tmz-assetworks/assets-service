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
    public class DeleteModelHandler : IRequestHandler<DeleteModelCommand, ModelResponse>
    {
        private readonly IModelRepository _ModelRepo;
        public DeleteModelHandler(IModelRepository ModelRepository)
        {
            _ModelRepo = ModelRepository;
        }
        public async Task<ModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var ModelEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Model>(request);
            if (ModelEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updateModel = _ModelRepo.DeleteActiveAsync(ModelEntitiy, ModelEntitiy.Id, "MODEL");
            var mapcustomerResponse = Mapper.Mappers.Map<ModelResponse>(updateModel.Result);

            return mapcustomerResponse;
        }
    }
}
