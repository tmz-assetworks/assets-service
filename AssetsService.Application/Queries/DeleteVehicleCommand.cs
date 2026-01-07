using MediatR;
public class DeleteVehicleCommand : IRequest<bool>
{
    public int VehicleId { get; set; }
    public DeleteVehicleCommand(int vehicleId)
    {
        VehicleId = vehicleId;
    }
}
