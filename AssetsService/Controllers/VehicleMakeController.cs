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
    public class VehicleMakeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<VehicleMakeController> _logger;
        string JSONString = String.Empty;
        public VehicleMakeController(IMediator mediator, ILogger<VehicleMakeController> logger)
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
        [HttpPost("CreateVehicleMake")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleMakeResponse>> CreateVehicle([FromBody] CreateVehicleMakeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Vehicle Make successfully");
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
        [HttpGet("GetAllVehicleMake")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllVehicleMake()
        {
            
            try
            {
                List<AssetsService.Core.Entities.VehicleMake> res = await _mediator.Send(new GetAllVehicleMakeQuery());
                _logger.LogInformation("Get all the data of Vehicle Make");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }
        [HttpGet("getVehicleMakebyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetVehicleMakeById(int id)
        {
            try
            {
                VehicleMake res = await _mediator.Send(new GetByIdVehicleMakeQuery(id));
                _logger.LogInformation("Get the data of Vehicle Make by Id");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;


        }
        [HttpPut("UpdateVehicleMake")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> UpdateVehicleMake([FromBody] UpdateVehicleMakeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update Vehicle Make successfully");
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
        [HttpDelete("DeleteVehicleMakeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleMakeResponse>> DeleteVehicleMakeById([FromBody] DeleteVehicleMakeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Delete Vehicle Make successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Vehicle Make not Deleted "
                };
            }
        }
    }
}
