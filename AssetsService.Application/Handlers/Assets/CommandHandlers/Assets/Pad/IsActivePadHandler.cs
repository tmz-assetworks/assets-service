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
using AssetsService.Application.Commands.Assets.Pad;
using AssetsService.Core.Entities;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.Pad
{
    public class IsActivePadHandler : IRequestHandler<IsActivePadCommand, PadResponse>
    {
        private readonly IPadRepository _padRepository;
        public IsActivePadHandler(IPadRepository padRepository)
        {
            _padRepository = padRepository;
        }
        public async Task<PadResponse> Handle(IsActivePadCommand request, CancellationToken cancellationToken)
        {
            var padMapper = Mapper.Mappers.Map<AssetsService.Core.Entities.Pad>(request);
            if (padMapper is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var updatecable = _padRepository.IsActiveStatusChangeAsync(padMapper, padMapper.Id, "pad");
            PadResponse _padResponse = new PadResponse();
            _padResponse.Id = padMapper.Id;
            return _padResponse;
        }
    }
}
