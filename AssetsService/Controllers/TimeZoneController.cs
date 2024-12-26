using AssetsService.Application.Queries;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Queries;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Net;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TimeZoneController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TimeZoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllTimeZones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AllTimeZone> GetAllTimeZones()
        {
            AllTimeZone allTimeZoneResponse = new AllTimeZone();
            try
            {
                List<TimeZoneResponse> timezones = await _mediator.Send(new GetAllTimeZoneQuery());
                if (timezones.Count > 0)
                {
                    allTimeZoneResponse.StatusMessage = RespnoseMessage.Record_found;
                    allTimeZoneResponse.StatusCode = (int)HttpStatusCode.OK;
                    allTimeZoneResponse.Data = timezones;
                }
                else
                {
                    allTimeZoneResponse.StatusMessage = RespnoseMessage.Record_not_found;
                    allTimeZoneResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    allTimeZoneResponse.Data = timezones;
                }
            }
            catch (Exception ex)
            {
                allTimeZoneResponse.StatusMessage = ex.Message.ToString();
                allTimeZoneResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                allTimeZoneResponse.Data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allTimeZoneResponse;
        }
    }
}
