using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using AssetsService.Application.Responses.Assets;
using AssetsService.Application.Queries;
using AssetsService.Core.Response;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<LocationController> _logger;
        string JSONString = string.Empty;
        public LocationController(IMediator mediator, ILogger<LocationController> logger)
        {
            _logger = logger;
            _mediator = mediator;
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
                List<AssetsService.Core.Entities.Location> location = await _mediator.Send(new GetAllLocationQuery());
                List<LocationStatusData> locationdata = location.Select(x => new LocationStatusData { Id = x.Id, LocationName = x.LocationName, LocationStatus = x.LocationStatus.LocationStatusName }).ToList();
                allLocationStatusQueryResponse.StatusMessage = "Record found";
                allLocationStatusQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                allLocationStatusQueryResponse.data = locationdata;
                _logger.LogInformation("Get all Location data");
            }
            catch (Exception ex)
            {
                allLocationStatusQueryResponse.StatusMessage = ex.Message.ToString();
                allLocationStatusQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                allLocationStatusQueryResponse.data = null;
                _logger.LogError(ex.ToString());

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
                allLocationNameResponse.StatusMessage = "Record found";
                allLocationNameResponse.StatusCode = (int)HttpStatusCode.OK;
                allLocationNameResponse.data = location;
                _logger.LogInformation("Get all Location Name data");
            }
            catch (Exception ex)
            {
                allLocationNameResponse.StatusMessage = ex.Message.ToString();
                allLocationNameResponse.StatusCode = (int)HttpStatusCode.NotFound;
                allLocationNameResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return allLocationNameResponse;
        }

        [HttpGet("GetLocationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<LocationQueryResponse> GetLocationById(long Id)
        {
            LocationQueryResponse locationQueryResponse = new LocationQueryResponse();
            try
            {
                AssetsService.Core.Entities.Location location = await _mediator.Send(new GetLocationByIdQuery(Id));

                if (location != null)
                {
                    locationQueryResponse.StatusMessage = "Record found";
                    locationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {

                    locationQueryResponse.StatusMessage = "Record not found";
                    locationQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                }


                locationQueryResponse.data = location;
                _logger.LogInformation("Get Location by Id");
            }
            catch (Exception ex)
            {
                locationQueryResponse.StatusMessage = "Operaion failed!" + ex.Message.ToString();
                locationQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                locationQueryResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return locationQueryResponse;
        }


        [HttpPost("CreateLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationResponse>> CreateLocation([FromBody] CreateLocationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("New Location created successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Location not Created "
                };
            }
        }




        [HttpDelete("DeleteLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationResponse>> DeleteLocation([FromBody] DeleteLocationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Location deleted successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Location not Delete "
                };
            }
        }


        [HttpPut("UpdateLocation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationResponse>> UpdateLocation([FromBody] UpdateLocationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Location updated successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Location not Update "
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
                List<LocationsDispenser> location = await _mediator.Send(new GetLocationsDispenserformapQuery(Id));

                locationQueryResponse.StatusMessage = "Record found";
                locationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                locationQueryResponse.data = location;
                _logger.LogInformation("Get Location Dispenser Count");
            }
            catch (Exception ex)
            {
                locationQueryResponse.StatusMessage = ex.Message.ToString();
                locationQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                locationQueryResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return locationQueryResponse;

        }

        [HttpPost("GetLocationsDispenserDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Core.Response.LocationsDispenserDetailsResponce>> GetLocationsDispenserDetails([FromBody] List<long> Id)
        {
            LocationsDispenserDetailsResponce locationQueryResponse = new LocationsDispenserDetailsResponce();
            try
            {

                List<LocationsDispenserDetails> location = await _mediator.Send(new GetLocationsDispenserDetailsQuery(Id));

                locationQueryResponse.StatusMessage = "Record found";
                locationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                locationQueryResponse.data = location;
                _logger.LogInformation("Get Location Dispenser Count");
            }
            catch (Exception ex)
            {
                locationQueryResponse.StatusMessage = ex.Message.ToString();
                locationQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                locationQueryResponse.data = null;
                _logger.LogError(ex.ToString());

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

                List<LocationDispenserForLocation> location = await _mediator.Send(new GetLocationsDispenserForLocationQuery(Id));
                if (location != null && location.Count() > 0)
                    locationDispenserForLocationResponse.StatusMessage = "Record found";
                else
                    locationDispenserForLocationResponse.StatusMessage = "Record not found";
                locationDispenserForLocationResponse.StatusCode = (int)HttpStatusCode.OK;
                locationDispenserForLocationResponse.data = location;
                _logger.LogInformation("Get Location Dispenser Count");
            }
            catch (Exception ex)
            {
                locationDispenserForLocationResponse.StatusMessage = "Operation failed!";
                locationDispenserForLocationResponse.StatusCode = (int)HttpStatusCode.NotFound;
                locationDispenserForLocationResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return locationDispenserForLocationResponse;

        }



    }
}