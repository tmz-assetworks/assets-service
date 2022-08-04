using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{

    public class DeleteDispenserCommand : IRequest<DispenserResponse>
    {
        public long Id { get; set; }

        public bool IsActive { get; set; }
    }
}