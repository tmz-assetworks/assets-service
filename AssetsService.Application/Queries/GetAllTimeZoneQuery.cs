using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetAllTimeZoneQuery : IRequest<List<TimeZoneResponse>>
    {

    }
}
