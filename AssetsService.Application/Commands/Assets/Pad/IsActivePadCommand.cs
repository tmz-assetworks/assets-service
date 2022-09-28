using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets.Pad
{
    public class IsActivePadCommand : IRequest<PadResponse>
    {
        public long Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string ModifiedBy { get; set; }
    }
}
