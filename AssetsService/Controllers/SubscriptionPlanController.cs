using AssetsService.Application.Commands.Assets.SubscriptionPlan;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses.Assets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SubscriptionPlan> _logger;
        string JSONString = String.Empty;

        public SubscriptionPlanController(IMediator mediator, ILogger<SubscriptionPlan> logger)
        {
            _mediator = mediator;
            //_logger = logger;
        }
        [HttpPost]
        [Route("/asset/subscriptionplan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSubscriptionPlan([FromBody] CreateSubscriptionPlanCommand planCommand)
        {
            try
            {
                var result = await _mediator.Send(planCommand);
                //_logger.LogInformation("Create Subscription Plan successfully");
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
                    Content = "Subscription Plan not Created "
                };
            }
        }

        [HttpGet]
        [Route("/asset/subscriptionplan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllSubscriptionplan>> GetAllubscriptionPlan()
        {
            AllSubscriptionplan allSubscriptionplan = new AllSubscriptionplan();
            try
            {
                List<AssetsService.Core.Entities.SubscriptionPlan> res = await _mediator.Send(new GetAllSubscriptionQuery());
                allSubscriptionplan.StatusCode = (int)HttpStatusCode.OK;
                allSubscriptionplan.StatusMessage = "Record found";
                allSubscriptionplan.data = res;
                //_logger.LogInformation("Get all the data of Subscription Plan");
            }
            catch (Exception ex)
            {
                allSubscriptionplan.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                allSubscriptionplan.StatusCode = (int)HttpStatusCode.NotFound;
                allSubscriptionplan.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());

            }
            return allSubscriptionplan;
        }

        [HttpGet("/asset/subscriptionplanById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SubscriptionplanById>> GetSubscriptionById(int id)
        {
            SubscriptionplanById subscriptionplanById = new SubscriptionplanById();
            try
            {
                SubscriptionPlan res = await _mediator.Send(new GetSubscriptionByIdQuery(id));
                subscriptionplanById.StatusCode = (int)HttpStatusCode.OK;
                subscriptionplanById.StatusMessage = "Record found";
                subscriptionplanById.data = res;
                //_logger.LogInformation("Get the data of Subscription Plan by Id");
            }
            catch (Exception ex)
            {
                subscriptionplanById.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                subscriptionplanById.StatusCode = (int)HttpStatusCode.NotFound;
                subscriptionplanById.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());

            }
            return subscriptionplanById;
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
                //_logger.LogInformation("Subscription Plan updated successfully");
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
                    Content = "Subscription Plan not Updated"
                };
            }
        }
    }
}
