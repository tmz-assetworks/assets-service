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
    public class PricePlanController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        private readonly ILogger<PricePlanController> _logger;
        string JSONString = String.Empty;
        public PricePlanController(IMediator mediator, ILogger<PricePlanController> logger)
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
        [HttpGet("GetAllPricePlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllPricePlan()
        {
            List<AssetsService.Core.Entities.PricePlan> obj =await _mediator.Send(new GetAllPricePlanQuery());
            try
            {
                List<AssetsService.Core.Entities.PricePlan> res = await _mediator.Send(new GetAllPricePlanQuery());
                _logger.LogInformation("Get all the data of Price Plan");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }


            [HttpGet("getPricePlanbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetPricePlanById(int id)
        {
            try
            {
                PricePlan res = await _mediator.Send(new GetByIdPricePlanQuery(id));
                _logger.LogInformation("Get the data of Price Plan by Id");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;


        }
        [HttpPost("CreatePricePlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PricePlanResponse>> CreatePricePlan([FromBody] CreatePricePlanCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Price Plan successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "PricePlan not Created "
                };
            }
        }
        [HttpPut("UpdatePricePlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PricePlanResponse>> UpdatePricePlan([FromBody] UpdatePricePlanCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update Price Plan successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "PricePlan not Created "
                };
        }}}}