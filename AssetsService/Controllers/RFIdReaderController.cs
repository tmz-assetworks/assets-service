using AssetsService.Application.Commands.Assets.RFId;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using AssetsService.Core.Mapper;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Dynamic;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RFIdReaderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RFIDReader> _logger;
        string JSONString = String.Empty;
        TokenBase _token;
        public RFIdReaderController(IMediator mediator, ILogger<RFIDReader> logger, TokenBase token)
        {
            _mediator = mediator;
            _token = token;
            //_logger = logger;
        }

        /// <summary>
        /// API to a New RfIdReader
        /// </summary>
        /// <param name="createRFIdCommand"></param>
        /// <returns></returns>
        [HttpPost("AddRfIdReader")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCommonResponse>> AddRfIdReader([FromBody] CreateRFIdCommand createRFIdCommand)
        {
            CreateCommonResponse createCommonResponse = new CreateCommonResponse();
            try
            {

                if (ModelState.IsValid)
                {
                    createCommonResponse.statusCode = 200;
                    var data = await _mediator.Send(createRFIdCommand);
                    if (data is not null && data.Id > 0)
                    {
                        createCommonResponse.statusMessage = RespnoseMessage.Record_Save_Successfully;
                        createCommonResponse.Id = data.Id;
                    }
                    else
                    if (data.Id == -1)
                    {                       
                        createCommonResponse.statusMessage = RespnoseMessage.Duplicate_AssetId_can_notbe_created;
                        return  BadRequest(createCommonResponse);
                    }
                    else
                    {

                        createCommonResponse.statusMessage = RespnoseMessage.Record_Not_Saved;
                        return BadRequest(createCommonResponse);
                    }
                }
                else
                {
                    createCommonResponse.statusCode = (int)HttpStatusCode.BadRequest;
                    createCommonResponse.statusMessage = ModelState.Where(m => m.Value.Errors.Any()).Select(x => new { x.Key, x.Value.Errors }).ToString();

                }
                return createCommonResponse;
            }
            catch (Exception ex)
            {               
                Log.Information("error occurred :" + ex.Message);
                createCommonResponse.statusMessage = RespnoseMessage.Faild+RespnoseMessage.Record_Not_Saved;
            }
            return createCommonResponse;
        }

        /// <summary>
        /// This api it used for getting all RfId Readers with Paggination
        /// </summary>
        /// <param name="rfIdReaderRequest"></param>
        /// <returns></returns>
        [HttpPost("GetAllRfIdReaders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RfIdReaderRespnse>> GetAllRfIdReaders(RfIdReaderRequest rfIdReaderRequest)
        {
            RfIdReaderRespnse rfIdReaderRespnse = new RfIdReaderRespnse();
            try
            {
                if (rfIdReaderRequest.PageSize == 0) rfIdReaderRequest.PageSize = 10;
                if (rfIdReaderRequest.PageNumber == 0) rfIdReaderRequest.PageNumber = 1;
                var rfidreaders = await _mediator.Send(new GetAllRFIdQuery(rfIdReaderRequest));
                rfIdReaderRespnse = new RfIdReaderRespnse();
                rfIdReaderRespnse.StatusCode = (int)HttpStatusCode.OK;
                if (rfidreaders is not null && rfidreaders.Count > 0)
                {
                    rfIdReaderRespnse.data = rfidreaders;
                    rfIdReaderRespnse.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = rfidreaders.TotalCount,
                        PageSize = rfidreaders.PageSize,
                        CurrentPage = rfidreaders.CurrentPage,
                        TotalPages = rfidreaders.TotalPages,
                        HasNext = rfidreaders.HasNext,
                        HasPrevious = rfidreaders.HasPrevious
                    };
                    rfIdReaderRespnse.StatusMessage = RespnoseMessage.Record_found;
                }
                else
                {
                    rfIdReaderRespnse.StatusMessage = RespnoseMessage.Record_not_found;
                }
            }
            catch (Exception ex)
            {
                rfIdReaderRespnse.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message;
                rfIdReaderRespnse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return rfIdReaderRespnse;
        }
        [HttpPost("GetAllRFIdReaderData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<RfIdReaderDataRespnse> GetAllRFIdReaderData(RfIdReaderDataRequest rfIdReaderDataRequest)
        {
            _token.acces_token = await HttpContext.GetTokenAsync("access_token");
            RfIdReaderDataRespnse rfIdReaderDataRespnse = new RfIdReaderDataRespnse();            
            try
            {
                List<AssetsService.Core.Entities.RFIDReader> rFIDReaders = await _mediator.Send(new GetRFIdReaderDataQuery(rfIdReaderDataRequest));
                List<RFIDReaderResult> rFIDReadersData = rFIDReaders.Select(x => new RFIDReaderResult { Id = x.Id, CardReader = x.CardReader, IsActive = x.IsActive })
                    .Where(m => m.CardReader != "").OrderBy(m => m.CardReader).ToList();
                rfIdReaderDataRespnse.StatusMessage = RespnoseMessage.Record_found;
                rfIdReaderDataRespnse.StatusCode = (int)HttpStatusCode.OK;
                rfIdReaderDataRespnse.Data = rFIDReadersData;
            }
            catch (Exception ex)
            {
                rfIdReaderDataRespnse.StatusMessage = ex.Message.ToString();
                rfIdReaderDataRespnse.StatusCode = (int)HttpStatusCode.NotFound;
                rfIdReaderDataRespnse.Data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return rfIdReaderDataRespnse;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetRfIdReaderById/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RfIdReaderDetailsResponse>> GetRfIdReaderById(int Id)
        {
            RfIdReaderDetailsResponse rfIdReaderRespnse = new RfIdReaderDetailsResponse();
            try
            {
                RFIDReaderDetails rFIDReaderDetails = await _mediator.Send(new GetByIdRfIdReaderQuery(Id));
                rfIdReaderRespnse.StatusCode = (int)HttpStatusCode.OK;
                if (rFIDReaderDetails is not null)
                {
                    rfIdReaderRespnse.StatusMessage = RespnoseMessage.Record_found;
                    rfIdReaderRespnse.data = new RFIDReaderDetails();
                    rfIdReaderRespnse.data = rFIDReaderDetails;
                }
                else
                {
                    rfIdReaderRespnse.StatusMessage = RespnoseMessage.Record_not_found;
                }
            }
            catch (Exception ex)
            {
                rfIdReaderRespnse.StatusCode = (int)HttpStatusCode.BadRequest;
                rfIdReaderRespnse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                rfIdReaderRespnse.data = null;
                _logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return rfIdReaderRespnse;
        }

        /// <summary>
        /// Update the details of RfId Reader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateRfIdReader")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UpdateCommonResponse>> UpdateRfIdReader([FromBody] UpdateRFIdCommand command)
        {
            UpdateCommonResponse updateCommonResponse = new UpdateCommonResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    updateCommonResponse.statusCode = 200;
                    if (command.Id < 0)
                    {
                        updateCommonResponse.statusMessage = RespnoseMessage.Please_provide_RfId_Reader_Id_value;
                        return updateCommonResponse;
                    }
                    else
                        if (string.IsNullOrEmpty(command.ModifiedBy))
                    {
                        updateCommonResponse.statusMessage = RespnoseMessage.Please_provide_ModifiedBy_value;
                        return updateCommonResponse;
                    }
                    var data = await _mediator.Send(command);
                    if (data is not null && data.Id > 0)
                    {
                        updateCommonResponse.statusMessage = RespnoseMessage.Record_Updated_Successfully;
                    }
                    else
                    {
                        updateCommonResponse.statusMessage = RespnoseMessage.Record_Not_Updated;
                    }
                }
                else
                {
                    updateCommonResponse.statusCode = (int)HttpStatusCode.BadRequest;
                    updateCommonResponse.statusMessage = ModelState.Where(m => m.Value.Errors.Any()).Select(x => new { x.Key, x.Value.Errors }).ToString();

                }
                return updateCommonResponse;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                updateCommonResponse.statusCode = (int)HttpStatusCode.BadRequest;
                updateCommonResponse.statusMessage = RespnoseMessage.Opeartion_Failed;
                Log.Information("error occurred :" + ex.Message);
            }
            return updateCommonResponse;
        }

        /// <summary>        
        /// we  update the IsActive to true and false in  RfIdReader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// Date: 06/09/2022
        /// Audther : Pradeep kumar
        [HttpPut("IsActiveRfIdReader")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UpdateCommonResponse>> IsActiveRfIdReader([FromBody] IsActiveRfIdReaderCommand command)
        {
            UpdateCommonResponse updateCommonResponse = new UpdateCommonResponse();
            try
            {
                updateCommonResponse.statusCode = 200;
                if (command.Id < 0)
                {
                    updateCommonResponse.statusMessage = RespnoseMessage.Please_provide_RfId_Reader_Id_value;
                    return updateCommonResponse;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    updateCommonResponse.statusMessage = RespnoseMessage.Please_provide_ModifiedBy_value;
                    return updateCommonResponse;
                }
                var result = await _mediator.Send(command);

                if (result is not null && result.Id > 0)
                    updateCommonResponse.statusMessage = RespnoseMessage.Record_status_changed_successfully;
                else
                    updateCommonResponse.statusMessage = RespnoseMessage.Record_not_found;

                return updateCommonResponse;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                updateCommonResponse.statusMessage = RespnoseMessage.Opeartion_Failed;
                updateCommonResponse.statusCode = (int)HttpStatusCode.BadRequest;
                Log.Information("error occurred :" + ex.Message);
            }
            return updateCommonResponse;
        }
    }
}
