using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Repositories;
using AssetsService.Infrastructure.Repositories.Assets;
using AssetsService.Core.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Application.Commands.Assets.RFId;
using AssetsService.Core.Entities;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class IsActiveRfIdRaderHandler : IRequestHandler<IsActiveRfIdReaderCommand, RFIdResponse>
    {
        private readonly IRFIdRepository _rFIdRepository;
        public IsActiveRfIdRaderHandler(IRFIdRepository rfIdRepository)
        {
            _rFIdRepository = rfIdRepository;
        }
        public async Task<RFIdResponse> Handle(IsActiveRfIdReaderCommand request, CancellationToken cancellationToken)
        {
            RFIdResponse rFIdResponse = new RFIdResponse();
            RFIDReader rfidreaderData = await _rFIdRepository.GetByIdRfIdReaderData(request.Id);
            if (rfidreaderData is not null)
            {
                rfidreaderData.IsActive = request.IsActive;
                rfidreaderData.ModifiedBy = request.ModifiedBy;
                rfidreaderData.ModifiedOn = DateTime.Now;
                 rfidreaderData = await _rFIdRepository.IsActiveStatusChangeAsync(rfidreaderData, request.Id, "RFIDReader");
                rFIdResponse.Id = rfidreaderData.Id;
            }           
            return rFIdResponse;
        }
    }
}
