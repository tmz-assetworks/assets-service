using AssetsService.Application.Commands.Assets.RFId;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.RFId
{
    public class UpdateRFIdHandler : IRequestHandler<UpdateRFIdCommand, RFIdResponse>
    {
        private readonly IRFIdRepository _rFIdRepository;

        public UpdateRFIdHandler(IRFIdRepository rFIdRepository)
        {
            _rFIdRepository = rFIdRepository;
        }

        public async Task<RFIdResponse> Handle(UpdateRFIdCommand request, CancellationToken cancellationToken)
        {
            var rfIdEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.RFIDReader>(request);
            if (rfIdEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var updateRfId = _rFIdRepository.UpdateAsync(rfIdEntitiy, request.Id);
            var mapRfIdResponse = Mapper.Mappers.Map<RFIdResponse>(updateRfId.Result);
            return mapRfIdResponse;
        }
    }
}
