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

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadControllerApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PadControllerApiController> _logger;
        string JSONString = String.Empty;

        public PadControllerApiController(IMediator mediator, ILogger<PadControllerApiController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        [Route("/asset/pad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PadResponse>> CreatePad([FromBody] CreatePadCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("All Pad data saved successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Cable not Created "
                };
            }
        }

        [HttpGet]
        [Route("/asset/pad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllPad()
        {
            try
            {
                List<AssetsService.Core.Entities.Pad> res = await _mediator.Send(new GetAllPadQuery());
                _logger.LogInformation("Get the all data of Pad");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());
            }
            return JSONString;
        }
        [HttpGet("getpadbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetPadById(int id)
        {
            try
            {
                Pad pad = await _mediator.Send(new GetByIdPadQuery(id));
                _logger.LogInformation("Get the data of Pad by Id");
                return getjson(pad);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());
            }
            return JSONString;
        }
        [HttpPut("updatepad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PadResponse>> UpdatePad([FromBody] UpdatePadCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Request body of pad controller is :" + JsonConvert.SerializeObject(command));
                _logger.LogInformation("All Pad data updated successfully");
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "User not Update "
                };
            }
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
    }
}
