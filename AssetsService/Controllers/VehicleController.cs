using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.EnumData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Net;
using AssetsService.Infrastructure.Helpers;
using System.Text.Json;
using AssetsService.Core.Response;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using AssetsService.Core.ConstantResponse;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IMediator mediator, ILogger<VehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetAllVehicleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<VehicleInfo> GetAllVehicleById(int id)
        {
            VehicleInfo res = new VehicleInfo();
            try
            {
                Vehicle vehicle = await _mediator.Send(new GetByIdVehicleInfoQuery(id));
                res.StatusCode = (int)HttpStatusCode.OK;
                if (vehicle != null)
                {
                    res.StatusMessage = RespnoseMessage.Record_found;
                }
                else
                {
                    res.StatusMessage = RespnoseMessage.Record_not_found;
                }
                res.data = vehicle;
            }
            catch (Exception ex)
            {
                res.StatusMessage = RespnoseMessage.Opeartion_Failed;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
                res.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());
            }
            return res;
        }



        [HttpPost("CreateVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCommonResponse>> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            CreateCommonResponse createCommonResponse = new CreateCommonResponse();
            try
            {
                createCommonResponse.statusCode = 200;
                
                

                if (command.RfIdCardsAssigneds is null || command.RfIdCardsAssigneds.Count == 0)
                {
                    createCommonResponse.statusMessage = RespnoseMessage.Please_provide_Vehicle_Rfid_card_Assigned;
                    createCommonResponse.statusCode = 400;
                    return createCommonResponse;
                }
                if (ModelState.IsValid)
                {
                    var createresult = await _mediator.Send(command);
                    if (createresult != null && createresult.id > 0)
                    {
                        createCommonResponse.Id = createresult.id;
                        createCommonResponse.statusMessage = RespnoseMessage.Record_Save_Successfully;
                    }
                    else
                    {
                        if (createresult != null && !string.IsNullOrEmpty(createresult.VIN))
                        {

                            createCommonResponse.statusMessage = RespnoseMessage.Dublicate_entry_for + createresult.VIN;
                        }
                        else
                        {
                            createCommonResponse.statusMessage = RespnoseMessage.Record_Not_Saved;
                        }
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


        [HttpPut("UpdateVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> UpdateVehicle([FromBody] UpdateVehicleCommand command)
        {
            dynamic expandoObject = new ExpandoObject();
            try
            {
                expandoObject.StatusCode = 200;
                if (command.ModelYear <= 0)
                {
                    expandoObject.StatusMessage = RespnoseMessage.Please_provide_Vehicle_ModelYear;
                    return expandoObject;
                }
                var resultdata = await _mediator.Send(command);

                if (resultdata != null && resultdata.id > 0)
                {
                    expandoObject.StatusMessage = RespnoseMessage.Record_Updated_Successfully;
                    expandoObject.data = resultdata;
                }
                else
                {
                    if (resultdata != null && !string.IsNullOrEmpty(resultdata.VIN))
                    {
                        expandoObject.statusMessage = RespnoseMessage.Dublicate_entry_for + resultdata.VIN;
                    }
                    else
                    {
                        expandoObject.StatusMessage = RespnoseMessage.Record_Not_Saved;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Information("error occurred :" + ex.Message);
                expandoObject.StatusMessage = RespnoseMessage.Opeartion_Failed;
                expandoObject.StatusCode = 404;
            }
            return expandoObject;
        }

        [HttpPut("IsActiveVehicleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ExpandoObject> IsActiveVehicleById([FromBody] IsActiveVehicleCommand command)
        {
            dynamic expandoObject = new ExpandoObject();
            try
            {
                expandoObject.statusCode = 200;
                if (command.Id < 0)
                {
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_Vehicle_Id_value;
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = RespnoseMessage.Please_provide_ModifiedBy_value;
                    return expandoObject;
                }
                var result = await _mediator.Send(command);

                if (result is not null && result.Id > 0)
                    expandoObject.statusMessage = RespnoseMessage.Record_status_changed_successfully;
                else
                    expandoObject.statusMessage = RespnoseMessage.Record_not_found;

                return expandoObject;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                expandoObject.statusMessage = RespnoseMessage.Opeartion_Failed;
                expandoObject.statusCode = (int)HttpStatusCode.BadRequest;
            }
            return expandoObject;
        }

        [HttpPost("GetAllVechicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllVehicle>> GetAllVechicle([FromBody] GetAllVehicleRequest getAllVehicleRequest)
        {
            AllVehicle allVehicle = new AllVehicle();
            StatusVehicleresponcse statusVehicleresponcse = new StatusVehicleresponcse();
            try
            {
                if (getAllVehicleRequest.PageSize == 0) getAllVehicleRequest.PageSize = 10;
                if (getAllVehicleRequest.PageNumber == 0) getAllVehicleRequest.PageNumber = 1;
                if (getAllVehicleRequest.SearchParam != "") getAllVehicleRequest.PageNumber = 1;
                statusVehicleresponcse = await _mediator.Send(new GetAllVechicleQuery(getAllVehicleRequest));

                if (statusVehicleresponcse != null && statusVehicleresponcse.data.Count > 0)
                {
                    allVehicle.StatusMessage = RespnoseMessage.Record_found;
                    allVehicle.data = statusVehicleresponcse.data;
                    allVehicle.Active = statusVehicleresponcse.Active;
                    allVehicle.Inactive = statusVehicleresponcse.Inactive;
                    allVehicle.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = statusVehicleresponcse.data.TotalCount,
                        PageSize = statusVehicleresponcse.data.PageSize,
                        CurrentPage = statusVehicleresponcse.data.CurrentPage,
                        TotalPages = statusVehicleresponcse.data.TotalPages,
                        HasNext = statusVehicleresponcse.data.HasNext,
                        HasPrevious = statusVehicleresponcse.data.HasPrevious
                    };
                    allVehicle.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {

                    allVehicle.StatusMessage = RespnoseMessage.Record_not_found;
                    allVehicle.StatusCode = (int)HttpStatusCode.OK;
                    allVehicle.data = null;
                }
            }
            catch (Exception ex)
            {
                allVehicle.StatusMessage = RespnoseMessage.Opeartion_Failed;
                allVehicle.StatusCode = (int)HttpStatusCode.NotFound;
                allVehicle.data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allVehicle;
        }


        [HttpGet("GetVehicleModelDDLList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetVehicleModelDDLList()
        {
            dynamic vehicleMakeDDLResponse = new ExpandoObject();
            try
            {
                vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.OK;
                vehicleMakeDDLResponse.statusMessage = RespnoseMessage.Record_found;
                List<ListDropDown> res = await _mediator.Send(new GetVechicleModelDDLQuery());

                vehicleMakeDDLResponse.data = res;
                //_logger.LogInformation("Get all the data of Vehicle Make.");
                return vehicleMakeDDLResponse;
            }
            catch (Exception ex)
            {
                vehicleMakeDDLResponse.statusMessage = RespnoseMessage.Opeartion_Failed;
                vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.NotFound;
                vehicleMakeDDLResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return vehicleMakeDDLResponse;
        }



        [HttpGet("GetVehicleModelYearDDLList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetVehicleModelYearDDLList()
        {
            dynamic vehicleMakeDDLResponse = new ExpandoObject();
            try
            {
                vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.OK;
                List<ListDropDown> res = await _mediator.Send(new GetVechicleModelYearDDLQuery());
                if (res != null && res.Count() > 0)
                {
                    vehicleMakeDDLResponse.statusMessage = RespnoseMessage.Record_found;
                    vehicleMakeDDLResponse.data = res;
                }
                else
                { vehicleMakeDDLResponse.statusMessage = RespnoseMessage.Record_not_found; }
                return vehicleMakeDDLResponse;
            }
            catch (Exception ex)
            {
                vehicleMakeDDLResponse.statusMessage = RespnoseMessage.Opeartion_Failed;
                vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.NotFound;
                vehicleMakeDDLResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return vehicleMakeDDLResponse;
        }


        /// <summary>
        /// Get all Vehicle data list for admin with paggination
        /// </summary>
        /// <param name="getAllVehicleRequest"></param>
        /// <returns></returns>
        [HttpPost("GetVechicleList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleListResponse>> GetVechicleList([FromBody] GetAllVehicleRequest getAllVehicleRequest)
        {
            VehicleListData vehicleListData = new VehicleListData();
            VehicleListResponse vehicleResponse = new VehicleListResponse();
            try
            {
                if (getAllVehicleRequest.PageSize == 0) getAllVehicleRequest.PageSize = 10;
                if (getAllVehicleRequest.PageNumber == 0) getAllVehicleRequest.PageNumber = 1;
                vehicleListData = await _mediator.Send(new GetVechicleListQuery(getAllVehicleRequest));
                vehicleResponse.data = vehicleListData.data;
                vehicleResponse.statusData = new List<StatusData>();
                if (vehicleResponse != null)
                {
                    List<StatusData> statusData = new List<StatusData>()
                    {
                       new StatusData { Key = Status_Indication.VehicleActiveInActive.TotalVehicle.GetEnumDisplayName(), Value = vehicleListData!=null? (vehicleListData.Active + vehicleListData.InActive).ToString():"" , Color = VehicleStatusColor.TotalVehicle.GetEnumDisplayName() },
                       new StatusData { Key = Status_Indication.VehicleActiveInActive.Active.GetEnumDisplayName(), Value = vehicleListData!=null? vehicleListData.Active.ToString():"" , Color = VehicleStatusColor.Active.GetEnumDisplayName() },
                        new StatusData { Key = Status_Indication.VehicleActiveInActive.InActive.GetEnumDisplayName(), Value = vehicleListData!=null? vehicleListData.InActive.ToString():"" , Color = VehicleStatusColor.InActive.GetEnumDisplayName() },
                        };
                    vehicleResponse.statusData = statusData;
                }
                if (vehicleListData != null && vehicleListData.data != null && vehicleListData.data.Count > 0)
                {
                    vehicleResponse.StatusMessage = RespnoseMessage.Record_found;
                    vehicleResponse.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = vehicleListData.data.TotalCount,
                        PageSize = vehicleListData.data.PageSize,
                        CurrentPage = vehicleListData.data.CurrentPage,
                        TotalPages = vehicleListData.data.TotalPages,
                        HasNext = vehicleListData.data.HasNext,
                        HasPrevious = vehicleListData.data.HasPrevious
                    };
                    vehicleResponse.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {

                    vehicleResponse.StatusMessage = RespnoseMessage.Record_not_found;
                    vehicleResponse.data = null;
                    vehicleResponse.paginationResponse = new PaginationResponse();
                }
            }
            catch (Exception ex)
            {
                vehicleResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                vehicleResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                vehicleResponse.data = null;
                Log.Information("error occurred :" + ex.Message);
            }
            return vehicleResponse;
        }
        [HttpGet("GetVehicleDetailsById/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<VehicleDetailsResponse> GetVehicleDetailsById(int Id)
        {
            VehicleDetailsResponse vehicleDetails = new VehicleDetailsResponse();
            try
            {
                vehicleDetails.data = new List<VehicleDTO>();
                VehicleDTO vehicleDTO = await _mediator.Send(new GetByIdVehicleQuery(Id));
                vehicleDetails.StatusCode = (int)HttpStatusCode.OK;
                if (vehicleDTO != null)
                {
                    vehicleDetails.data.Add(vehicleDTO);
                    vehicleDetails.StatusMessage = RespnoseMessage.Record_found;
                }
                else
                {
                    vehicleDetails.StatusMessage = RespnoseMessage.Record_not_found;
                }
                return vehicleDetails;
            }
            catch (Exception ex)
            {
                vehicleDetails.StatusMessage = RespnoseMessage.Opeartion_Failed;
                vehicleDetails.StatusCode = (int)HttpStatusCode.NotFound;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());
            }
            return vehicleDetails;
        }

        [HttpGet("GetVehicleMakeDDLList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> GetVehicleMakeDDLList()
        {
            dynamic vehicleMakeDDLResponse = new ExpandoObject();
            try
            {
                vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.OK;
                vehicleMakeDDLResponse.statusMessage = RespnoseMessage.Record_found;
                List<ListDropDown> res = await _mediator.Send(new GetVechicleMakeDDLQuery());
                vehicleMakeDDLResponse.data = res;
                return vehicleMakeDDLResponse;
            }
            catch (Exception ex)
            {
                vehicleMakeDDLResponse.statusMessage = RespnoseMessage.Opeartion_Failed;
                vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.NotFound;
                vehicleMakeDDLResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return vehicleMakeDDLResponse;
        }

    }
}
