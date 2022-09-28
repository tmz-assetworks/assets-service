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
    public class UpdateMakeMasterHandler : IRequestHandler<UpdateMakeMasterCommand, MakeMasterResponse>
    {
        private readonly IMakeMasterRepository _MakeMasterRepo;

        public UpdateMakeMasterHandler(IMakeMasterRepository MakeMasterRepository)
        {
            _MakeMasterRepo = MakeMasterRepository;
        }


        public async Task<MakeMasterResponse> Handle(UpdateMakeMasterCommand request, CancellationToken cancellationToken)
        {
            var MakeMasterEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.MakeMaster>(request);
            if (MakeMasterEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
             MakeMasterEntitiy.CreatedOn = DateTime.Now;
            MakeMasterEntitiy.ModifiedOn = DateTime.Now;
            var updateMakeMaster = _MakeMasterRepo.UpdateAsync(MakeMasterEntitiy, request.Id, "MODEL");
            var mapMakeMasterResponse = Mapper.Mappers.Map<MakeMasterResponse>(updateMakeMaster.Result);
            return mapMakeMasterResponse;
        }
    }
}
