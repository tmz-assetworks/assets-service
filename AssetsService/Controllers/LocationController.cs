using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using AssetsService.Application.Responses.Assets;
using AssetsService.Application.Queries;
using AssetsService.Core.Response;
using Newtonsoft.Json;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using System.Dynamic;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using AssetsService.Infrastructure.Helpers;
using AssetsService.Core.ConstantResponse;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<LocationController> _logger;
        string JSONString = string.Empty;
        TokenBase _token;
        public LocationController(IMediator mediator, ILogger<LocationController> logger,TokenBase token)
        {
            //_logger = logger;
            _mediator = mediator;
            _token=token;
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
        [HttpGet("GetAllLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AllLocationStatusQueryResponse> GetAllLocation()
        {
            AllLocationStatusQueryResponse allLocationStatusQueryResponse = new AllLocationStatusQueryResponse();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                List<AssetsService.Core.Entities.Location> location = await _mediator.Send(new GetAllLocationQuery());
                List<LocationStatusData> locationdata = location.Select(x => new LocationStatusData { Id = x.Id, LocationName = x.LocationName, LocationStatus = x.LocationStatus.LocationStatusName }).OrderBy(a => a.LocationName).ToList();
                allLocationStatusQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                allLocationStatusQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                allLocationStatusQueryResponse.data = locationdata;
                //_logger.LogInformation("Get all Location data");
            }
            catch (Exception ex)
            {
                allLocationStatusQueryResponse.StatusMessage = ex.Message.ToString();
                allLocationStatusQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                allLocationStatusQueryResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return allLocationStatusQueryResponse;
        }

        [HttpGet("GetAllLocationName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AllLocationNameResponse> GetAllLocationName()
        {
            AllLocationNameResponse allLocationNameResponse = new AllLocationNameResponse();
            try
            {
                List<LocationData> location = await _mediator.Send(new GetAllLocationNameQuery());
                //List<LocationData> locationdata = location.Select(x => new LocationData { Id = x.Id, LocationName = x.LocationName }).ToList();
                allLocationNameResponse.StatusMessage = RespnoseMessage.Record_found;
                allLocationNameResponse.StatusCode = (int)HttpStatusCode.OK;
                allLocationNameResponse.data = location;
                //_logger.LogInformation("Get all Location Name data");
            }
            catch (Exception ex)
            {
                allLocationNameResponse.StatusMessage = ex.Message.ToString();
                allLocationNameResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                allLocationNameResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return allLocationNameResponse;
        }

        [HttpPost("GetLocationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationListResponse>> GetLocationList([FromBody] LocationListRequst locationListRequst)
        {
            LocationListResponse locationListResponse = new LocationListResponse();
            Locationalist Locationalist = new Locationalist();
            List<StatusData> statusData = new List<StatusData>();
            StatusList StatusList = new StatusList();
            try
            {
                if (locationListRequst.PageSize == 0) locationListRequst.PageSize = 10;
                if (locationListRequst.PageNumber == 0) locationListRequst.PageNumber = 1;
                Locationalist = await _mediator.Send(new GetLocationListQuery(locationListRequst));
                if (Locationalist != null && Locationalist.data.Count() > 0)
                {
                    locationListResponse.StatusMessage = RespnoseMessage.Record_found;
                    locationListResponse.data = Locationalist.data;
                    statusData = new List<StatusData>(){
                            new StatusData () {
                                Key = "Total Locations",
                                Value = Locationalist.TotalLocation,
                                Color = "#E97300",
                            },
                            new StatusData () {
                                Key = "Live",
                                Value = Locationalist.Live,
                                Color = "#90993F",
                            },
                            new StatusData () {
                                Key = "Under Maintenance",
                                Value = Locationalist.UnderMaintenance,
                                Color = "#757575",
                            },                            
                            new StatusData () {
                                Key = "Inactive",
                                Value = Locationalist.Inactive,
                                Color = "#0062A6",
                            },
                            new StatusData () {
                                Key = "Upcoming",
                                Value = Locationalist.Upcomming,
                                Color = "#0062A6",
                            },
                    };
                    StatusList.StatusData = statusData;
                    locationListResponse.statusList = StatusList;
                    locationListResponse.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = Locationalist.data.TotalCount,
                        PageSize = Locationalist.data.PageSize,
                        CurrentPage = Locationalist.data.CurrentPage,
                        TotalPages = Locationalist.data.TotalPages,
                        HasNext = Locationalist.data.HasNext,
                        HasPrevious = Locationalist.data.HasPrevious
                    };
                    locationListResponse.StatusCode = (int)HttpStatusCode.OK;
                    //_logger.LogInformation("Get all Location List data");
                }
                else
                {
                    locationListResponse.StatusMessage = RespnoseMessage.Record_not_found;
                    locationListResponse.StatusCode = (int)HttpStatusCode.OK;
                    locationListResponse.data = null;
                }
            }
            catch (Exception ex)
            {
                locationListResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                locationListResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                locationListResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return locationListResponse;
        }

        [HttpGet("GetLocationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<LocationQueryResponse> GetLocationById(long Id)
        {
            LocationQueryResponse locationQueryResponse = new LocationQueryResponse();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                AssetsService.Core.Entities.Location location = await _mediator.Send(new GetLocationByIdQuery(Id));

                if (location != null)
                {
                    locationQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                    locationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {

                    locationQueryResponse.StatusMessage = RespnoseMessage.Record_not_found;
                    locationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                }


                locationQueryResponse.data = location;
                //_logger.LogInformation("Get Location by Id");
            }
            catch (Exception ex)
            {
                locationQueryResponse.StatusMessage = RespnoseMessage.Opeartion_Failed + ex.Message.ToString();
                locationQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                locationQueryResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return locationQueryResponse;
        }

        [HttpGet("GetAllLocationStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<LocationStatusResponcse> GetAllLocationStatus()
        {
            LocationStatusResponcse locationStatusResponcse = new LocationStatusResponcse();

            try
            {
                List<AllLocationStatuss> locationSchedule = await _mediator.Send(new GetAllLocationStatusQuery());
                locationStatusResponcse.StatusMessage = RespnoseMessage.Record_found;
                locationStatusResponcse.StatusCode = (int)HttpStatusCode.OK;
                locationStatusResponcse.data = locationSchedule;
                //_logger.LogInformation("Get all Location Status data");
            }
            catch (Exception ex)
            {
                locationStatusResponcse.StatusMessage = ex.Message.ToString();
                locationStatusResponcse.StatusCode = (int)HttpStatusCode.BadRequest;
                locationStatusResponcse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return locationStatusResponcse;
        }

        [HttpGet("GetAllDepartmentList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DepartmentListResponcse> GetAllDepartmentList()
        {
            DepartmentListResponcse departmentListResponcse = new DepartmentListResponcse();

            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                List<AllDepartmentList> departmentList = await _mediator.Send(new GetAllDepartmentListQuery());
                departmentListResponcse.StatusMessage = RespnoseMessage.Record_found;
                departmentListResponcse.StatusCode = (int)HttpStatusCode.OK;
                departmentListResponcse.data = departmentList;
                //_logger.LogInformation("Get all Department List data");
            }
            catch (Exception ex)
            {
                departmentListResponcse.StatusMessage = ex.Message.ToString();
                departmentListResponcse.StatusCode = (int)HttpStatusCode.BadRequest;
                departmentListResponcse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
            }
            return departmentListResponcse;
        }


        [HttpPost("CreateLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> CreateLocation([FromBody] CreateLocationCommand command)
        {
            dynamic expendo = new ExpandoObject();
            var result = await _mediator.Send(command);
            try
            {
                if (result.Id != 0)
                {

                    expendo.StatusCode = 200;
                    expendo.Id = result.Id;
                    expendo.StatusMessage = RespnoseMessage.Record_Save_Successfully;
                    //_logger.LogInformation("New Location created successfully");
                }
                else
                {
                    expendo.StatusCode = 200;
                    expendo.StatusMessage = RespnoseMessage.Record_Not_Saved;

                }
            }
            catch (Exception ex)
            {
                expendo.StatusCode = 200;
                expendo.StatusMessage = RespnoseMessage.Record_Not_Saved;
                //_logger.LogError(ex.StackTrace.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return (expendo);
        }




        [HttpDelete("DeleteLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationResponse>> DeleteLocation([FromBody] DeleteLocationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Location deleted successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = RespnoseMessage.Exception,
                    StatusCode = 404,
                    Content = RespnoseMessage.Not_Deleted
                };
            }
        }


        [HttpPut("UpdateLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationResponse>> UpdateLocation([FromBody] UpdateLocationCommand command)
        {
            try
            {
                // command.ModifiedOn = DateTime.Now;
                var result = await _mediator.Send(command);
                //_logger.LogInformation("Location updated successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);
                return new ContentResult()
                {
                    ContentType = RespnoseMessage.Exception,
                    StatusCode = 404,
                    Content = RespnoseMessage.Record_Not_Updated
                };
            }
        }


        [HttpPost("GetLocationsDispenserformap")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Core.Response.LocationsDispenserformapResponce>> GetLocationsDispenserformap([FromBody] List<long> Id)
        {
            LocationsDispenserformapResponce locationQueryResponse = new LocationsDispenserformapResponce();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                List<LocationsDispenser> location = await _mediator.Send(new GetLocationsDispenserformapQuery(Id));

                locationQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                locationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                locationQueryResponse.data = location;
                //_logger.LogInformation("Get Location Dispenser Count");
            }
            catch (Exception ex)
            {
                locationQueryResponse.StatusMessage = ex.Message.ToString();
                locationQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                locationQueryResponse.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());

            }
            return locationQueryResponse;

        }




        /// <summary>
        /// Get data for Locations Grid
        /// </summary>
        /// <param name="locationDispenserRequest"> Search by Location name </param>
        /// <returns> Locations List </returns>
        [HttpPost("GetLocationsDispenserDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationsDispenserDetailsResponse>> GetLocationsDispenserDetails([FromBody] LocationDispenserRequest locationDispenserRequest)
        {
            LocationsDispenserDetailsResponse locationQueryResponse = new LocationsDispenserDetailsResponse();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                if (locationDispenserRequest.PageSize == 0) locationDispenserRequest.PageSize = 10;
                if (locationDispenserRequest.PageNumber == 0) locationDispenserRequest.PageNumber = 1;
                var location = await _mediator.Send(new GetLocationsDispenserDetailsQuery(locationDispenserRequest));

                // Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                if (location != null && location.Count > 0)
                {
                    locationQueryResponse.StatusMessage = RespnoseMessage.Record_found;
                    locationQueryResponse.data = location;
                    locationQueryResponse.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = location.TotalCount,
                        PageSize = location.PageSize,
                        CurrentPage = location.CurrentPage,
                        TotalPages = location.TotalPages,
                        HasNext = location.HasNext,
                        HasPrevious = location.HasPrevious
                    };
                    locationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    locationQueryResponse.StatusMessage = RespnoseMessage.Record_not_found;
                    locationQueryResponse.data = null;
                    locationQueryResponse.paginationResponse = new PaginationResponse();
                }

                //_logger.LogInformation("Get Locations  Data List");
            }
            catch (Exception ex)
            {
                locationQueryResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                locationQueryResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                locationQueryResponse.data = null;
                Log.Information("error occurred :" + ex.Message);
                //_logger.LogError(ex.ToString());
            }
            return locationQueryResponse;
        }


        [HttpPost("GetDispenserByLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Core.Response.LocationDispenserForLocationResponse>> GetDispenserByLocation([FromBody] List<long> Id)
        {
            LocationDispenserForLocationResponse locationDispenserForLocationResponse = new LocationDispenserForLocationResponse();
            try
            {
                _token.acces_token = await HttpContext.GetTokenAsync("access_token");
                List<LocationDispenserForLocation> location = await _mediator.Send(new GetLocationsDispenserForLocationQuery(Id));
                if (location != null && location.Count() > 0)
                    locationDispenserForLocationResponse.StatusMessage = RespnoseMessage.Record_found;
                else
                    locationDispenserForLocationResponse.StatusMessage = RespnoseMessage.Record_not_found;
                locationDispenserForLocationResponse.StatusCode = (int)HttpStatusCode.OK;
                locationDispenserForLocationResponse.data = location;
                //_logger.LogInformation("Get Location Dispenser Count");
            }
            catch (Exception ex)
            {
                locationDispenserForLocationResponse.StatusMessage = RespnoseMessage.Opeartion_Failed;
                locationDispenserForLocationResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                locationDispenserForLocationResponse.data = null;
                //_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return locationDispenserForLocationResponse;

        }



    }
}