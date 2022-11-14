using AssetsService.Application.Queries;
using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Queries;
using AssetsService.Core.Responses;
using AssetsService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;
using AssetsService.Core.Responses.Assets;
using Serilog;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using AssetsService.Core.ConstantResponse;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CableController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CableController> _logger;
        public CableController(IMediator mediator, ILogger<CableController> logger)
        {
            _mediator = mediator;
            //_logger = logger;
        }

        [HttpPost("GetAllCable")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<CableQueryResponse> GetAllCable([FromBody] GetAllCableRequest getAllCableRequest)
        {
            CableQueryResponse cableQueryResponse = new CableQueryResponse();
            try
            {
                if (getAllCableRequest.PageSize == 0) getAllCableRequest.PageSize = 10;
                if (getAllCableRequest.PageNumber == 0) getAllCableRequest.PageNumber = 1;
                var res = await _mediator.Send(new GetAllCableQuery(getAllCableRequest));
                if (res != null && res.Count > 0)
                {
                    cableQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                    cableQueryResponse.data = res;
                    cableQueryResponse.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = res.TotalCount,
                        PageSize = res.PageSize,
                        CurrentPage = res.CurrentPage,
                        HasNext = res.HasNext,
                        HasPrevious = res.HasPrevious
                    };
                    cableQueryResponse.StatusCode = (int)HttpStatusCode.OK;

                    ////_logger.LogInformation("Get the all data of Cable");
                }
                else
                {
                    cableQueryResponse.StatusMessage = RespnoseMessage.Record_not_found;
                    cableQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    cableQueryResponse.data = null;
                    ////_logger.LogInformation("Data not found");
                }
            }
            catch (Exception ex)
            {
                cableQueryResponse.StatusMessage = ex.Message.ToString();
                cableQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                cableQueryResponse.data = null;
                // //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return cableQueryResponse;
        }
        [HttpGet("getCablebyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<CableByIdResponse> GetCableById(int id)
        {
            CableByIdResponse cableByIdResponse = new CableByIdResponse();
            try
            {
                CableData res = await _mediator.Send(new GetByIdCablesQuery(id));
                cableByIdResponse.StatusCode = (int)HttpStatusCode.OK;
                cableByIdResponse.StatusMessage = RespnoseMessage.Record_found;
                cableByIdResponse.data = res;
                // //_logger.LogInformation("Get the data of Cable reader by Id");
            }
            catch (Exception ex)
            {
                cableByIdResponse.StatusMessage = ex.Message.ToString();
                cableByIdResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                cableByIdResponse.data = null;
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return cableByIdResponse;
        }
        [HttpPost("CreateCable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCableResponse>> CreateCable([FromBody] CreateCableCommand command)
        {
            CreateCableResponse createCableResponse = new CreateCableResponse();

            try
            {
                if (ModelState.IsValid)
                {                    
                    var result = await _mediator.Send(command);                  
                    if (result.Id > 0)
                    {
                        createCableResponse.StatusCode = 200;
                        createCableResponse.StatusMessage = RespnoseMessage.Cable_Created_Successfully;
                        createCableResponse.Id = result.Id;
                    }
                    else
                    {
                        if (result.Id == -1)
                        {
                            createCableResponse.StatusCode = 200;
                            createCableResponse.StatusMessage = RespnoseMessage.Duplicate_AssetId_can;
                            return BadRequest(createCableResponse);
                        }
                        else
                        {
                            createCableResponse.StatusCode = 200;
                            createCableResponse.StatusMessage = RespnoseMessage.Record_not_found;
                        }
                    }
                }
                else
                {
                    dynamic expendo = new ExpandoObject();
                    expendo.statusCode = 400;
                    expendo.statusMessage = RespnoseMessage.Invalid_Data;

                    expendo.errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                    return (expendo);
                }

            }

            catch (Exception ex)
            {
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                createCableResponse.StatusCode = 404;
                createCableResponse.StatusMessage = RespnoseMessage.Cable_Not_Created;

            }
            return (createCableResponse);
        }
        [HttpPut("UpdateCable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UpdateCableResponse>> UpdateCable([FromBody] UpdateCableCommand command)
        {
            UpdateCableResponse updateCableResponse = new UpdateCableResponse();
            try
            {
                ////_logger.LogInformation("Request Body of Cable controller is :" + command);
                var result = await _mediator.Send(command);
                ////_logger.LogInformation("All Cable data updated successfully");

                if (result is not null && result.Id > 0)
                {
                    updateCableResponse.StatusMessage = RespnoseMessage.Record_Updated_Successfully;
                    updateCableResponse.StatusCode = 200;
                    updateCableResponse.Id = result.Id;
                }
                else
                {
                    updateCableResponse.StatusMessage = RespnoseMessage.Record_Not_Updated;
                    updateCableResponse.StatusCode = 200;
                    updateCableResponse.Id = result.Id;
                }
            }
            catch (Exception ex)
            {
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = RespnoseMessage.Exception,
                    StatusCode = 404,
                    Content = RespnoseMessage.Cable_Not_Created
                };
            }
            return (updateCableResponse);
        }
        [HttpDelete("DeleteCableById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DeleteCableResponse>> DeleteCable([FromBody] DeleteCableCommand command)
        {
            DeleteCableResponse deleteCableResponse = new DeleteCableResponse();
            try
            {
                var result = await _mediator.Send(command);
                ////_logger.LogInformation("Cable data deleted successfully");
                deleteCableResponse.StatusCode = 200;
                deleteCableResponse.StatusMessage = RespnoseMessage.Deleted;
                deleteCableResponse.Id = result.Id;
                deleteCableResponse.IsActive = result.IsActive;

            }
            catch (Exception ex)
            {
                // //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                deleteCableResponse.StatusCode = 400;
                deleteCableResponse.StatusMessage = ex.Message;
            }
            return deleteCableResponse;
        }
        [HttpPost("GetCableDropDown")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetCableDropDown(GetAllCableDropDownRequest getAllCableDropDown)
        {
            dynamic expendo = new ExpandoObject();          
            var result = await _mediator.Send(new GetCableDropDownQuery(getAllCableDropDown.userId, getAllCableDropDown.dispenserId));
           
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
