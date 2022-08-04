using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
using AssetsService.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using AssetsService.Application.Responses.Assets;
using AssetsService.Application.Queries;
using AssetsService.Core.Responses.Assets;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargingInfrastureController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ChargingInfrastureController> _logger;
        string JSONString = string.Empty;
        public ChargingInfrastureController(IMediator mediator, ILogger<ChargingInfrastureController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        string getjson(object res)
        {
            string JSONString = String.Empty;
            if (res != null)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var data = System.Text.Json.JsonSerializer.Serialize(res, options);

                JSONString = "{\n  \"StatusCode\" : " + (int)HttpStatusCode.OK + ",\n  \"StatusMessage\" : \"Record found\",\n  \"data\" : " + data + " \n}";
            }
            else
            {
                JSONString = "{\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + ",\n  \"StatusMessage\" : \"Record not found\",\n  \"data\" : " + null + " \n}";
            }
            return JSONString;
        }

        [HttpGet("getTotalLocationAndCharger")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<TotalLocationAndChargerResponse> GetTotalLocationAndCharger()
        {
            TotalLocationAndChargerResponse totalLocationAndChargerResponse = null;
            try
            {
                totalLocationAndChargerResponse = new TotalLocationAndChargerResponse();
                 totalLocationAndChargerResponse = await _mediator.Send(new GetTotalLocationAndChargerQuery());
                totalLocationAndChargerResponse.StatusCode = (int)HttpStatusCode.OK;
                totalLocationAndChargerResponse.StatusMessage = "Record found";
                _logger.LogInformation("Get all data of Location");
                return totalLocationAndChargerResponse;
            }
            catch (Exception ex)
            {
                totalLocationAndChargerResponse.StatusMessage = "Faild!";
                totalLocationAndChargerResponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogError(ex.ToString());
            }
            return totalLocationAndChargerResponse;
        }
    }
}