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
using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleResponse>
    {
        private readonly IVehicleRepository _vehicleRepo;

        public CreateVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }
        public async Task<CreateVehicleResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)

        {
            CreateVehicleResponse vehicleResponse = new CreateVehicleResponse();
            var vehicleEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Vehicle>(request);

            if (vehicleEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            if (request.RfIdCardsAssigneds is not null && request.RfIdCardsAssigneds.Count() > 0)
            {
                VehicleRFID objVehicleRfIdReader = null;
                vehicleEntitiy.vehicleRFID = new List<VehicleRFID>();
                vehicleEntitiy.CreatedOn = DateTime.Now;
                vehicleEntitiy.ModifiedOn = DateTime.Now;
                foreach (var rdIdCard in request.RfIdCardsAssigneds)
                {
                    if (request.RfIdCardsAssigneds != null && request.RfIdCardsAssigneds.Count() > 0)
                    {
                        var dataDublicate = request.RfIdCardsAssigneds.GroupBy(x => new { x.Name }).Where(x => x.Count() > 1).ToList();
                        if (dataDublicate != null && dataDublicate.Count() > 0)
                        {
                            foreach(var name in dataDublicate)
                            {

                                vehicleResponse.VIN = name.Key.Name + ", " + vehicleResponse.VIN;
                            }
                            return vehicleResponse;
                        }
                    }
                    objVehicleRfIdReader = new VehicleRFID();
                    objVehicleRfIdReader.Name = rdIdCard.Name;
                    objVehicleRfIdReader.CreatedBy = request.CreatedBy;
                    objVehicleRfIdReader.ModifiedBy = request.CreatedBy;
                    objVehicleRfIdReader.ModifiedOn = DateTime.Now;
                    objVehicleRfIdReader.CreatedOn = DateTime.Now;
                    objVehicleRfIdReader.IsActive = rdIdCard.IsActive;
                    vehicleEntitiy.vehicleRFID.Add(objVehicleRfIdReader);

                }
            }
            vehicleResponse = await _vehicleRepo.CreateVehicle(vehicleEntitiy);
            return vehicleResponse;
        }
    }
}
