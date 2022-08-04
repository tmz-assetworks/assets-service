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
            var padEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Pad>(request);
            if (padEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var addPadResponse = await _padRepo.AddAsync(padEntitiy);
            var mapPadResponse = Mapper.Mappers.Map<PadResponse>(addPadResponse);
            return mapPadResponse;
        }
    }
}
