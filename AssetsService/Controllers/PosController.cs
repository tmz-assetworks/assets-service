using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
using AssetsService.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PosController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<PosController> _logger;
        string JSONString = String.Empty;
        public PosController(IMediator mediator, ILogger<PosController> logger)
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
        [HttpGet("GetAllPos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllPos>> GetAllPos()
        {
            AllPos allPos = new AllPos();
            try
            {
                List<AssetsService.Core.Entities.Pos> res = await _mediator.Send(new GetAllPosQuery());
                allPos.StatusCode = (int)HttpStatusCode.OK;
                allPos.StatusMessage = "Record found";
                allPos.data = res;
                //_logger.LogInformation("Get all the data of Pos");
            }
            catch (Exception ex)
            {
                allPos.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                allPos.StatusCode = (int)HttpStatusCode.NotFound;
                allPos.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return allPos;
        }


        [HttpGet("getPosbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PosById>> GetPosById(int id)
        {
            PosById posById = new PosById();
            try
            {
                Pos res = await _mediator.Send(new GetByIdPosQuery(id));
                posById.StatusCode = (int)HttpStatusCode.OK;
                posById.StatusMessage = "Record found";
                posById.data = res;
                //_logger.LogInformation("Get the data of Pos by Id");

            }
            catch (Exception ex)
            {
                posById.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                posById.StatusCode = (int)HttpStatusCode.NotFound;
                posById.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return posById;


        }
        [HttpPost("CreatePos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PosResponse>> CreatePos([FromBody] CreatePosCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Create Pos successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Pos not Created "
                };
            }
        }
        [HttpPut("UpdatePos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PosResponse>> UpdatePos([FromBody] UpdatePosCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Update Pos successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Pos not Created "
                };
            }
        }
    }
}