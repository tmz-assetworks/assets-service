using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses.Assets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Dynamic;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<VehicleMakeController> _logger;
        string JSONString = String.Empty;
        public VehicleMakeController(IMediator mediator, ILogger<VehicleMakeController> logger)
        {
            _mediator = mediator;
            //_logger = logger;
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
                //_logger.LogInformation("Create Vehicle Make successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = RespnoseMessage.Exception,
                    StatusCode = 404,
                    Content = RespnoseMessage.VehicleMake_Not_Created
                };
            }
        }
        [HttpGet("GetAllVehicleMake")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllVehicleMake>> GetAllVehicleMake()
        {
            AllVehicleMake allVehicleMake = new AllVehicleMake();

            try
            {
                List<AssetsService.Core.Entities.VehicleMake> res = await _mediator.Send(new GetAllVehicleMakeQuery());
                allVehicleMake.StatusCode = (int)HttpStatusCode.OK;
                allVehicleMake.StatusMessage = RespnoseMessage.Record_found;
                allVehicleMake.data = res;
                //_logger.LogInformation("Get all the data of Vehicle Make");
            }
            catch (Exception ex)
            {
                allVehicleMake.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message.ToString();
                allVehicleMake.StatusCode = (int)HttpStatusCode.NotFound;
                allVehicleMake.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return allVehicleMake;
        }
        [HttpGet("getVehicleMakebyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleMakeById>> GetVehicleMakeById(int id)
        {
            VehicleMakeById vehicleMakeById = new VehicleMakeById();
            try
            {
                VehicleMake res = await _mediator.Send(new GetByIdVehicleMakeQuery(id));
                vehicleMakeById.StatusCode = (int)HttpStatusCode.OK;
                vehicleMakeById.StatusMessage = RespnoseMessage.Record_found;
                vehicleMakeById.data = res;
                //_logger.LogInformation("Get the data of Vehicle Make by Id");
            }
            catch (Exception ex)
            {
                vehicleMakeById.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message.ToString();
                vehicleMakeById.StatusCode = (int)HttpStatusCode.NotFound;
                vehicleMakeById.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return vehicleMakeById;


        }
        [HttpPut("UpdateVehicleMake")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> UpdateVehicleMake([FromBody] UpdateVehicleMakeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Update Vehicle Make successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = RespnoseMessage.Exception,
                    StatusCode = 404,
                    Content = RespnoseMessage.Record_Not_Updated
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
                //_logger.LogInformation("Delete Vehicle Make successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = RespnoseMessage.Exception,
                    StatusCode = 404,
                    Content = RespnoseMessage.Not_Deleted
                };
            }
        }


        // [HttpGet("GetVehicleMakeDDLList")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public async Task<ActionResult<ExpandoObject>> GetVehicleMakeDDLList()
        // {
        //     dynamic vehicleMakeDDLResponse = new ExpandoObject();  
        //     try
        //     {
        //         vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.OK;
        //         vehicleMakeDDLResponse.statusMessage = "Record found.";
        //         List<ListDropDown> res = await _mediator.Send(new GetVechicleMakeDDLQuery());

        //         vehicleMakeDDLResponse.data = res;
        //         //_logger.LogInformation("Get all the data of Vehicle Make.");
        //         return vehicleMakeDDLResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         vehicleMakeDDLResponse.statusMessage = "Operaion failed!";
        //         vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.NotFound;
        //         vehicleMakeDDLResponse.data = null;
        //         //_logger.LogError(ex.ToString());

        //     }
        //     return vehicleMakeDDLResponse;
        // }
    }
}
