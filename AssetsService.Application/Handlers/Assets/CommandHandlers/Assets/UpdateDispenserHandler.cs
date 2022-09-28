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
        public UpdateDispenserHandler(IDispenserRepository DispenserRepository, IRFIdRepository _rfidrepository, ILocationRepository locationRepository)
        {
            _DispenserRepo = DispenserRepository;
            _RFIdRepository = _rfidrepository;
            _locationRepository = locationRepository;   
        }


        public async Task<DispenserResponse> Handle(UpdateDispenserCommand request, CancellationToken cancellationToken)
        {
            
            var dispenserEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Dispenser>(request);
            if (dispenserEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            DispenserResponse dataResponse = new DispenserResponse();

            var rfIdReader = _RFIdRepository.GetByIdRfIdReaderData(request.RFIdReaderId);
            var location = _locationRepository.GetByIdLocation(request.LocationId);
            if (location.Result == null)
            {
                dataResponse.Id = -3;      //  return back becouse the mapped LocationId is not  present in Database.   Bug Issue  AS-1337
                return dataResponse;
            }
            if (rfIdReader.Result == null)
            {
                dataResponse.Id = -2;      //  return back becouse the mapped RFIdReaderId is not  present in Database.   Bug Issue  AS-1337
                return dataResponse;
            }
           
            dispenserEntitiy.Ports = new List<Port>();
            if (request.UpdatePortCommand != null)
            {
                for (int i = 0; i < request.UpdatePortCommand.Count(); i++)
                {
                    dispenserEntitiy.Ports.Add(new Port()
                    {
                        Id = request.UpdatePortCommand[i].Id,
                        DispenserId = request.Id,
                        ConnectorId = request.UpdatePortCommand[i].ConnectorId,
                        ConnectorType = request.UpdatePortCommand[i].ConnectorType,
                        IncrementalPower = request.UpdatePortCommand[i].IncrementalPower,
                        IsActive = request.UpdatePortCommand[i].IsActive,
                        MaxPower = request.UpdatePortCommand[i].MaxPower,
                        MinPower = request.UpdatePortCommand[i].MinPower,
                        ModifiedBy = request.ModifiedBy,
                        ModifiedOn = DateTime.Now,
                        PlugTypeId = request.UpdatePortCommand[i].PlugTypeId,
                        PortName = request.UpdatePortCommand[i].PortName,
                        Power = request.UpdatePortCommand[i].Power,
                    });
                }
            }
            var updateDispenser = _DispenserRepo.UpdateDispenser(dispenserEntitiy);
            var mapUserResponse = Mapper.Mappers.Map<DispenserResponse>(updateDispenser.Result);
            return mapUserResponse;
        }

    }
}


