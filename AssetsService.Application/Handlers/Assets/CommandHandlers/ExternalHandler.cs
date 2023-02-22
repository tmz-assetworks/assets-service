using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    
    public class ExternalHandler : IRequestHandler<CreateNewVehicleCommandExternal, CreateVehicleResponseExternal>
    {
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IExternalRepository _externalvehicleRepo;
        

        public ExternalHandler(IVehicleRepository vehicleRepository, IExternalRepository _ExternalvehicleRepo)
        {
            _vehicleRepo = vehicleRepository;
            _externalvehicleRepo = _ExternalvehicleRepo;    
        }

        async Task<CreateVehicleResponseExternal> IRequestHandler<CreateNewVehicleCommandExternal, CreateVehicleResponseExternal>.Handle(CreateNewVehicleCommandExternal request, CancellationToken cancellationToken)
        {
            CreateVehicleResponseExternal vehicleResponse = new CreateVehicleResponseExternal();
            var vehicleEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Vehicle>(request);

            if (vehicleEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            VehicleRFID objVehicleRfIdReader = null;
            vehicleEntitiy.vehicleRFID = new List<VehicleRFID>();
            vehicleEntitiy.CreatedOn = DateTime.Now;
            vehicleEntitiy.ModifiedOn = DateTime.Now;
            if (request.RfIdCardsAssigneds.Count() <= 0)
            {
                //var alreadyVehicleRFID = await _vehicleRepo.GetVehicleRFIDDetailsByName(request.VIN);
                //if (alreadyVehicleRFID != null)
                //{
                //    vehicleResponse.id = -6;  // vin no as rfid is already assigned to vehicle 
                //    return vehicleResponse;
                //}
                objVehicleRfIdReader = new VehicleRFID();
                objVehicleRfIdReader.Name = request.VIN;
                objVehicleRfIdReader.CreatedBy = request.CreatedBy;
                objVehicleRfIdReader.ModifiedBy = request.CreatedBy;
                objVehicleRfIdReader.ModifiedOn = DateTime.Now;
                objVehicleRfIdReader.CreatedOn = DateTime.Now;
                objVehicleRfIdReader.IsActive = true;
                //VehicleDTO dt = await _vehicleRepo.GetVehicleByVinNumber(request.VIN);
                //if (dt != null)
                //{
                //    objVehicleRfIdReader.VehicleId = dt.Id;
                //}
                vehicleEntitiy.vehicleRFID.Add(objVehicleRfIdReader);
            }
            if (request.RfIdCardsAssigneds is not null && request.RfIdCardsAssigneds.Count() > 0)
            {

                foreach (var rdIdCard in request.RfIdCardsAssigneds)
                {
                    if (request.RfIdCardsAssigneds != null && request.RfIdCardsAssigneds.Count() > 0)
                    {
                        var dataDublicate = request.RfIdCardsAssigneds.GroupBy(x => new { x.Name }).Where(x => x.Count() > 1).ToList();
                        if (dataDublicate != null && dataDublicate.Count() > 0)
                        {
                            foreach (var name in dataDublicate)
                            {
                                var alreadyVehicleRFID = await _vehicleRepo.GetVehicleRFIDDetailsByName(name.Key.Name);
                                if (alreadyVehicleRFID != null)
                                {
                                    vehicleResponse.id = -5;  // RfID is already assigned to vehicle 
                                    return vehicleResponse;
                                }
                                vehicleResponse.VIN = name.Key.Name + ", " + vehicleResponse.VIN;
                            }
                            return vehicleResponse;
                        }
                        else
                        {
                            foreach (var rfIdCard in request.RfIdCardsAssigneds)
                            {
                                var alreadyVehicleRFID = await _vehicleRepo.GetVehicleRFIDDetailsByName(rfIdCard.Name);
                                if (alreadyVehicleRFID != null)
                                {
                                    vehicleResponse.id = -5;  // RfID is already assigned to vehicle 
                                    vehicleResponse.VIN = rfIdCard.Name;
                                    return vehicleResponse;
                                }
                            }
                        }
                    }
                    objVehicleRfIdReader = new VehicleRFID();
                    objVehicleRfIdReader.Name = rdIdCard.Name;
                    objVehicleRfIdReader.CreatedBy = request.CreatedBy;
                    objVehicleRfIdReader.ModifiedBy = request.CreatedBy;
                    objVehicleRfIdReader.ModifiedOn = DateTime.Now;
                    objVehicleRfIdReader.CreatedOn = DateTime.Now;
                    objVehicleRfIdReader.IsActive = rdIdCard.IsActive;
                    VehicleDTO dt = await _vehicleRepo.GetVehicleByVinNumber(request.VIN);
                    if (dt != null)
                    {
                        objVehicleRfIdReader.VehicleId = dt.Id;
                    }
                    vehicleEntitiy.vehicleRFID.Add(objVehicleRfIdReader);
                }
            }

            vehicleResponse = await _externalvehicleRepo.CreateNewVehicle(vehicleEntitiy);
            return vehicleResponse;
        }
    }
}
