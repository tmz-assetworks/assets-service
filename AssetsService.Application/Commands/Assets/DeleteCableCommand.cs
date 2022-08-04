using AssetsService.Core.Entities;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class DeleteCableCommand : IRequest<CableResponse>
    {
        public long Id { get; set; }

        public bool IsActive { get; set; }



    }
}
