using AssetsService.Application.Responses.Assets;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{
    public class IsActiveDispenserCommand : IRequest<DispenserResponse>
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
    }
}
