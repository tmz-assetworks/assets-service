using AssetsService.Application.Commands.Assets.SubscriptionPlan;
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
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SubscriptionPlan> _logger;
        string JSONString = String.Empty;

        public SubscriptionPlanController(IMediator mediator, ILogger<SubscriptionPlan> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        [Route("/asset/subscriptionplan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSubscriptionPlan([FromBody] CreateSubscriptionPlanCommand planCommand)
        {
            try
            {
                var result = await _mediator.Send(planCommand);
                _logger.LogInformation("Create Subscription Plan successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Subscription Plan not Created "
                };
            }
        }

        [HttpGet]
        [Route("/asset/subscriptionplan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetAllubscriptionPlan()
        {
            List<AssetsService.Core.Entities.SubscriptionPlan> obj = await _mediator.Send(new GetAllSubscriptionQuery());
            try
            {
                List<AssetsService.Core.Entities.SubscriptionPlan> res = await _mediator.Send(new GetAllSubscriptionQuery());
                _logger.LogInformation("Get all the data of Subscription Plan");
                return getjson(res);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());

            }
            return JSONString;
        }

        [HttpGet("/asset/subscriptionplanById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetSubscriptionById(int id)
        {
            try
            {
                SubscriptionPlan subscriptionPlan = await _mediator.Send(new GetSubscriptionByIdQuery(id));
                _logger.LogInformation("Get the data of Subscription Plan by Id");
                return getjson(subscriptionPlan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
            }
            return JSONString;
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

        [HttpPut("/asset/subscriptionplan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AssetsService.Application.Responses.Assets.SubscriptionPlanResponse>> UpdateSubscriptionPlan([FromBody] UpdateSubscriptionPlanCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Subscription Plan updated successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Subscription Plan not Updated"
                };
            }
        }
    }
}
