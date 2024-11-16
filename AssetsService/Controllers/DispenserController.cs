using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Queries;
using AssetsService.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using AssetsService.Core.Responses.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Application.Queries;
using System.Collections.Generic;
using AssetsService.Core.Response;
using Serilog;
using static AssetsService.Core.Response.GetDispenserStatusResponse;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using AssetsService.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication;
using AssetsService.Core.ConstantResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DispenserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DispenserController> _logger;
        string JSONString = string.Empty;
        TokenBase _token;
        public DispenserController(IMediator mediator, ILogger<DispenserController> logger,TokenBase token)
        {
            //_logger = logger;
            _mediator = mediator;
            _token = token;
            
            
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
        //ToDo  Operator Location Base filter not implemented
        // [HttpGet("getAllDispenser")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public async Task<string> GetAllDispenser()
        // {

        //     try
        //     {
        //         List<AssetsService.Core.Entities.Dispenser> res = await _mediator.Send(new GetAllDispenserQuery());
        //         return getjson(res);
        //     }
        //     catch (Exception ex)
        //     {
        //         JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
        //         //_logger.LogError(ex.ToString());

        //     }
        //     return JSONString;
        // }
        //ToDo  Operator Location Base filter not implemented
        [HttpGet("getAllDispenser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AllDispenserQueryResponse> GetAllDispenser()
        {
            AllDispenserQueryResponse allDispenserQueryResponse = new AllDispenserQueryResponse();
            try
            {

                _token.acces_token  =  HttpContext != null ?  await HttpContext.GetTokenAsync("access_token") : _token.acces_token;
                List<AssetsService.Core.Entities.Charger> dispenser = await _mediator.Send(new GetAllDispenserQuery());                
                allDispenserQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                allDispenserQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                allDispenserQueryResponse.data = dispenser;               
            }
            catch (Exception ex)
            {
                allDispenserQueryResponse.StatusMessage = ex.Message.ToString();
                allDispenserQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                allDispenserQueryResponse.data = null;
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return allDispenserQueryResponse;
        }
        [HttpPost("GetDispenserStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetDispenserStatus> GetAllModelData(DispenserStatusRequest dispenserStatusRequest)
        {
            GetDispenserStatus allModelDataResponse = new GetDispenserStatus();
            try
            {
                List<AssetsService.Core.Entities.ChargerStatus> dispensers = await _mediator.Send(new GetDispenserStatusQuery(dispenserStatusRequest));
                List<DispenserStatusList> modelResults = dispensers.Select(x => new DispenserStatusList { Id = x.Id,  Status = x.ChargerStatus1 }).Where(m => m.Status != "").OrderBy(m => m.Status).ToList();
                allModelDataResponse.StatusMessage = RespnoseMessage.Record_found;
                allModelDataResponse.StatusCode = (int)HttpStatusCode.OK;
                allModelDataResponse.Data = modelResults;
            }
            catch (Exception ex)
            {
                allModelDataResponse.StatusMessage = ex.Message.ToString();
                allModelDataResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                allModelDataResponse.Data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allModelDataResponse;
        }
        [HttpPost("GetDispensersWithPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllDispenserResponse>> GetDispensersWithPagination([FromBody] DispensersRequest getAllDispenserRequest)
        {
            AllDispenserResponse allDispenserQueryResponse = new AllDispenserResponse();
            
            try
            {
                if (getAllDispenserRequest.PageSize == 0) getAllDispenserRequest.PageSize = 10;
                if (getAllDispenserRequest.PageNumber == 0) getAllDispenserRequest.PageNumber = 1;
                allDispenserQueryResponse = await _mediator.Send(new GetAllDispenserDetailQuery(getAllDispenserRequest));
            }
            catch (Exception ex)
            {
                allDispenserQueryResponse.StatusMessage = ex.Message.ToString();
                allDispenserQueryResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                allDispenserQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                allDispenserQueryResponse.Data = null;
                _logger.LogError(ex.ToString());
            }
            return allDispenserQueryResponse;
        }

        /// <summary>
        /// Get Dispenser deatil by Id
        /// </summary>
        /// <param name="dispenserId"></param>
        /// <returns></returns>
        [HttpPost("GetDispenserDetailsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetDispenserByIdResponse> GetDispenserDetailsById(long dispenserId)
        {
            GetDispenserByIdResponse dispenserQueryResponse = new GetDispenserByIdResponse();
            try
            {
                dispenserQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                var dispenser = await _mediator.Send(new GetDispenserDetailByIdQuery(dispenserId));
                if (dispenser != null)
                {
                    dispenserQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                    dispenserQueryResponse.Data.Add(dispenser);
                }
                else
                {
                    dispenserQueryResponse.StatusMessage = RespnoseMessage.Record_not_found;
                }
            }
            catch (Exception ex)
            {
                dispenserQueryResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                dispenserQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                dispenserQueryResponse.Data = null;
                _logger.LogError(ex.ToString());
            }
            return dispenserQueryResponse;
        }

        [HttpGet("GetDispenserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserQueryResponse> GetDispenserById(long Id)
        {
            DispenserQueryResponse dispenserQueryResponse = new DispenserQueryResponse();
            try
            {
                var dispenser = await _mediator.Send(new GetDispenserByIdQuery(Id));

                dispenserQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                dispenserQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                dispenserQueryResponse.data = new List<Charger>();
                dispenserQueryResponse.data.Add(dispenser);

            }
            catch (Exception ex)
            {
                dispenserQueryResponse.StatusMessage = ex.Message.ToString();
                dispenserQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                dispenserQueryResponse.data = null;
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return dispenserQueryResponse;           
        }

         [HttpGet("getDispenserByLocationId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserByLocationQueryResponse> getDispenserByLocationId(long Id)
        {
            DispenserByLocationQueryResponse dispenserByLocationQueryResponse = new DispenserByLocationQueryResponse();
            try
            {
                List<AssetsService.Core.Responses.Assets.DispenserByLocationIdResponse> dispenser = await _mediator.Send(new GetDispenserByLocationIdQuery(Id));
                if (dispenser != null && dispenser.Count() != 0)
                {
                dispenserByLocationQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                dispenserByLocationQueryResponse.data = dispenser;
               // ////_logger.LogInformation("Get the all data of Dispenser location by Id");
                }
                 else
                {
                    dispenserByLocationQueryResponse.data = null;
                    dispenserByLocationQueryResponse.StatusMessage = RespnoseMessage.Record_not_found;
                }
            }
            catch (Exception ex)
            {
                dispenserByLocationQueryResponse.StatusMessage = ex.Message.ToString();
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                dispenserByLocationQueryResponse.data = null;
                //////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return dispenserByLocationQueryResponse;
        }



        [HttpGet("GetDispenserByChargeBoxId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserByChargeBoxIdResponse> GetDispenserByChargeBoxId(string ChargeBoxId)
        {
            DispenserByChargeBoxIdResponse dispenserByChargeBoxIdResponse = new DispenserByChargeBoxIdResponse();
            try
            {
                Charger dispenser = await _mediator.Send(new GetDispenserByChargeBoxIdQuery(ChargeBoxId));
                dispenserByChargeBoxIdResponse.StatusCode = (int)HttpStatusCode.OK;
                if (dispenser != null)
                {
                    dispenserByChargeBoxIdResponse.data = new List<Charger>();
                    dispenserByChargeBoxIdResponse.data.Add(dispenser);
                    dispenserByChargeBoxIdResponse.StatusMessage = RespnoseMessage.Record_found;
                    dispenserByChargeBoxIdResponse.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    dispenserByChargeBoxIdResponse.data = null;
                    dispenserByChargeBoxIdResponse.StatusMessage = RespnoseMessage.Record_not_found;
                }
                //////_logger.LogInformation("Get the all data of Dispenser location by Id");
            }
            catch (Exception ex)
            {
                // dispenserByChargeBoxIdResponse.StatusMessage = ex..ToString();
                dispenserByChargeBoxIdResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                dispenserByChargeBoxIdResponse.data = null;
                //////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return dispenserByChargeBoxIdResponse;
        }

        [HttpGet("GetDispenserByStationId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetDispenserByStationId(long StationId)
        {
            try
            {
                Charger dispenser = await _mediator.Send(new GetDispenserByStationIdQuery(StationId));
                ////_logger.LogInformation("Get the Dispenser data by Station Id");
                return getjson(dispenser);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return JSONString;
        }

        [HttpDelete("Deletedispenser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DispenserResponse>> Deletedispenser([FromBody] DeleteDispenserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                ////_logger.LogInformation("Dispenser data deleted successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = RespnoseMessage.Exception,
                    StatusCode = 404,
                    Content = RespnoseMessage.Not_Deleted
                };
            }
        }

        [HttpPost("CreateDispenser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> CreateDispenser([FromBody] CreateDispenserCommand command)
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
                    expendo.statusCode = 400;
                    expendo.statusMessage = ResultMessage(result.Id);
                    return BadRequest(expendo);
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


        [HttpPut("UpdateDispenser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> UpdateDispenser([FromBody] UpdateDispenserCommand command)
        {
            dynamic updatertn = new ExpandoObject();
            var Updateresult = await _mediator.Send(command);
            try
            {
                if (Updateresult.Id > 0)
                {
                    updatertn.statusCode = 200;
                    updatertn.Id = Updateresult.Id;
                    updatertn.statusMessage = RespnoseMessage.Record_Updated_Successfully;
                }
                else
                {
                    updatertn.statusCode = 400;
                    updatertn.statusMessage = ResultMessage(Updateresult.Id);
                    return BadRequest(updatertn);
                }

            }
            catch (Exception ex)
            {
                updatertn.statusCode = (int)HttpStatusCode.BadRequest;
                updatertn.statusMessage = RespnoseMessage.Record_Not_Updated;
                Log.Information("error occurred :" + ex.Message);
            }
            return (updatertn);
        }

        private string ResultMessage(long ID)
        {
            if (ID == -1)
            {
                return RespnoseMessage.Duplicate_AssetId_can;
            }
            else if (ID == -2)
            {
                return RespnoseMessage.Mapped_RFIdReaderId_is_not_exits;
            }
            else if (ID == -3)
            {
                return RespnoseMessage.Mapped_LocationID_is_not_exits;
            }
            else if (ID == -4)
            {
                return RespnoseMessage.Mapped_CableID_is_not_exits;
            }
            else if (ID == -5)
            {
                return RespnoseMessage.Duplicate_ChargeBoxId_can;
            }
            else
            {
                return RespnoseMessage.Record_Not_Saved;
            }
        }

        [HttpPost("GetDispenserByLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserByLocationsQueryResponse> GetDispenserByLocations([FromBody] DispenserByLocations objdisp)
        {
            DispenserByLocationsQueryResponse dispenserByLocationQueryResponse = new DispenserByLocationsQueryResponse();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                List<DispenserByLocationsResponse> dispenser = (List<DispenserByLocationsResponse>)await _mediator.Send(new GetDispenserByLocationsQuery(objdisp.LocationIds, objdisp.ChargeBoxId));


                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                if (dispenser != null && dispenser.Count > 0)
                {
                    dispenserByLocationQueryResponse.data = dispenser;
                    dispenserByLocationQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                }
                else
                {
                    dispenserByLocationQueryResponse.data = null;
                    dispenserByLocationQueryResponse.StatusMessage = RespnoseMessage.Record_not_found;
                }
                ////_logger.LogInformation("Get the all data of Dispenser location by Id");
            }
            catch (Exception ex)
            {
                dispenserByLocationQueryResponse.StatusMessage = ex.Message.ToString();
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                dispenserByLocationQueryResponse.data = null;
                Log.Information("error occurred :" + ex.Message);
                ////_logger.LogError(ex.ToString());

            }
            return dispenserByLocationQueryResponse;
        }


        [HttpPost("GetDispensersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispensersDetailResponse> GetDispensersList([FromBody] DispensersDetailRequest dispensersDetailRequest)
        {
            DispensersDetailResponse dispensersDetailResponse = new DispensersDetailResponse();
            try
            {
                _token.acces_token= await HttpContext.GetTokenAsync("access_token");
                if (dispensersDetailRequest.PageSize == 0) dispensersDetailRequest.PageSize = 10;
                if (dispensersDetailRequest.PageNumber == 0) dispensersDetailRequest.PageNumber = 1;
                var dispensers = await _mediator.Send(new GetDispensersDetailQuery(dispensersDetailRequest));
                if (dispensers != null && dispensers.Count > 0)
                {
                    dispensersDetailResponse.StatusMessage = RespnoseMessage.Record_found;
                    
                    dispensersDetailResponse.StatusCode = (int)HttpStatusCode.OK;
                    dispensersDetailResponse.data = dispensers;
                    dispensersDetailResponse.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = dispensers.TotalCount,
                        PageSize = dispensers.PageSize,
                        CurrentPage = dispensers.CurrentPage,
                        TotalPages = dispensers.TotalPages,
                        HasNext = dispensers.HasNext,
                        HasPrevious = dispensers.HasPrevious
                    };
                }
                else
                { 
                    dispensersDetailResponse.StatusMessage = RespnoseMessage.Record_not_found;
                    dispensersDetailResponse.StatusCode = (int)HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                dispensersDetailResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                dispensersDetailResponse.StatusCode = (int)HttpStatusCode.NotFound;
                dispensersDetailResponse.data = null;
                Log.Information("error occurred :" + ex.Message);
                ////_logger.LogError(ex.ToString());

            }
            return dispensersDetailResponse;
        }

        [HttpGet("ValidateChargerId/{ChargeBoxId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ValidateChargerIdResponse> ValidateChargerId(string ChargeBoxId)
        {
            ValidateChargerIdResponse validateChargerIdResponse = new ValidateChargerIdResponse();
            try
            {
                var charher = await _mediator.Send(new ValidateChargerIdQuery(ChargeBoxId));
                validateChargerIdResponse.data = charher;
                validateChargerIdResponse.StatusCode = (int)HttpStatusCode.OK;
                if(charher.Id != 0){
                validateChargerIdResponse.StatusMessage = RespnoseMessage.Record_found;
                }
                else{
                    validateChargerIdResponse.data = null;
                    validateChargerIdResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    validateChargerIdResponse.StatusMessage = RespnoseMessage.Record_not_found;
                }


            }
            catch (Exception ex)
            {
                validateChargerIdResponse.data = null;
                validateChargerIdResponse.StatusCode = 500;
                validateChargerIdResponse.StatusMessage = ex.Message.ToString();
                Log.Information("error occurred :" + ex.Message);
            }
            return validateChargerIdResponse;



        }

        #region Modem DDL List
        /// <summary>
        /// This api is used for binding the Modem data with dropdown , Id, SerialNumer
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        [HttpPost("GetModemDDL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetModemDDL(PadDataRequest  userId)
        {
            dynamic expendo = new ExpandoObject();
            var result = await _mediator.Send(new GetModemDDLQuery(userId.userId, userId.dispenserId));
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
        [HttpPost("GetPlugType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetPlugType(PlugTypeRequest plugTypeRequest)
        {
            dynamic expendo = new ExpandoObject();
            var result = await _mediator.Send(new GetAllPlugTypeQuery(plugTypeRequest.userId));
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
        [HttpPost("GetConnectorType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetConnectorType(ConnectorTypeRequest plugTypeRequest)
        {
            dynamic expendo = new ExpandoObject();
            var result = await _mediator.Send(new GetConnectorTypeQuery(plugTypeRequest.userId));
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

        #endregion


        [HttpPost("GetLocationDispensers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<LocationDispensersResponse> GetLocationDispensers([FromBody] LocationDispensersRequest locationDispenser)
        {
            LocationDispensersResponse dispensersDetailResponse = new LocationDispensersResponse();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                if (locationDispenser.PageSize == 0) locationDispenser.PageSize = 10;
                if (locationDispenser.PageNumber == 0) locationDispenser.PageNumber = 1;
                var dispensers = await _mediator.Send(new GetLocationDispensersQuery(locationDispenser));
                if (dispensers.Count > 0)
                    dispensersDetailResponse.StatusMessage = RespnoseMessage.Record_found;
                else dispensersDetailResponse.StatusMessage = RespnoseMessage.Record_not_found;

                dispensersDetailResponse.StatusCode = (int)HttpStatusCode.OK;
                dispensersDetailResponse.data = dispensers;
                dispensersDetailResponse.paginationResponse = new Core.PagingHelper.PaginationResponse
                {
                    TotalCount = dispensers.TotalCount,
                    PageSize = dispensers.PageSize,
                    CurrentPage = dispensers.CurrentPage,
                    TotalPages = dispensers.TotalPages,
                    HasNext = dispensers.HasNext,
                    HasPrevious = dispensers.HasPrevious
                };
            }
            catch (Exception ex)
            {
                dispensersDetailResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                dispensersDetailResponse.StatusCode = (int)HttpStatusCode.NotFound;
                dispensersDetailResponse.data = null;
                Log.Information("error occurred :" + ex.Message);
                ////_logger.LogError(ex.ToString());

            }
            return dispensersDetailResponse;
        }

        [HttpPost("GetChargeboxIdByLocationsId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserLocationResponse> GetDispenserByLocationsId([FromBody] DispenserLocationRequest locationDispenser)
        {
            DispenserLocationResponse dispenserByLocationQueryResponse = new DispenserLocationResponse();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                DispenserLocationResponse dispenser = await _mediator.Send(new GetDispenserslocationIdQuery(locationDispenser));
                if (dispenser != null)
                {
                    dispenserByLocationQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                    dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                    dispenserByLocationQueryResponse.Data = dispenser.Data;
                }
                else
                {
                    dispenserByLocationQueryResponse.Data = new List<GetDispenserLocationResponse>();
                    dispenserByLocationQueryResponse.StatusMessage = RespnoseMessage.Record_not_found;
                }
            }
            catch (Exception ex)
            {
                dispenserByLocationQueryResponse.StatusMessage = ex.Message.ToString();
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                dispenserByLocationQueryResponse.Data = new List<GetDispenserLocationResponse>(); 
                //////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return dispenserByLocationQueryResponse;
        }

    }
}

