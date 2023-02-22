using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Dynamic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace AssetsService.Api.Controllers
{
#pragma warning disable
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExternalController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        private readonly ILogger<CableController> _logger;
        public ExternalController(IMediator mediator, IConfiguration configuration, ILogger<ExternalController> logger)
        {
            _mediator = mediator;
            _configuration= configuration;
        }
        [HttpPost("CreateNewVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCommonResponseExternal>> CreateNewVehicle([FromBody] CreateNewVehicleCommandExternal command)
        {
            CreateCommonResponseExternal createCommonResponse = new CreateCommonResponseExternal();
            try
            {
                //if (command.RfIdCardsAssigneds is null || command.RfIdCardsAssigneds.Count == 0)
                //{
                //    createCommonResponse.statusMessage = RespnoseMessage.Please_provide_Vehicle_Rfid_card_Assigned;
                //    createCommonResponse.statusCode = 400;
                //    return createCommonResponse;
                //}
                if (ModelState.IsValid)
                {
                    var createresult = await _mediator.Send(command);
                    if (createresult != null && createresult.id > 0)
                    {
                        createCommonResponse.Id = createresult.id;
                        createCommonResponse.statusMessage = RespnoseMessage.Record_Save_Successfully;
                        createCommonResponse.statusCode = RespnoseCode.OK;
                    }
                    else
                    {
                        if (createresult != null && !string.IsNullOrEmpty(createresult.VIN))
                        {
                            createCommonResponse.statusMessage = RespnoseMessage.Duplicate_entry_for + createresult.VIN;
                        }
                        if (createresult != null && (createresult.id == -5))    // RfID is already assigned to vehicle 
                        {
                            createCommonResponse.statusMessage = createresult.VIN + ", " + RespnoseMessage.RfID_Already_Assigned_To_Vehicle;
                        }
                        else if (createresult != null && (createresult.id == -6))    // VIN is already assigned to vehicle 
                        {
                            createCommonResponse.statusMessage = createresult.VIN + ", " + RespnoseMessage.VIN_Already_Assigned_To_Vehicle;
                        }
                        else
                        {
                            createCommonResponse.statusMessage = RespnoseMessage.Record_Not_Saved;
                        }
                        createCommonResponse.statusCode = RespnoseCode.Bad_Request;
                    }
                }
                else
                {
                    createCommonResponse.statusMessage = ModelState.Where(m => m.Value.Errors.Any()).Select(x => new { x.Key, x.Value.Errors }).ToString();
                }
                return createCommonResponse;
            }
            catch (Exception ex)
            {
                Log.Information("error occurred :" + ex.Message);
                createCommonResponse.statusMessage = RespnoseMessage.Opeartion_Failed;
            }
            return createCommonResponse;
        }
    }
}
