using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using System.Net;
using System.Text.Json;
using AssetsService.Application.Responses.Assets;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets.Pad;
using Serilog;
using Newtonsoft.Json;
using System.Dynamic;
using AssetsService.Core.Response;
using Microsoft.AspNetCore.Authorization;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PadController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PadController> _logger;
        string JSONString = String.Empty;

        public PadController(IMediator mediator, ILogger<PadController> logger)
        {
            _mediator = mediator;
            //_logger = logger;
        }
        [HttpPost]
        [Route("/asset/pad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> CreatePad([FromBody] CreatePadCommand command)
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
                expendo.statusCode = (int)HttpStatusCode.BadRequest;
                expendo.statusMessage = "Operation Failed!";
                Log.Information("error occurred :" + ex.Message);

            }
            return (expendo);
        }

        [HttpGet]
        [Route("/asset/pad")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<AllPad>> GetAllPad()
        {
            AllPad allPad = new AllPad();
            try
            {
                List<GetPadResponse> res = await _mediator.Send(new GetAllPadQuery());
                allPad.StatusCode = (int)HttpStatusCode.OK;
                allPad.StatusMessage = "Record found";
                allPad.data = res;
                //_logger.LogInformation("Get the all data of Pad");
            }
            catch (Exception ex)
            {
                allPad.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                allPad.StatusCode = (int)HttpStatusCode.NotFound;
                allPad.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return allPad;
        }


        [HttpPost("GetAllPadData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AllPadData> GetAllPadData(PadDataRequest padDataRequest)
        {
            AllPadData allModelDataResponse = new AllPadData();
            try
            {
                List<GetPadResponse> res = await _mediator.Send(new GetAllPadQuery());
                List<PadResults> modelResults = res.Select(x => new PadResults { Id = x.Id, PadName = x.PadName }).Where(m => m.PadName != "").OrderBy(m => m.PadName).ToList();
                allModelDataResponse.StatusMessage = "Record found";
                allModelDataResponse.StatusCode = (int)HttpStatusCode.OK;
                allModelDataResponse.data = modelResults;
            }
            catch (Exception ex)
            {
                allModelDataResponse.StatusMessage = ex.Message.ToString();
                allModelDataResponse.StatusCode = (int)HttpStatusCode.NotFound;
                allModelDataResponse.data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allModelDataResponse;
        }

        [HttpGet("getpadbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PadById>> GetPadById(int id)
        {
            PadById padById = new PadById();
            try
            {
                GetPadResponse pad = await _mediator.Send(new GetByIdPadQuery(id));
                padById.StatusCode = (int)HttpStatusCode.OK;
                padById.StatusMessage = "Record found";
                padById.data = pad;
                if(pad==null)
                    padById.StatusMessage = "Record not found";
                //_logger.LogInformation("Get the data of Pad by Id");

            }
            catch (Exception ex)
            {
                padById.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                padById.StatusCode = (int)HttpStatusCode.NotFound;
                padById.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());
            }
            return padById;
        }
        [HttpPut("updatepad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> UpdatePad([FromBody] UpdatePadCommand command)
        {
            dynamic expandoObject = new ExpandoObject();
            try
            {
                expandoObject.statusCode = 200;
                if (command.Id < 0)
                {
                    expandoObject.statusMessage = "Please provide Pad Id value.";
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
        [HttpPut("IsActivePad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> IsActivePad([FromBody] IsActivePadCommand command)
        {
            dynamic expandoObject = new ExpandoObject();
            try
            {
                expandoObject.statusCode = 200;
                if (command.Id < 0)
                {
                    expandoObject.statusMessage = "Please provide Pad Id value.";
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = "Please provide ModifiedBy value.";
                    return expandoObject;
                }
                var result = await _mediator.Send(command);

                if (result is not null && result.Id > 0)
                    expandoObject.statusMessage = "Record status changed successfully.";
                else
                    expandoObject.statusMessage = "Record not found.";

                return expandoObject;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                expandoObject = new ExpandoObject();
                expandoObject.StatusMessage = "Opeartion failed!";
                expandoObject.statusCode = HttpStatusCode.BadRequest;
                Log.Information("error occurred :" + ex.Message);
            }
            return expandoObject;
        }
    
    
    }
}
