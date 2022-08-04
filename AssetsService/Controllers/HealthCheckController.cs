using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using Newtonsoft.Json;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HealthCheckController> _logger;
        public HealthCheckController(IMediator mediator, ILogger<HealthCheckController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/actuator/health/**")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult HandleUsingGET([FromBody] Dictionary<string, string> body)
        {
            _logger.LogInformation("Get the all data of HealthCheck Controller");
            string exampleJson = null;

            var example = exampleJson != null            //var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            return new ObjectResult(example);
        }

        [HttpGet]
        [Route("/actuator/health")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult HandleUsingGET1([FromBody] Dictionary<string, string> body)
        {
            _logger.LogInformation("Get the all data of HealthCheck Controller");
            string exampleJson = null;

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            return new ObjectResult(example);
        }

        [HttpGet]
        [Route("/actuator/info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult HandleUsingGET2([FromBody] Dictionary<string, string> body)
        {
            _logger.LogInformation("Get the all data of HealthCheck Controller");
            string exampleJson = null;

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            return new ObjectResult(example);
        }
    }
}
