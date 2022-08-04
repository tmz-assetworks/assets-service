using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetLocationsDispenserForLocationQuery : IRequest<List<Core.Response.LocationDispenserForLocation>>
    {
        public List<long> Id { get; set; }
        public GetLocationsDispenserForLocationQuery(List<long> id)
        {
            Id = id;
        }
    }
}