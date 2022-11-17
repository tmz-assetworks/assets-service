using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateDispenserHandler : IRequestHandler<CreateDispenserCommand, DispenserResponse>
    {
        private readonly IDispenserRepository _dispenserRepo;
        private readonly IRepository<Port> _repositoryPort;
        private readonly IRFIdRepository _RFIdRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICableRepository _cableRepo;
        private readonly ISwitchGearRepository _switchGearRepository;
        public CreateDispenserHandler(IDispenserRepository dispenserRepository, IRepository<Port> repositoryPort, IRFIdRepository _rfidrepository, ILocationRepository locationRepository, ICableRepository cableRepo, ISwitchGearRepository switchGearRepository)
        {
            _dispenserRepo = dispenserRepository;
            _repositoryPort = repositoryPort;
            _RFIdRepository = _rfidrepository;
            _locationRepository = locationRepository;
            _cableRepo = cableRepo;
            _switchGearRepository = switchGearRepository;   
        }
        public async Task<DispenserResponse> Handle(CreateDispenserCommand request, CancellationToken cancellationToken)
        {
            var dispenserEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Charger>(request);
            DispenserResponse dataResponse = new DispenserResponse();
            if (dispenserEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            // UNIQUE KEY constraint dataResponse.Id = -1 in Catch; 
            var location = _locationRepository.GetByIdLocation(request.LocationId);
            //var cable = _cableRepo.GetByIdCable(request.CableId.Value);
            if (location.Result == null)
            {
                dataResponse.Id = -3;      //  return back becouse the mapped LocationId is not  present in Database.   Bug Issue  AS-1337
                return dataResponse;
            }
            dispenserEntitiy.CreatedOn = DateTime.Now;
            dispenserEntitiy.ModifiedOn = DateTime.Now;
            dispenserEntitiy.ModifiedBy = dispenserEntitiy.CreatedBy;
            dispenserEntitiy.MultiplePorts = true;
            dispenserEntitiy.IsAutomatic = true;
            dispenserEntitiy.Ports = new List<Port>();
            if (request.PortCommand.Count > 0)
            {
                for (int i = 0; i < request.PortCommand.Count(); i++)
                {
                    dispenserEntitiy.Ports.Add(new Port()
                    {
                        Id = 0,
                        ChargerId = 0,
                        ConnectorId = request.PortCommand[i].ConnectorId,
                        ConnectorType = request.PortCommand[i].ConnectorType,
                        CreatedBy = request.CreatedBy,
                        CreatedOn = DateTime.Now,
                        IncrementalPower = request.PortCommand[i].IncrementalPower,
                        IsActive = request.PortCommand[i].IsActive,
                        MaxPower = request.PortCommand[i].MaxPower,
                        MinPower = request.PortCommand[i].MinPower,
                        ModifiedBy = "",
                        ModifiedOn = DateTime.Now,
                        PlugTypeId = request.PortCommand[i].PlugTypeId,
                        PortName = request.PortCommand[i].PortName,
                        Power = request.PortCommand[i].Power,
                    });
                }
            }
            else
            {
                dispenserEntitiy.Ports.Add(new Port()
                {
                    Id = 0,
                    ChargerId = 0,
                    ConnectorId = 1,
                    ConnectorType = 1,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = DateTime.Now,
                    IncrementalPower = 100,
                    IsActive = true,
                    MaxPower = 20,
                    MinPower = 10,
                    ModifiedBy = "",
                    ModifiedOn = DateTime.Now,
                    PlugTypeId = 1,
                    PortName = "Port",
                    Power = 100,
                });
            }
            try
            {
                dispenserEntitiy.CableId = (dispenserEntitiy.CableId.HasValue && dispenserEntitiy.CableId == 0) ? null : dispenserEntitiy.CableId;
                dispenserEntitiy.ModemId = (dispenserEntitiy.ModemId.HasValue && dispenserEntitiy.ModemId == 0) ? null : dispenserEntitiy.ModemId;
                dispenserEntitiy.PadId = (dispenserEntitiy.PadId.HasValue && dispenserEntitiy.PadId == 0) ? null : dispenserEntitiy.PadId;
                dispenserEntitiy.RFIDReaderId = (dispenserEntitiy.RFIDReaderId.HasValue && dispenserEntitiy.RFIDReaderId == 0) ? null : dispenserEntitiy.RFIDReaderId;
                dispenserEntitiy.SwitchGearId = (dispenserEntitiy.SwitchGearId.HasValue && dispenserEntitiy.SwitchGearId == 0) ? null : dispenserEntitiy.SwitchGearId;
                dispenserEntitiy.PowerCabinetId = (dispenserEntitiy.PowerCabinetId.HasValue && dispenserEntitiy.PowerCabinetId == 0) ? null : dispenserEntitiy.PowerCabinetId;

                var addDispenserResponse = await _dispenserRepo.AddAsync(dispenserEntitiy);
                dataResponse = Mapper.Mappers.Map<DispenserResponse>(addDispenserResponse);
            }
            catch (Exception ex)
            {
                if (ex != null && ex.InnerException != null && ex.InnerException.ToString().Contains("UNIQUE KEY constraint"))
                {
                    dataResponse.Id = -1;
                }
            }
            return dataResponse;
        }

    }
}