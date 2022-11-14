
using AssetsService.Application.Commands.Assets;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
using AssetsService.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModemController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ModemController> _logger;
        string JSONString = String.Empty;
        public ModemController(IMediator mediator, ILogger<ModemController> logger)
        {
            _mediator = mediator;
            //_logger = logger;
        }
        [HttpPost("GetAllModem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Core.Entities.ModemResponse> GetAllModem([FromBody] ModemRequest ModemRequest)
        {
            Core.Entities.ModemResponse re = new Core.Entities.ModemResponse();
            try
            {

                if (ModemRequest.PageSize == 0) ModemRequest.PageSize = 10;
                if (ModemRequest.PageNumber == 0) ModemRequest.PageNumber = 1;
                var modems = await _mediator.Send(new GetAllModemQuery(ModemRequest));
                if (modems.Count > 0)
                    re.StatusMessage = RespnoseMessage.Record_found;
                else re.StatusMessage = RespnoseMessage.Record_not_found;
                re.StatusCode = (int)HttpStatusCode.OK;
                re.data = modems;

                re.paginationResponse = new Core.PagingHelper.PaginationResponse
                {
                    TotalCount = modems.TotalCount,
                    PageSize = modems.PageSize,
                    CurrentPage = modems.CurrentPage,
                    TotalPages = modems.TotalPages,
                    HasNext = modems.HasNext,
                    HasPrevious = modems.HasPrevious
                };
                //_logger.LogInformation("Get all the data of Modem");
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("error occurred :" + ex.Message);
                Log.Information("error occurred :" + ex.Message);
            }
            
           
          return re;

        }
        [HttpGet("getModembyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async  Task<Core.Entities.ModemByIDResponse> GetModemById(int id)
        {
            Core.Entities.ModemByIDResponse modem = new ModemByIDResponse();

            try
            {
                modem = await _mediator.Send(new GetByIdModemsQuery(id));
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("Get by id the data of Modem");
                Log.Information("error occurred :" + ex.Message); 
            }
               
            
            return modem;

            
        }
        [HttpPost("CreateModem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> CreateModem([FromBody] CreateModemCommand command)
        {
            dynamic expendo = new ExpandoObject();

            try
            {

                var result = await _mediator.Send(command);
                if (result.Id > 0)
                {

                    expendo.statusCode = 200;
                    expendo.Id = result.Id;
                    expendo.statusMessage = RespnoseMessage.Record_Save_Successfully;
                }
                else
                {
                    if (result.Id == -1)
                    {
                        expendo.statusCode = 200;
                        expendo.statusMessage = RespnoseMessage.Duplicate_AssetId_can;
                        return BadRequest(expendo);
                    }
                    else
                    {
                        expendo.statusCode = 200;
                        expendo.statusMessage = RespnoseMessage.Record_not_found;
                    }
                }
            }
            catch (Exception ex)
            {
                expendo = new ExpandoObject();
                expendo.statusCode = (int)HttpStatusCode.BadRequest;
                expendo.statusMessage = RespnoseMessage.Opeartion_Failed;
                Log.Information("error occurred :" + ex.Message);

            }
            return (expendo);
        }
        [HttpPut("UpdateModem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> UpdateModem([FromBody] UpdateModemCommand command)
        {
            dynamic expandoObject = new ExpandoObject();
            try
            {
                expandoObject.statusCode = 200;
                if (command.Id < 0)
                {
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_Modem_Id_value;
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_ModifiedBy_value;
                    return expandoObject;
                }
                var data = await _mediator.Send(command);
                if (data is not null && data.Id > 0)
                {
                    expandoObject.statusMessage = RespnoseMessage.Record_Updated_Successfully;
                }
                if (data.Id == -1)
                {
                    expandoObject.statusCode = 200;
                    expandoObject.statusMessage = RespnoseMessage.Duplicate_AssetId_can;
                    return BadRequest(expandoObject);
                }

                else
                {
                    expandoObject.statusMessage = RespnoseMessage.Record_not_found;
                }
                return expandoObject;
            }
            catch (Exception ex)
            {
                expandoObject = new ExpandoObject();
                //_logger.LogError(ex.ToString());
                expandoObject.StatusCode = (int)HttpStatusCode.BadRequest;
                expandoObject.StatusMessage = RespnoseMessage.Opeartion_Failed;
                Log.Information("error occurred :" + ex.Message);
            }
            return expandoObject;
        }
    }
}















