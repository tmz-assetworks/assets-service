using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetLocationsDispenserformapQuery : IRequest<List<Core.Response.LocationsDispenser>>
    {
        public List<long> Id { get; set; }
        public GetLocationsDispenserformapQuery(List<long> id)
        {
            Id = id;
        }
    }
}
