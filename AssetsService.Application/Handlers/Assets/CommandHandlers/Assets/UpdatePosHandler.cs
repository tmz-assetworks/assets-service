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
    public class UpdatePosHandler : IRequestHandler<UpdatePosCommand, PosResponse>
    {
        private readonly IPosRepository _posRepo;

        public UpdatePosHandler(IPosRepository posRepository)
        {
            _posRepo = posRepository;
        }


        public async Task<PosResponse> Handle(UpdatePosCommand request, CancellationToken cancellationToken)
        {
            var posEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Pos>(request);
            if (posEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatePos = _posRepo.UpdateAsync(posEntitiy, request.Id, "POS");
            var mapPosResponse = Mapper.Mappers.Map<PosResponse>(updatePos.Result);
            return mapPosResponse;
        }
    }
}