using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
namespace AssetsService.Application.Queries
{
    public class GetAllVechicleQuery : IRequest<List<AssetsService.Core.Entities.Vehicle>>
    {


    }
}
