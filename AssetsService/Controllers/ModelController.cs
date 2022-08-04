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
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ModelController> _logger;
        string JSONString = String.Empty;
        public ModelController(IMediator mediator, ILogger<ModelController> logger)
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
        [HttpGet("GetAllModel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllModel()
        {       
            try
            {
                List<AssetsService.Core.Entities.Model> res = await _mediator.Send(new GetAllModelQuery());
                _logger.LogInformation("Get all the data of Model");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }
        [HttpGet("getModelbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetModelById(int id)
        {
            try
            {
                Model res = await _mediator.Send(new GetByIdModelQuery(id));
                _logger.LogInformation("Get the data of Model by Id");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;


        }
        [HttpPost("CreateModel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModelResponse>> CreateModel([FromBody] CreateModelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Model successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Model not Created "
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
                _logger.LogInformation("Updatwe Model successfully");
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
        [HttpDelete("DeleteModelById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> DeleteModel([FromBody] DeleteModelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Delete Model successfully");
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
