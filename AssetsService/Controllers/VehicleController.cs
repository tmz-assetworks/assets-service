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
                    res.StatusMessage = "Record found";
                }
                else
                {
                    res.StatusMessage = "Record not found";
                }
                res.data = vehicle;
            }
            catch (Exception ex)
            {
                res.StatusMessage = "Operaion failed!";
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
                if (command.VehicleModelId <= 0)
                {
                    createCommonResponse.statusMessage = "Please provide Vehicle ModelId.";
                    return createCommonResponse;
                }
                if (command.VehicleModelYearid <= 0)
                {
                    createCommonResponse.statusMessage = "Please provide Vehicle ModelYearid.";
                    return createCommonResponse;
                }
                if (command.VehicleModelId <= 0)
                {
                    createCommonResponse.statusMessage = "Please provide Vehicle ModelId.";
                    return createCommonResponse;
                }

                if (command.RfIdCardsAssigneds is null || command.RfIdCardsAssigneds.Count == 0)
                {
                    createCommonResponse.statusMessage = "Please provide Vehicle RfId Card Assigned.";
                    createCommonResponse.statusCode = 400;
                    return createCommonResponse;
                }
                if (ModelState.IsValid)
                {
                    var createresult = await _mediator.Send(command);
                    if (createresult != null && createresult.id > 0)
                    {
                        createCommonResponse.Id = createresult.id;
                        createCommonResponse.statusMessage = "Record saved successfully.";
                    }
                    else
                    {
                        if (createresult != null && !string.IsNullOrEmpty(createresult.VIN))
                        {

                            createCommonResponse.statusMessage = "Dublicate entry for :" + createresult.VIN;
                        }
                        else
                        {
                            createCommonResponse.statusMessage = "Record not saved";
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
                createCommonResponse.statusMessage = "Operation Failed!";
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
                if (command.VehicleModelId <= 0)
                {
                    expandoObject.StatusMessage = "Please provide Vehicle ModelId.";
                    return expandoObject;
                }
                if (command.VehicleModelYearid <= 0)
                {
                    expandoObject.StatusMessage = "Please provide Vehicle ModelYearid.";
                    return expandoObject;
                }
                if (command.VehicleModelId <= 0)
                {
                    expandoObject.StatusMessage = "Please provide Vehicle ModelId.";
                    return expandoObject;
                }
                var resultdata = await _mediator.Send(command);

                if (resultdata != null && resultdata.id > 0)
                {
                    expandoObject.StatusMessage = "Record update successfully.";
                    expandoObject.data = resultdata;
                }
                else
                {
                    if (resultdata != null && !string.IsNullOrEmpty(resultdata.VIN))
                    {

                        expandoObject.statusMessage = "Dublicate entry for :" + resultdata.VIN;
                    }

                    else
                    {
                        expandoObject.StatusMessage = "Record not saved";

                    }
                }
            }

            catch (Exception ex)
            {
                Log.Information("error occurred :" + ex.Message);
                expandoObject.StatusMessage = "Operation Failed!";
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
                    expandoObject.statusMessage = "Please provide Vehicle Id value.";
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = "Please provide ModifiedBy value.";
                    return expandoObject;
                }
                var result = await _mediator.Send(command);

                if (result is not null && result.Id > 0)
                    expandoObject.statusMessage = "Record status changed successfully.";
                else
                    expandoObject.statusMessage = "Record not found.";

                return expandoObject;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                expandoObject.statusMessage = "Operation Failed!";
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
                statusVehicleresponcse = await _mediator.Send(new GetAllVechicleQuery(getAllVehicleRequest));

                if (statusVehicleresponcse != null && statusVehicleresponcse.data.Count > 0)
                {
                    allVehicle.StatusMessage = "Record found";
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

                    allVehicle.StatusMessage = "Record not found";
                    allVehicle.StatusCode = (int)HttpStatusCode.OK;
                    allVehicle.data = null;
                }
            }
            catch (Exception ex)
            {
                allVehicle.StatusMessage = "Operaion failed!";
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
                vehicleMakeDDLResponse.statusMessage = "Record found.";
                List<ListDropDown> res = await _mediator.Send(new GetVechicleModelDDLQuery());

                vehicleMakeDDLResponse.data = res;
                //_logger.LogInformation("Get all the data of Vehicle Make.");
                return vehicleMakeDDLResponse;
            }
            catch (Exception ex)
            {
                vehicleMakeDDLResponse.statusMessage = "Operaion failed!";
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
                    vehicleMakeDDLResponse.statusMessage = "Record found.";
                    vehicleMakeDDLResponse.data = res;
                }
                else
                { vehicleMakeDDLResponse.statusMessage = "Record not found."; }
                return vehicleMakeDDLResponse;
            }
            catch (Exception ex)
            {
                vehicleMakeDDLResponse.statusMessage = "Operaion failed!";
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
                    vehicleResponse.StatusMessage = "Record found";
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

                    vehicleResponse.StatusMessage = "List Record not found.";
                    vehicleResponse.data = null;
                    vehicleResponse.paginationResponse = new PaginationResponse();
                }
            }
            catch (Exception ex)
            {
                vehicleResponse.StatusMessage = "Operaion failed!";
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
                    vehicleDetails.StatusMessage = "Record found";
                }
                else
                {
                    vehicleDetails.StatusMessage = "Record not found";
                }
                return vehicleDetails;
            }
            catch (Exception ex)
            {
                vehicleDetails.StatusMessage = "Operaion failed!";
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
                vehicleMakeDDLResponse.statusMessage = "Record found.";
                List<ListDropDown> res = await _mediator.Send(new GetVechicleMakeDDLQuery());
                vehicleMakeDDLResponse.data = res;
                return vehicleMakeDDLResponse;
            }
            catch (Exception ex)
            {
                vehicleMakeDDLResponse.statusMessage = "Operaion failed!";
                vehicleMakeDDLResponse.statusCode = (int)HttpStatusCode.NotFound;
                vehicleMakeDDLResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return vehicleMakeDDLResponse;
        }

    }
}
