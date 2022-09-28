using AssetsService.Application.Commands.Assets.RFId;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
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
    public class CreateRFIdHandler : IRequestHandler<CreateRFIdCommand, RFIDReader>
    {
        private readonly IRFIdRepository _iRFIdRepository;

        public CreateRFIdHandler(IRFIdRepository iRFIdRepository)
        {
            _iRFIdRepository = iRFIdRepository;
        }

        public async Task<RFIDReader> Handle(CreateRFIdCommand request, CancellationToken cancellationToken)
        {
            RFIdResponse maprfIdResponse = new RFIdResponse();
            RFIDReader rfidreader = null;
            var rfIdEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.RFIDReader>(request);
            try
            {
                if (rfIdEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                rfIdEntitiy.IsActive = request.IsActive;
                rfIdEntitiy.CreatedOn = DateTime.Now;
                //rfIdEntitiy.ModifiedBy = request.CreatedBy;
                rfIdEntitiy.ModifiedOn = DateTime.Now;
                var addrfIdResponse = await _iRFIdRepository.AddAsync(rfIdEntitiy);
                 rfidreader = Mapper.Mappers.Map<RFIDReader>(addrfIdResponse);
            }
            catch (Exception ex)
            {
                ;
            }
            return rfidreader;
        }
    }
}
