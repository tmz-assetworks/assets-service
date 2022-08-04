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
    public class PosController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        private readonly ILogger<PosController> _logger;
        string JSONString = String.Empty;
        public PosController(IMediator mediator, ILogger<PosController> logger)
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
        [HttpGet("GetAllPos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllPos()
        {
            List<AssetsService.Core.Entities.Pos> obj =await _mediator.Send(new GetAllPosQuery());
            try
            {
                List<AssetsService.Core.Entities.Pos> res = await _mediator.Send(new GetAllPosQuery());
                _logger.LogInformation("Get all the data of Pos");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }


            [HttpGet("getPosbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetPosById(int id)
        {
            try
            {
                Pos res = await _mediator.Send(new GetByIdPosQuery(id));
                _logger.LogInformation("Get the data of Pos by Id");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;


        }
        [HttpPost("CreatePos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PosResponse>> CreatePos([FromBody] CreatePosCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Pos successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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
                _logger.LogInformation("Update Pos successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Pos not Created "
                };
        }}}}