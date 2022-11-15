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
    public class UpdateRFIdHandler : IRequestHandler<UpdateRFIdCommand, RFIDReader>
    {
        private readonly IRFIdRepository _rFIdRepository;

        public UpdateRFIdHandler(IRFIdRepository rFIdRepository)
        {
            _rFIdRepository = rFIdRepository;
        }

        public async Task<RFIDReader> Handle(UpdateRFIdCommand request, CancellationToken cancellationToken)
        {
            RFIDReader rfidreader = null;
            try
            {
                var rfIdEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.RFIDReader>(request);
                if (rfIdEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var rfIdReader = _rFIdRepository.GetByIdRfIdReader(request.Id);
                if (rfIdReader is not null && rfIdReader.Result is not null)
                {
                    rfIdEntitiy.CreatedOn = rfIdReader.Result.CreatedOn;
                    rfIdEntitiy.CreatedBy = rfIdReader.Result.CreatedBy;
                }
                else
                {
                    return rfidreader;
                }
                rfIdEntitiy.ModifiedOn = DateTime.Now;
                rfIdEntitiy.IsActive = request.IsActive;
                rfIdEntitiy.ModifiedBy = request.ModifiedBy;
                var updateRfId = _rFIdRepository.UpdateAsync(rfIdEntitiy, request.Id);
                rfidreader = Mapper.Mappers.Map<RFIDReader>(updateRfId.Result);
            }
            catch (Exception ex)
            {
                rfidreader = new RFIDReader();
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {

                    rfidreader.Id = -1;
                }
            }
            return rfidreader;
        }
    }
}
