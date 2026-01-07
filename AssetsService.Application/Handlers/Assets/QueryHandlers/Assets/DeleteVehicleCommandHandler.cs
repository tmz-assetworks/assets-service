using MediatR;
using AssetsService.Core.Repositories;
using AssetsService.Application.Queries;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepo;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _vehicleRepo.DeleteVehicleById(request.VehicleId);
        }
    }
}
