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
using AssetsService.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Responses.Assets;

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
        TokenBase _token;
        public PadController(IMediator mediator, ILogger<PadController> logger, TokenBase token)
        {
            _mediator = mediator;
            _token = token;
            //_logger = logger;
        }
        [HttpPost]
        [Route("CreatePad")]
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
                    expendo.statusMessage = RespnoseMessage.Record_Save_Successfully;
                }
                else
                {
                    if (result.Id == -1)
                    {
                        expendo.statusCode = 200;
                        expendo.statusMessage = RespnoseMessage.Duplicate_AssetId_can;
                        return BadRequest(expendo);
                    }
                    else
                    {
                        expendo.statusCode = 200;
                        expendo.statusMessage = RespnoseMessage.Record_Not_Saved;
                    }
                }
            }
            catch (Exception ex)
            {
                expendo = new ExpandoObject();
                //_logger.LogError(ex.ToString());
                expendo.statusCode = (int)HttpStatusCode.BadRequest;
                expendo.statusMessage = RespnoseMessage.Opeartion_Failed;
                Log.Information("error occurred :" + ex.Message);

            }
            return (expendo);
        }

        [HttpGet]
        [Route("pad")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<AllPad>> GetAllPad()
        {
            AllPad allPad = new AllPad();
            try
            {
                List<GetPadResponse> res = await _mediator.Send(new GetAllPadQuery());
                allPad.StatusCode = (int)HttpStatusCode.OK;
                allPad.StatusMessage = RespnoseMessage.Record_found;
                allPad.data = res;
                //_logger.LogInformation("Get the all data of Pad");
            }
            catch (Exception ex)
            {
                allPad.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message.ToString();
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
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                List<ListDropDown> res = await _mediator.Send(new GetAllPadDataQuery(padDataRequest.dispenserId));
                List<PadResults> modelResults = res.Select(x => new PadResults { Id = x.Id, PadName = x.Name,IsActive=x.IsActive }).Where(m => m.PadName != "")                    
                    .OrderBy(m => m.PadName).ToList();
                allModelDataResponse.StatusMessage = RespnoseMessage.Record_found;
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
                padById.StatusMessage = RespnoseMessage.Record_found;
                padById.data = pad;
                if(pad==null)
                    padById.StatusMessage = RespnoseMessage.Record_not_found;
                //_logger.LogInformation("Get the data of Pad by Id");

            }
            catch (Exception ex)
            {
                padById.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message.ToString();
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
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_Pad_Id_value;
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_ModifiedBy_value;
                    return expandoObject;
                }
                var data = await _mediator.Send(command);
                if (data is not null && data.Id > 0)
                {
                    expandoObject.statusMessage = RespnoseMessage.Record_Updated_Successfully;
                    return expandoObject;
                }
                if (data.Id == -1)
                {
                    expandoObject.statusMessage = RespnoseMessage.Duplicate_AssetId_can;
                    return BadRequest(expandoObject);
                }
                else
                {
                    expandoObject.statusMessage = RespnoseMessage.Record_not_found;
                }
                return expandoObject;
            }
            catch (Exception ex)
            {
                expandoObject = new ExpandoObject();
                //_logger.LogError(ex.ToString());
                expandoObject.StatusCode = (int)HttpStatusCode.BadRequest;
                expandoObject.StatusMessage = RespnoseMessage.Opeartion_Failed;
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
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_Pad_Id_value;
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_ModifiedBy_value;
                    return expandoObject;
                }
                var result = await _mediator.Send(command);

                if (result is not null && result.Id > 0)
                    expandoObject.statusMessage = RespnoseMessage.Record_status_changed_successfully;
                else
                    expandoObject.statusMessage = RespnoseMessage.Record_not_found;

                return expandoObject;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                expandoObject = new ExpandoObject();
                expandoObject.StatusMessage = RespnoseMessage.Opeartion_Failed;
                expandoObject.statusCode = HttpStatusCode.BadRequest;
                Log.Information("error occurred :" + ex.Message);
            }
            return expandoObject;
        }
    
    
    }
}
