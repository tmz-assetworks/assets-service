using AutoMapper;
using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Application.Responses.Assets;
using AssetsService.Application.Commands.Assets.Pad;
using AssetsService.Application.Commands.Assets.RFId;
using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Response;

namespace AssetsService.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<AssetsService.Core.Entities.Cable, DeleteCableCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Cable, IsActiveAssetCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Cable, CableResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Cable, CreateCableCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Cable, UpdateCableCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Vehicle, VehicleResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Vehicle, CreateVehicleCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Vehicle, UpdateVehicleCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Vehicle, IsActiveVehicleCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.VehicleMake, CreateVehicleMakeCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.VehicleMake, VehicleMakeResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.VehicleMake, UpdateVehicleMakeCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.VehicleMake, DeleteVehicleMakeCommand>().ReverseMap();

            CreateMap<AssetsService.Core.Entities.MakeMaster, CreateMakeMasterCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.MakeMaster, MakeMasterResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.MakeMaster, UpdateMakeMasterCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.MakeMaster, DeleteMakeMasterCommand>().ReverseMap();

            CreateMap<AssetsService.Core.Entities.Model, Application.Responses.Assets.ModelResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Model, CreateModelCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Model, UpdateModelCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Model, DeleteModelCommand>().ReverseMap();


            CreateMap<AssetsService.Core.Entities.Modem, ModemResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Modem, IsActiveAssetCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Modem, CreateModemCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Modem, UpdateModemCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Pos, PosResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Pos, CreatePosCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Pos, UpdatePosCommand>().ReverseMap();

            CreateMap<AssetsService.Core.Entities.PowerCabinet, PowerCabinetResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.PowerCabinet, IsActiveAssetCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.PowerCabinet, CreatePowerCabinetCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.PowerCabinet, UpdatePowerCabinetCommand>().ReverseMap();


            CreateMap<AssetsService.Core.Entities.Location, LocationResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Location, CreateLocationCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Location, UpdateLocationCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Location, UpdateLocationCommand>().ReverseMap();

            CreateMap<AssetsService.Core.Entities.Charger, DispenserResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Charger, CreateDispenserCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Charger, UpdateDispenserCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Charger, DeleteDispenserCommand>().ReverseMap();

            CreateMap<AssetsService.Core.Entities.Pad, PadResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Pad, IsActiveAssetCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Pad, CreatePadCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Pad, UpdatePadCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.Pad, IsActivePadCommand>().ReverseMap();

            CreateMap<AssetsService.Core.Entities.RFIDReader, RFIdResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.RFIDReader, IsActiveAssetCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.RFIDReader, CreateRFIdCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.RFIDReader, UpdateRFIdCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.SwitchGear, SwitchGearResponse>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.SwitchGear, CreateSwitchGearCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.SwitchGear, UpdateSwitchGearCommand>().ReverseMap();
            CreateMap<AssetsService.Core.Entities.SwitchGear, IsActiveAssetCommand>().ReverseMap();

        }
    }
}
