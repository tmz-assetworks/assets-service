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
    public class DeleteMakeMasterHandler : IRequestHandler<DeleteMakeMasterCommand, MakeMasterResponse>
    {
        private readonly IMakeMasterRepository _MakeMasterRepo;
        public DeleteMakeMasterHandler(IMakeMasterRepository MakeMasterRepository)
        {
            _MakeMasterRepo = MakeMasterRepository;
        }
        public async Task<MakeMasterResponse> Handle(DeleteMakeMasterCommand request, CancellationToken cancellationToken)
        {
            var MakeMasterEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.MakeMaster>(request);
            if (MakeMasterEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatecable = _MakeMasterRepo.DeleteActiveAsync(MakeMasterEntitiy, MakeMasterEntitiy.Id, "MAKEMASTER");
            var mapMakeMasterResponse = Mapper.Mappers.Map<MakeMasterResponse>(updatecable.Result);

            return mapMakeMasterResponse;
        }
    }
}
