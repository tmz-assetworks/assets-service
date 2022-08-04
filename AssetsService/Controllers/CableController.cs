using AssetsService.Application.Queries;
using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Queries;
using AssetsService.Core.Responses;
using AssetsService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CableController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        private readonly ILogger<CableController> _logger;
        string JSONString = String.Empty;
        public CableController(IMediator mediator, ILogger<CableController> logger)
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
        [HttpGet("GetAllCable")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<CableQueryResponse> GetAllCable()
        {
            CableQueryResponse cableQueryResponse = new CableQueryResponse();
            try
            {
                List<AssetsService.Core.Entities.Cable> res = await _mediator.Send(new GetAllCableQuery());
                cableQueryResponse.StatusMessage = "Record found";
                cableQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                cableQueryResponse.data = res;
                if (res.Count > 0)
                {
                    _logger.LogInformation("Get the all data of Cable");
                    return cableQueryResponse;
                }
                else
                {
                    _logger.LogInformation("Data not found");
                }
            }
            catch (Exception ex)
            {
                cableQueryResponse.StatusMessage = ex.Message.ToString();
                cableQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                cableQueryResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return cableQueryResponse;
        }
        [HttpGet("getCablebyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<CableQueryResponse> GetCableById(int id)
        {
            CableQueryResponse cableQueryResponse = new CableQueryResponse();
            try
            {
                _logger.LogInformation("Id of Cable controller is :" + JsonConvert.SerializeObject(id));
                Cable res = await _mediator.Send(new GetByIdCablesQuery(id));
                if (res != null)
                {
                    _logger.LogInformation("Get the data of Cable by Id");
                    return cableQueryResponse;
                }
                else
                {
                    _logger.LogInformation("Data not found");
                }
            }
            catch (Exception ex)
            {
                cableQueryResponse.StatusMessage = ex.Message.ToString();
                cableQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                cableQueryResponse.data = null;
                _logger.LogError(ex.ToString());
            }
            return cableQueryResponse;
        }
        [HttpPost("CreateCable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CableResponse>> CreateCable([FromBody] CreateCableCommand command)
        {
            try
            {
                _logger.LogInformation("Request Body of Cable controller is :" + command);
                var result = await _mediator.Send(command);
                    _logger.LogInformation("All Cable data saved successfully");
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
        [HttpPut("UpdateCable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CableResponse>> UpdateCable([FromBody] UpdateCableCommand command)
        {
            try
            {
                _logger.LogInformation("Request Body of Cable controller is :" + command);
                var result = await _mediator.Send(command);
                _logger.LogInformation("All Cable data updated successfully");
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
        [HttpDelete("DeleteCableById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CableResponse>> DeleteCable([FromBody] DeleteCableCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Cable data deleted successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Customer not Deleted "
                };
            }
        }
      
    }
}
