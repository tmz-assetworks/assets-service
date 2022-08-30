using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Responses.Assets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<VehicleId> GetAllVehicleById(int id)
        {
            VehicleId res = new VehicleId();
            try
            {
                AssetsService.Core.Entities.Vehicle vehicle = await _mediator.Send(new GetByIdVehicleQuery(id));
                if (vehicle != null)
                {
                    res.StatusMessage = "Record found";
                    res.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    res.StatusMessage = "Record not found";
                    res.StatusCode = (int)HttpStatusCode.NotFound;
                }
                res.data = vehicle;
            }
            catch (Exception ex)
            {
                res.StatusMessage = "Operaion failed!";
                res.StatusCode = (int)HttpStatusCode.NotFound;
                res.data = null;
                _logger.LogError(ex.ToString());
            }
            return res;
        }
        [HttpPost("CreateVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Create Vehicle successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Vehicle not Created "
                };
            }
        }
        [HttpPut("UpdateVehicle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> UpdateCable([FromBody] UpdateVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update Vehicle successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Vehicle not Update "
                };
            }
        }

        [HttpDelete("DeleteVehicleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleResponse>> DeleteVehicle([FromBody] DeleteVehicleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Delete Vehicle successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Vehicle not Deleted "
                };
            }
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
                    allVehicle.paginationResponse = new PaginationResponse();
                }
            }
            catch (Exception ex)
            {
                allVehicle.StatusMessage = "Operaion failed!";
                allVehicle.StatusCode = (int)HttpStatusCode.NotFound;
                allVehicle.data = null;
               

            }
            return allVehicle;
        }

    }
}
