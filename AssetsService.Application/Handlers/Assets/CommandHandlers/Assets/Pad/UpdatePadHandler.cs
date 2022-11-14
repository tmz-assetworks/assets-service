using AssetsService.Application.Commands.Assets.Pad;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Repositories;
using AssetsService.Application.Commands.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Mapper;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.Pad
{
    public class UpdatePadHandler : IRequestHandler<UpdatePadCommand, PadResponse>
    {
        private readonly IPadRepository _padRepo;

        public UpdatePadHandler(IPadRepository padRepository)
        {
            _padRepo = padRepository;
        }

        public async Task<PadResponse> Handle(UpdatePadCommand request, CancellationToken cancellationToken)
        {
            var padEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Pad>(request);
            PadResponse padResponse = null;
            try
            {
                if (padEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                padEntitiy.ModifiedOn = DateTime.Now;
                var updatePad = _padRepo.UpdateAsync(padEntitiy, request.Id, "PAD");
                padResponse = Mapper.Mappers.Map<PadResponse>(updatePad.Result);
            }
            catch (Exception ex)
            {
                padResponse = new PadResponse();
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    padResponse.Id = -1;
                }
            }
            return padResponse;
        }
    }
}
