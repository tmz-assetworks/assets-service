using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using System.Text.Json;
using static AssetsService.Core.Response.ModelResponse;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ModelController> _logger;
        string JSONString = String.Empty;
        public ModelController(IMediator mediator, ILogger<ModelController> logger)
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
        [HttpGet("GetAllModel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllModel>> GetAllModel()
        {

            AllModel allModel = new AllModel();
            try
            {
                var res = await _mediator.Send(new GetAllModelQuery());
                allModel.StatusMessage = RespnoseMessage.Record_found;
                allModel.StatusCode = (int)HttpStatusCode.OK;
                allModel.data = res;
                //_logger.LogInformation("Get all the data of Model");
            }
            catch (Exception ex)
            {
                allModel.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message.ToString();
                allModel.StatusCode = (int)HttpStatusCode.NotFound;
                allModel.data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allModel;
        }
        [HttpPost("GetAllModelData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AllModelData> GetAllModelData(ModelDataRequest modelDataRequest)
        {
            AllModelData allModelDataResponse = new AllModelData();
            try
            {
                List<AssetsService.Core.Entities.Model> models = await _mediator.Send(new GetAllModelDataQuery(modelDataRequest));
                List<ModelResults> modelResults = models.Select(x => new ModelResults { Id = x.Id,  ModelName = x.ModelName }).Where(m => m.ModelName != "").OrderBy(m => m.ModelName).ToList();
                allModelDataResponse.StatusMessage = RespnoseMessage.Record_found;
                allModelDataResponse.StatusCode = (int)HttpStatusCode.OK;
                allModelDataResponse.Data = modelResults;
            }
            catch (Exception ex)
            {
                allModelDataResponse.StatusMessage = ex.Message.ToString();
                allModelDataResponse.StatusCode = (int)HttpStatusCode.NotFound;
                allModelDataResponse.Data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allModelDataResponse;
        }
        [HttpGet("getModelbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModelById>> GetModelById(int id)
        {
            ModelById modelById = new ModelById();
            try
            {
                Model res = await _mediator.Send(new GetByIdModelQuery(id));
                modelById.StatusCode = (int)HttpStatusCode.OK;
                modelById.StatusMessage = RespnoseMessage.Record_found;
                modelById.data = res;

                //_logger.LogInformation("Get the data of Model by Id");
            }
            catch (Exception ex)
            {
                modelById.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message.ToString();
                modelById.StatusCode = (int)HttpStatusCode.NotFound;
                modelById.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return modelById;


        }
        [HttpPost("CreateModel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModelResponse>> CreateModel([FromBody] CreateModelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Create Model successfully");
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
                    Content = RespnoseMessage.Make_Master_not_Created
                };
            }
        }
        [HttpPut("UpdateModel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModelResponse>> UpdateCable([FromBody] UpdateModelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Updatwe Model successfully");
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
                    Content = RespnoseMessage.Vehicle_not_Updated
                };
            }
        }
        [HttpDelete("DeleteModelById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> DeleteModel([FromBody] DeleteModelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Delete Model successfully");
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
                    Content = RespnoseMessage.Vehicle_not_deleted
                };
            }
        }
    }
}
