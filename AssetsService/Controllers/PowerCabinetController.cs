using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
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

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerCabinetController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<PowerCabinetController> _logger;
        string JSONString = string.Empty;
        public PowerCabinetController(IMediator mediator, ILogger<PowerCabinetController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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

        [HttpGet("getpowercabinetbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetPowerCabinetById(long Id)
        {

            try
            {
                PowerCabinet powerCabinet = await _mediator.Send(new GetPowerCabinetByIdQuery(Id));
                _logger.LogInformation("Get the data of Power Cabinet by Id");
                return getjson(powerCabinet);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());
            }
            return JSONString;

        }

        [HttpGet("getallpowerCabinet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllPowerCabinet()
        {
            
            try
            {
                List<PowerCabinet> res = await _mediator.Send(new GetAllPowerCabinetQuery());
                _logger.LogInformation("Get all the data of Power Cabinet");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }

        [HttpPost("createpowerCabinet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PowerCabinet>> CreatePowerCabinet([FromBody] CreatePowerCabinetCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Power Cabinet successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "PowerCabinet not Created "
                };
            }
        }

        [HttpPut("updatepowerCabinet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PowerCabinetResponse>> UpdatePowerCabinet([FromBody] UpdatePowerCabinetCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update Power Cabinet successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Dispenser not Update "
                };
            }
        }



    }
}