using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Repositories;
using AssetsService.Core.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class CreateMakeMasterHandler : IRequestHandler<CreateMakeMasterCommand, MakeMasterResponse>
    {
        private readonly IMakeMasterRepository _MakeMasterRepo;

        public CreateMakeMasterHandler(IMakeMasterRepository MakeMasterRepository)
        {
            _MakeMasterRepo = MakeMasterRepository;
        }
        public async Task<MakeMasterResponse> Handle(CreateMakeMasterCommand request, CancellationToken cancellationToken)
        {
            var MakeMasterEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.MakeMaster>(request);
            if (MakeMasterEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            MakeMasterEntitiy.IsActive = true;
            var addMakeMasterResponse = await _MakeMasterRepo.AddAsync(MakeMasterEntitiy);
            var mapMakeMasterResponse = Mapper.Mappers.Map<MakeMasterResponse>(addMakeMasterResponse);
            return mapMakeMasterResponse;
        }
    }
}
