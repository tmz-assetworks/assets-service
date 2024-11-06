using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{


    public class UpdateDispenserHandler : IRequestHandler<UpdateDispenserCommand, DispenserResponse>
    {
        private readonly IDispenserRepository _DispenserRepo;
        private readonly IRFIdRepository _RFIdRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICableRepository _cableRepo;
        private readonly ISwitchGearRepository _switchGearRepository;
        public UpdateDispenserHandler(IDispenserRepository DispenserRepository, IRFIdRepository _rfidrepository, ILocationRepository locationRepository, ICableRepository cableRepo, ISwitchGearRepository switchGearRepository)
        {
            _DispenserRepo = DispenserRepository;
            _RFIdRepository = _rfidrepository;
            _locationRepository = locationRepository;
            _cableRepo = cableRepo;
            _switchGearRepository = switchGearRepository;
        }


        public async Task<DispenserResponse> Handle(UpdateDispenserCommand request, CancellationToken cancellationToken)
        {

            var dispenserEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Charger>(request);
            if (dispenserEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            DispenserResponse dataResponse = new DispenserResponse();

            var location = _locationRepository.GetByIdLocation(request.LocationId);
            if (location.Result == null)
            {
                dataResponse.Id = -3;      //  return back becouse the mapped LocationId is not  present in Database.   Bug Issue  AS-1337
                return dataResponse;
            }
            var dispensery = _DispenserRepo.GetDispenserByChargeBoxId(request.ChargeBoxId);
            if (dispensery != null && dispensery.Result != null && dispensery.Result.Id != request.Id)
            {
                dataResponse.Id = -5;
                return dataResponse;
            }
            dispenserEntitiy.MultiplePorts = true;
            dispenserEntitiy.IsAutomatic = true;
            dispenserEntitiy.Ports = new List<Port>();
            if (request.UpdatePortCommand != null)
            {
                for (int i = 0; i < request.UpdatePortCommand.Count(); i++)
                {
                    dispenserEntitiy.Ports.Add(new Port()
                    {
                        Id = request.UpdatePortCommand[i].Id,
                        ChargerId = (int)request.Id,
                        ConnectorId = request.UpdatePortCommand[i].ConnectorId,
                        ConnectorType = request.UpdatePortCommand[i].ConnectorType,
                        IncrementalPower = request.UpdatePortCommand[i].IncrementalPower,
                        IsActive = request.UpdatePortCommand[i].IsActive,
                        MaxPower = request.UpdatePortCommand[i].MaxPower,
                        MinPower = request.UpdatePortCommand[i].MinPower,
                        ModifiedBy = request.ModifiedBy,
                        ModifiedOn = DateTime.Now,
                        ChargerTypeId = request.UpdatePortCommand[i].PlugTypeId,
                        PortName = request.UpdatePortCommand[i].PortName,
                        Power = request.UpdatePortCommand[i].Power,
                    });
                }
            }
            dispenserEntitiy.CableId = (dispenserEntitiy.CableId.HasValue && dispenserEntitiy.CableId == 0) ? null : dispenserEntitiy.CableId;
            dispenserEntitiy.ModemId = (dispenserEntitiy.ModemId.HasValue && dispenserEntitiy.ModemId == 0) ? null : dispenserEntitiy.ModemId;
            dispenserEntitiy.PadId = (dispenserEntitiy.PadId.HasValue && dispenserEntitiy.PadId == 0) ? null : dispenserEntitiy.PadId;
            dispenserEntitiy.RFIDReaderId = (dispenserEntitiy.RFIDReaderId.HasValue && dispenserEntitiy.RFIDReaderId == 0) ? null : dispenserEntitiy.RFIDReaderId;
            dispenserEntitiy.SwitchGearId = (dispenserEntitiy.SwitchGearId.HasValue && dispenserEntitiy.SwitchGearId == 0) ? null : dispenserEntitiy.SwitchGearId;
            dispenserEntitiy.PowerCabinetId = (dispenserEntitiy.PowerCabinetId.HasValue && dispenserEntitiy.PowerCabinetId == 0) ? null : dispenserEntitiy.PowerCabinetId;
            var updateDispenser = _DispenserRepo.UpdateDispenser(dispenserEntitiy);
            var mapUserResponse = Mapper.Mappers.Map<DispenserResponse>(updateDispenser.Result);
            return mapUserResponse;
        }

    }
}
