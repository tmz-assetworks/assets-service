using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<VehicleController> _logger;
        string JSONString = String.Empty;
        public VehicleController(IMediator mediator, ILogger<VehicleController> logger)
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
        [HttpGet("GetAllVechicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllVechicle()
        {
            List<AssetsService.Core.Entities.Vehicle> obj = await _mediator.Send(new GetAllVechicleQuery());
            try
            {
                List<AssetsService.Core.Entities.Vehicle> res = await _mediator.Send(new GetAllVechicleQuery());
                _logger.LogInformation("Get all the data of Vehicle");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }
        [HttpGet("getVehiclebyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetVehicleById(int id)
        {
            try
            {
                Vehicle res = await _mediator.Send(new GetByIdVehicleQuery(id));
                _logger.LogInformation("Get the data of Vehicle by Id");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;


        }
        [HttpPost("CreateVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Vehicle successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Vehicle not Created "
                };
            }
        }
        [HttpPut("UpdateVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> UpdateCable([FromBody] UpdateVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update Vehicle successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Vehicle not Update "
                };
            }
        }
        [HttpDelete("DeleteVehicleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> DeleteVehicle([FromBody] DeleteVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Delete Vehicle successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Vehicle not Deleted "
                };
            }
        }
    }
}
