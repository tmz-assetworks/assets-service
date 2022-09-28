using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateModemHandler : IRequestHandler<CreateModemCommand, Modem>
    {
        private readonly IModemRepository _modemRepo;

        public CreateModemHandler(IModemRepository modemRepository)
        {
            _modemRepo = modemRepository;
        }
        public async Task<Modem> Handle(CreateModemCommand request, CancellationToken cancellationToken)
        {
            Modem modem = null;
            try
            {
                var modemEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Modem>(request);
                if (modemEntitiy is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                modemEntitiy.CreatedOn = DateTime.Now;
                modemEntitiy.ModifiedOn = DateTime.Now;
                modemEntitiy.ModifiedBy = "";
                var addModemResponse = await _modemRepo.AddAsync(modemEntitiy);
                modem = Mapper.Mappers.Map<Modem>(addModemResponse);
                 
            }
            catch (Exception ex)
            {
                modem=  new Modem();
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    modem.Id = -1;
                }                
            }
            return modem;
            
        }
    }
}
