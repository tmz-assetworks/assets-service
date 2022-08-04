using AssetsService.Application.Commands.Assets.RFId;
using AssetsService.Application.Queries;
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
    public class RFIdReaderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RFIDReader> _logger;
        string JSONString = String.Empty;
        public RFIdReaderController(IMediator mediator, ILogger<RFIDReader> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        [Route("/assets/rfIdReader")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddRFid([FromBody] CreateRFIdCommand createRFIdCommand)
        {
            try
            {
                var result = await _mediator.Send(createRFIdCommand);
                _logger.LogInformation("Create RFId Reader successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "RFId not Created "
                };
            }
        }

        [HttpGet]
        [Route("/assets/getallRfIdReader")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllRfId()
        {
            List<AssetsService.Core.Entities.RFIDReader> obj = await _mediator.Send(new GetAllRFIdQuery());
            try
            {
                List<AssetsService.Core.Entities.RFIDReader> res = await _mediator.Send(new GetAllRFIdQuery());
                _logger.LogInformation("Get all the data of RfId reader");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }
      
        [HttpGet("/assets/getbyIdRfIdReader")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetByIdRfId(int id)
        {
            try
            {
                RFIDReader rFIDReader = await _mediator.Send(new GetByIdRfIdReaderQuery(id));
                _logger.LogInformation("Get the data of RFId reader by Id");
                return getjson(rFIDReader);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
            }
            return JSONString;
        }
        [HttpPut("/asset/rfIdReader")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AssetsService.Application.Responses.Assets.RFIdResponse>> UpdateRfIdReader([FromBody] UpdateRFIdCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("RFId reader updated successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
;                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "RFId not Update "
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
