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
    public class CreateRFIdHandler : IRequestHandler<CreateRFIdCommand, RFIdResponse>
    {
        private readonly IRFIdRepository _iRFIdRepository;

        public CreateRFIdHandler(IRFIdRepository iRFIdRepository)
        {
            _iRFIdRepository = iRFIdRepository;
        }

        public async Task<RFIdResponse> Handle(CreateRFIdCommand request, CancellationToken cancellationToken)
        {
            var rfIdEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.RFIDReader>(request);
            if (rfIdEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var addrfIdResponse = await _iRFIdRepository.AddAsync(rfIdEntitiy);
            var maprfIdResponse = Mapper.Mappers.Map<RFIdResponse>(addrfIdResponse);
            return maprfIdResponse;
        }
    }
}
