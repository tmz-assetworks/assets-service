using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetLocationsDispenserDetailsQuery : IRequest<List<Core.Response.LocationsDispenserDetails>>
    // public class GetLocationsDispenserDetailsQuery : IRequest<List<Core.Response.LocationsDispenserDetails>>
    {
        public List<long> Id { get; set; }

       // public LocationDispenserParams objPamams { get; set; }
        public GetLocationsDispenserDetailsQuery(List<long> id)
        {
            Id = id;
           // this.objPamams = _objPamams;
        }
    }
}