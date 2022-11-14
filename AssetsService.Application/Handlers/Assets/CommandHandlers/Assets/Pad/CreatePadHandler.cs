using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class CreatePadHandler : IRequestHandler<CreatePadCommand, PadResponse>
    {
        private readonly IPadRepository _padRepo;

        public CreatePadHandler(IPadRepository padRepository)
        {
            _padRepo = padRepository;
        }
        public async Task<PadResponse> Handle(CreatePadCommand request, CancellationToken cancellationToken)
        {
            PadResponse padResponse = null;
            try
            {
                var padEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Pad>(request);
                if (padEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                padEntitiy.ModifiedOn = DateTime.Now;
                padEntitiy.CreatedOn = DateTime.Now;
                padEntitiy.ModifiedBy = "";
                var addPadResponse = await _padRepo.AddAsync(padEntitiy);
                padResponse = Mapper.Mappers.Map<PadResponse>(addPadResponse);
            }
            catch (Exception ex)
            {
                padResponse = new PadResponse();
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    padResponse = new PadResponse();
                    padResponse.Id = -1;
                }
            }
            return padResponse;
        }
    }
}
