using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Dynamic;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PowerCabinetController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<PowerCabinetController> _logger;
        string JSONString = string.Empty;
        public PowerCabinetController(IMediator mediator, ILogger<PowerCabinetController> logger)
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

        [HttpGet("getpowercabinetbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PowerCabinetById>>  GetPowerCabinetById(long Id)
        {
            PowerCabinetById powerCabinetById = new PowerCabinetById();

            try
            {
                GetPowerCabinetResponse powerCabinet = await _mediator.Send(new GetPowerCabinetByIdQuery(Id));
                powerCabinetById.StatusCode = (int)HttpStatusCode.OK;
                powerCabinetById.StatusMessage = "Record found";
                powerCabinetById.data = powerCabinet;
                if (powerCabinet == null)
                    powerCabinetById.StatusMessage = "Record not found";

            }
            catch (Exception ex)
            {
                powerCabinetById.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                powerCabinetById.StatusCode = (int)HttpStatusCode.NotFound;
                powerCabinetById.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());
            }
            return powerCabinetById;

        }

        [HttpGet("getallpowerCabinet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllPowerCabinet>> GetAllPowerCabinet()
        {
            AllPowerCabinet allPowerCabinet = new AllPowerCabinet();
            try
            {
                List<PowerCabinet> res = await _mediator.Send(new GetAllPowerCabinetQuery());
                allPowerCabinet.StatusCode = (int)HttpStatusCode.OK;
                allPowerCabinet.StatusMessage = "Record found";
                allPowerCabinet.data = res;
                //_logger.LogInformation("Get all the data of Power Cabinet");
            }
            catch (Exception ex)
            {
                allPowerCabinet.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                allPowerCabinet.StatusCode = (int)HttpStatusCode.NotFound;
                allPowerCabinet.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());

            }
            return allPowerCabinet;
        }
        [HttpGet("GetPowerCabinetData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllPowerCabinetData>> GetPowerCabinetData()
        {
            AllPowerCabinetData allPowerCabinetData = new AllPowerCabinetData();
            try
            {
                List<GetPowerCabinetResponse> powerCabinets = await _mediator.Send(new GetPowerCabinetDataQuery());
                allPowerCabinetData.StatusMessage = "Record found";
                allPowerCabinetData.StatusCode = (int)HttpStatusCode.OK;
                allPowerCabinetData.Data = powerCabinets.Select(x => new PowerCabinetResults { Id = x.Id, SerialNumber = x.SerialNumber }).Where(m => m.SerialNumber != "").OrderBy(m => m.SerialNumber).ToList();

            }
            catch (Exception ex)
            {
                allPowerCabinetData.StatusMessage = ex.Message.ToString();
                allPowerCabinetData.StatusCode = (int)HttpStatusCode.NotFound;
                allPowerCabinetData.Data = null;
                Log.Information("error occurred :" + ex.Message);
            }
            return allPowerCabinetData;
        }
        [HttpPost("createpowerCabinet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> CreatePowerCabinet([FromBody] CreatePowerCabinetCommand command)
        {
            dynamic expendo = new ExpandoObject();

            try
            {

                var result = await _mediator.Send(command);
                if (result.Id > 0)
                {

                    expendo.statusCode = 200;
                    expendo.Id = result.Id;
                    expendo.statusMessage = "Record Saved Successfully";
                }
                else
                {

                    if (result.Id == -1)
                    {
                        expendo.statusCode = 200;
                        expendo.statusMessage = "Duplicate AssetId can not be created.";
                        return BadRequest(expendo);
                    }
                    else
                    {
                        expendo.statusCode = 200;
                        expendo.statusMessage = "Record not saved";
                    }
                }

               
            }
            catch (Exception ex)
            {
                expendo = new ExpandoObject();
                //_logger.LogError(ex.ToString());
                expendo.StatusCode = (int)HttpStatusCode.BadRequest;
                expendo.StatusMessage = "Operation Failed!";
                Log.Information("error occurred :" + ex.Message);

            }
            return (expendo);
        }

        [HttpPut("updatepowerCabinet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> UpdatePowerCabinet([FromBody] UpdatePowerCabinetCommand command)
        {
            dynamic expandoObject = new ExpandoObject();
            try
            {
                expandoObject.statusCode = 200;
                if (command.Id < 0)
                {
                    expandoObject.statusMessage = "Please provide PowerCabinet Id value.";
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = "Please provide ModifiedBy value.";
                    return expandoObject;
                }
                var data = await _mediator.Send(command);
                if (data is not null && data.Id > 0)
                {
                    expandoObject.statusMessage = "Record updated successfully.";
                }
                else
                {
                    expandoObject.statusMessage = "Record not found.";
                }
                return expandoObject;
            }
            catch (Exception ex)
            {
                expandoObject = new ExpandoObject();
                //_logger.LogError(ex.ToString());
                expandoObject.StatusCode = (int)HttpStatusCode.BadRequest;
                expandoObject.StatusMessage = "Operation Failed!";
                Log.Information("error occurred :" + ex.Message);
            }
            return expandoObject;
        }



    }
}