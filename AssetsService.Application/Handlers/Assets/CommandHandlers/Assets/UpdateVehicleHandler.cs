using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, CreateVehicleResponse>
    {
        private readonly IVehicleRepository _vehicleRepo;

        public UpdateVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }
        public async Task<CreateVehicleResponse> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)

        {
            CreateVehicleResponse vehicleResponse = new CreateVehicleResponse();
            if (request.Id <= 0)
            {
                throw new ApplicationException("Invalid Vehicle Id.");
            }

            var vehicledetails = _vehicleRepo.GetByIdVehicleData(request.Id);
            if (vehicledetails is not null && vehicledetails.Result is not null)
            {
                vehicledetails.Result.ModifiedBy = request.ModifiedBy;
                vehicledetails.Result.VIN = request.VIN;
                vehicledetails.Result.LicencePlate = request.LicencePlate;
                vehicledetails.Result.DomicileLocation = request.DomicileLocation;
                vehicledetails.Result.VehicleMacAddress = request.VehicleMacAddress;
                 vehicledetails.Result.ModelYear = request.ModelYear;
                vehicledetails.Result.VehicleModelId = request.VehicleModelId;
                vehicledetails.Result.VehicleMakeId = request.VehicleMakeId;
                vehicledetails.Result.Department = request.Department;
                vehicledetails.Result.ModifiedOn = DateTime.Now;
            }

            if (request.RfIdCardsAssigneds != null && request.RfIdCardsAssigneds.Count() > 0)
            {

                List<VehicleRFID> cardsAssigned = new List<VehicleRFID>();
                VehicleRFID vehicle = null;
                var dataDublicate = request.RfIdCardsAssigneds.GroupBy(x => new { x.Name }).Where(x => x.Count() > 1).ToList();
                if (dataDublicate != null && dataDublicate.Count() > 0)
                {
                    foreach (var name in dataDublicate)
                    {
                        vehicleResponse.VIN = name.Key.Name + ", " + vehicleResponse.VIN;
                    }
                    return vehicleResponse;
                }
                foreach (var item in request.RfIdCardsAssigneds.Where(m => m.Id == 0))
                {
                    vehicle = new VehicleRFID();
                    vehicle.CreatedBy = request.ModifiedBy;
                    vehicle.ModifiedBy = request.ModifiedBy;
                    vehicle.ModifiedOn = DateTime.Now;
                    vehicle.Name = item.Name;
                    vehicle.IsActive = item.IsActive;
                    vehicle.VehicleId = request.Id;
                    cardsAssigned.Add(vehicle);
                }
                foreach (var item in request.RfIdCardsAssigneds.Where(m => m.Id > 0))
                {
                    vehicle = await _vehicleRepo.GetVehicleRFIDDetails(item.Id);
                    vehicle.IsActive = item.IsActive;
                    vehicle.Name = item.Name;
                    cardsAssigned.Add(vehicle);
                }
                vehicledetails.Result.vehicleRFID = cardsAssigned;
            }
            var vehicleResponses = await _vehicleRepo.UpdateVehicle(vehicledetails.Result);
            return vehicleResponses;
        }
    }
}


