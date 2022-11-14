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
using AssetsService.Core.Repositories.Assets;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class IsActiveAssetHandler : IRequestHandler<IsActiveAssetCommand, AssetResponse>
    {
        private readonly IPadRepository _padRepository;
        private readonly IPowerCabinetRepository _powerCabinetRepository;
        private readonly IRFIdRepository _rfidRepository;
        private readonly IModemRepository _modemRepository;
        private readonly ICableRepository _cableRepository;
        private readonly ISwitchGearRepository _switchGearRepository;
        public IsActiveAssetHandler(IPadRepository padRepository, IPowerCabinetRepository powerCabinet, IRFIdRepository rfidRepository, IModemRepository modemRepository, ICableRepository cableRepository, ISwitchGearRepository switchGearRepository)
        {
            _padRepository = padRepository;
            _powerCabinetRepository = powerCabinet;
            _rfidRepository = rfidRepository;
            _modemRepository = modemRepository;
            _cableRepository = cableRepository;
            _switchGearRepository = switchGearRepository;
        }
        public async Task<AssetResponse> Handle(IsActiveAssetCommand request, CancellationToken cancellationToken)
        {
            if (request.Name.ToLower() == "pads")
            {
                var padMapper = Mapper.Mappers.Map<Core.Entities.Pad>(request);
                if (padMapper is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var updateasset = _padRepository.IsActiveStatusChangeAsync(padMapper, padMapper.Id, "pad");
                AssetResponse _padResponse = new AssetResponse();
                _padResponse.Id = updateasset.Id;
                return _padResponse;

            }
            else if (request.Name.ToLower() == "powercabinet" || request.Name.ToLower() == "powercabinets")
            {
                var assetMapper = Mapper.Mappers.Map<Core.Entities.PowerCabinet>(request);
                if (assetMapper is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var updateasset = _powerCabinetRepository.IsActiveStatusChangeAsync(assetMapper, assetMapper.Id, "powercabinet");
                AssetResponse _padResponse = new AssetResponse();
                _padResponse.Id = updateasset.Id;
                return _padResponse;
            }
            else if (request.Name.ToLower() == "rfidreaders")
            {
                var assetMapper = Mapper.Mappers.Map<Core.Entities.RFIDReader>(request);
                if (assetMapper is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var updateasset = _rfidRepository.IsActiveStatusChangeAsync(assetMapper, assetMapper.Id, "rfidreader");

                AssetResponse _padResponse = new AssetResponse();
                _padResponse.Id = updateasset.Id;
                return _padResponse;
            }
            else if (request.Name.ToLower() == "modem" || request.Name.ToLower() == "modems")
            {
                var assetMapper = Mapper.Mappers.Map<Core.Entities.Modem>(request);
                if (assetMapper is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var updateasset = _modemRepository.IsActiveStatusChangeAsync(assetMapper, assetMapper.Id, "modem");

                AssetResponse _padResponse = new AssetResponse();
                _padResponse.Id = updateasset.Id;
                return _padResponse;
            }
            else if (request.Name.ToLower() == "cables")
            {
                var assetMapper = Mapper.Mappers.Map<Core.Entities.Cable>(request);
                if (assetMapper is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var updateasset = _cableRepository.IsActiveStatusChangeAsync(assetMapper, assetMapper.Id, "cable");

                AssetResponse _padResponse = new AssetResponse();
                _padResponse.Id = updateasset.Id;
                return _padResponse;
            }
            else if (request.Name.ToLower() == "switchgears")
            {
                var assetMapper = Mapper.Mappers.Map<Core.Entities.SwitchGear>(request);
                if (assetMapper is null)
                {
                    throw new ApplicationException("Issue with mapper");
                }
                var updateasset = _switchGearRepository.IsActiveStatusChangeAsync(assetMapper, assetMapper.Id, "SwitchGears");

                AssetResponse _padResponse = new AssetResponse();
                _padResponse.Id = updateasset.Id;
                return _padResponse;
            }
            return new AssetResponse() { Id=0};
        }
    }
}
