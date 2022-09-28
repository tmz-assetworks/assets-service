using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{

    public class DeleteLocationCommand : IRequest<LocationResponse>
    {
        public long Id { get; set; }

        public bool IsActive { get; set; }
        public string UserId {get ; set;}

    }
}