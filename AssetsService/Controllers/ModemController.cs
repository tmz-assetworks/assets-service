
using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
using AssetsService.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModemController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        private readonly ILogger<ModemController> _logger;
        string JSONString = String.Empty;
        public ModemController(IMediator mediator, ILogger<ModemController> logger)
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
        [HttpGet("GetAllModem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllModem()
        {       
            try
            {
                List<AssetsService.Core.Entities.Modem> res = await _mediator.Send(new GetAllModemQuery());
                _logger.LogInformation("Get all the data of Modem");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }
        [HttpGet("getModembyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetModemById(int id)
        {
            try
            {
                Modem res = await _mediator.Send(new GetByIdModemsQuery(id));
                _logger.LogInformation("Get the data of Modem by Id");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;


        }
        [HttpPost("CreateModem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModemResponse>> CreateModem([FromBody] CreateModemCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Modem successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Modem not Created "
                };
            }
        }
        [HttpPut("UpdateModem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModemResponse>> UpdateModem([FromBody] UpdateModemCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update Modem successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Modem not Created "
                };
            }
        }
    }




        }

     


