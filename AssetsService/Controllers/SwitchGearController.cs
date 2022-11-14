using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Dynamic;
using System.Net;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SwitchGearController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SwitchGear> _logger;
        TokenBase _token;
        public SwitchGearController(IMediator mediator, ILogger<SwitchGear> logger, TokenBase token)
        {
            _mediator = mediator;
            _logger = logger;
            _token = token;
        }

        [HttpPost("CreateSwitchGear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> CreateSwitchGear([FromBody] CreateSwitchGearCommand command)
        {
            dynamic expendo = new ExpandoObject();
            var result = await _mediator.Send(command);
            try
            {
                if (result.Id > 0)
                {
                    expendo.statusCode = 200;
                    expendo.Id = result.Id;
                    expendo.statusMessage = RespnoseMessage.Record_Save_Successfully;
                }
                else
                {
                    expendo.statusCode = 200;
                    expendo.statusMessage = RespnoseMessage.Record_Not_Saved;
                }
            }
            catch (Exception ex)
            {
                expendo.statusCode = (int)HttpStatusCode.BadRequest;
                expendo.statusMessage = RespnoseMessage.Record_Not_Saved;
                Log.Information("error occurred :" + ex.Message);
            }
            return (expendo);
        }
        [HttpPut("UpdateSwitchGear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> UpdateSwitchGear([FromBody] UpdateSwitchGearCommand command)
        {
            dynamic expendo = new ExpandoObject();
            var result = await _mediator.Send(command);
            try
            {
                if (result.Id > 0)
                {
                    expendo.statusCode = 200;
                    expendo.Id = result.Id;
                    expendo.statusMessage = RespnoseMessage.Record_Updated_Successfully;
                }
                else
                {
                    expendo.statusCode = (int)HttpStatusCode.OK;
                    expendo.statusMessage = RespnoseMessage.Record_Not_Updated;
                }
            }
            catch (Exception ex)
            {
                expendo.statusCode = (int)HttpStatusCode.BadRequest;
                expendo.statusMessage = RespnoseMessage.Record_Not_Updated;
                Log.Information("error occurred :" + ex.Message);
            }
            return (expendo);
        }
        [HttpGet("GetSwitchGearById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetSwitchGearResponseById> GetSwitchGearById(long Id)
        {
            GetSwitchGearResponseById switchGearResponse = new GetSwitchGearResponseById();
            try
            {
                switchGearResponse.StatusCode = (int)HttpStatusCode.OK;
                var dispenser = await _mediator.Send(new GetByIdSwitchGearQuery(Id));
                if (dispenser != null)
                {
                    switchGearResponse.StatusMessage = RespnoseMessage.Record_found;
                    switchGearResponse.Data=(dispenser);
                }
                else
                {
                    switchGearResponse.StatusMessage = RespnoseMessage.Record_not_found;
                }
            }
            catch (Exception ex)
            {
                switchGearResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                switchGearResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                switchGearResponse.Data = null;
                _logger.LogError(ex.ToString());
            }
            return switchGearResponse;
        }
        [HttpPost("GetAllSwitchGears")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllSwitchGearResponse>> GetAllSwitchGears([FromBody] SwitchGearRequest switchGearRequest)
        {
            AllSwitchGearResponse allswitchGearResponse = new AllSwitchGearResponse();
            try
            {
                if (switchGearRequest.PageSize == 0) switchGearRequest.PageSize = 10;
                if (switchGearRequest.PageNumber == 0) switchGearRequest.PageNumber = 1;
                allswitchGearResponse = await _mediator.Send(new GetAllSwitchGearQuery(switchGearRequest));
            }
            catch (Exception ex)
            {
                allswitchGearResponse.StatusMessage = ex.Message.ToString();
                allswitchGearResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                allswitchGearResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                allswitchGearResponse.Data = null;
                _logger.LogError(ex.ToString());
            }
            return allswitchGearResponse;
        }
        [HttpPost("GetSwitchGearDropDown")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetSwitchGearDropDown(SwitchGearDropDownRequest switchGearDropDown)
        {
            dynamic expendo = new ExpandoObject();
            var result = await _mediator.Send(new GetSwitchGearDDLQuery(switchGearDropDown.userId, switchGearDropDown.dispenserId));
            try
            {
                expendo.statusCode = 200;
                if (result is not null)
                {
                    expendo.statusMessage = RespnoseMessage.Record_found;
                    expendo.data = result;
                }
                else
                {
                    expendo.statusMessage = RespnoseMessage.Record_not_found;
                }
            }
            catch (Exception ex)
            {
                expendo.statusCode = (int)HttpStatusCode.BadRequest;
                expendo.statusMessage = RespnoseMessage.Faild;
                Log.Information("error occurred :" + ex.Message);
            }
            return (expendo);
        }
    }
}
