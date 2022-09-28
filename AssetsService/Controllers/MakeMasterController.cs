using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Response;
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
    public class MakeMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MakeMasterController> _logger;
        string JSONString = String.Empty;
        public MakeMasterController(IMediator mediator, ILogger<MakeMasterController> logger)
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
        [HttpGet("GetAllMakeMaster")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllMakeMaster>> GetAllMakeMaster()
        {
            AllMakeMaster allMakeMaster = new AllMakeMaster();
            try
            {
                List<AssetsService.Core.Entities.MakeMaster> res = await _mediator.Send(new GetAllMakeMasterQuery());
                allMakeMaster.StatusCode = (int)HttpStatusCode.OK;
                allMakeMaster.StatusMessage = "Record found";
                allMakeMaster.data = res;
                //_logger.LogInformation("Get all the data of Make master");
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                allMakeMaster.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                allMakeMaster.StatusCode = (int)HttpStatusCode.NotFound;
                allMakeMaster.data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allMakeMaster;
        }
        [HttpGet("getMakeMasterbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MakeMasterById>> GetMakeMasterById(int id)
        {
            MakeMasterById makeMasterById = new MakeMasterById();   
            try
            {
                MakeMaster res = await _mediator.Send(new GetByIdMakeMastersQuery(id));
                makeMasterById.StatusCode = (int)HttpStatusCode.OK;
                makeMasterById.StatusMessage = "Record found";
                makeMasterById.data = res;
                //_logger.LogInformation("Get the data of Make master by Id");
            }
            catch (Exception ex)
            {
                makeMasterById.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                makeMasterById.StatusCode = (int)HttpStatusCode.NotFound;
                makeMasterById.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return makeMasterById;


        }
        [HttpPost("CreateMakeMasters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MakeMasterResponse>> CreateMakeMasters([FromBody] CreateMakeMasterCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Create Make master successfully");
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
                    Content = "Make Master not Created "
                };
            }
        }
        [HttpPut("UpdateMakeMaster")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MakeMasterResponse>> UpdateMakeMaster([FromBody] UpdateMakeMasterCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Update Make master successfully");
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
                    Content = "Make Master not Update "
                };
            }
        }
        [HttpDelete("DeleteMakeMasterById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MakeMasterResponse>> DeleteMakeMaster([FromBody] DeleteMakeMasterCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Delete Make master successfully");
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
                    Content = "Make Master not Deleted "
                };
            }
        }
    }
}
