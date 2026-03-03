using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.ConstantResponse;
using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Dynamic;
using System.Net;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OwningDepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<VehicleController> _logger;

        public OwningDepartmentsController(IMediator mediator, ILogger<VehicleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCommonResponse>> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            CreateCommonResponse createCommonResponse = new ();
            try
            {


                if (string.IsNullOrWhiteSpace(command.DepartmentName))
                {
                    createCommonResponse.statusMessage = "Please provide Department Name";
                    createCommonResponse.statusCode = 400;
                    return createCommonResponse;
                }
                if (ModelState.IsValid)
                {
                    var createresult = await _mediator.Send(command);
                    if (createresult != null)
                    {
                        createCommonResponse.Id = createresult.Id;
                        createCommonResponse.statusMessage = RespnoseMessage.Record_Save_Successfully;
                        createCommonResponse.statusCode = 200;
                    }
                }
                else
                {
                    createCommonResponse.statusMessage = ModelState.Where(m => m.Value!.Errors.Any()).Select(x => new { x.Key, x.Value!.Errors }).ToString()!;

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

        [HttpPut("UpdateDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCommonResponse>> UpdateDepartment([FromBody] UpdateDepartmentCommand command)
        {
            CreateCommonResponse createCommonResponse = new ();
            try
            {

                if (string.IsNullOrWhiteSpace(command.DepartmentName))
                {
                    createCommonResponse.statusMessage = "Please provide Department Name";
                    createCommonResponse.statusCode = 400;
                    return createCommonResponse;
                }
                if (ModelState.IsValid)
                {
                    var createresult = await _mediator.Send(command);
                    if (createresult != null )
                    {
                        createCommonResponse.Id = createresult.Id;
                        createCommonResponse.statusMessage = RespnoseMessage.Record_Save_Successfully;
                        createCommonResponse.statusCode = 200;
                    }
                }
                else
                {
                    createCommonResponse.statusMessage = ModelState.Where(m => m.Value!.Errors.Any()).Select(x => new { x.Key, x.Value!.Errors }).ToString()!;

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

        [HttpPost("GetAllDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllDepartment>> GetAllDepartment([FromBody] GetAllDepartmentRequest getAllDepartmentRequest)
        {
            GetAllDepartment allDepartment = new();
            StatusAllDepartmentResponse statusVehicleresponcse = new();
            try
            {
                if (getAllDepartmentRequest.PageSize == 0) getAllDepartmentRequest.PageSize = 10;
                if (getAllDepartmentRequest.PageNumber == 0) getAllDepartmentRequest.PageNumber = 1;
                if (getAllDepartmentRequest.SearchParam != "") getAllDepartmentRequest.PageNumber = 1;
                statusVehicleresponcse = await _mediator.Send(new GetAllDepartmentQuery(getAllDepartmentRequest));

                if (statusVehicleresponcse != null && statusVehicleresponcse.data.Count > 0)
                {
                    allDepartment.StatusMessage = RespnoseMessage.Record_found;
                    allDepartment.data = statusVehicleresponcse.data;
                    allDepartment.Active = statusVehicleresponcse.Active;
                    allDepartment.Inactive = statusVehicleresponcse.Inactive;
                    allDepartment.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = statusVehicleresponcse.data.TotalCount,
                        PageSize = statusVehicleresponcse.data.PageSize,
                        CurrentPage = statusVehicleresponcse.data.CurrentPage,
                        TotalPages = statusVehicleresponcse.data.TotalPages,
                        HasNext = statusVehicleresponcse.data.HasNext,
                        HasPrevious = statusVehicleresponcse.data.HasPrevious
                    };
                    allDepartment.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {

                    allDepartment.StatusMessage = RespnoseMessage.Record_not_found;
                    allDepartment.StatusCode = (int)HttpStatusCode.OK;
                    allDepartment.data = null;
                }
            }
            catch (Exception ex)
            {
                allDepartment.StatusMessage = RespnoseMessage.Opeartion_Failed;
                allDepartment.StatusCode = (int)HttpStatusCode.NotFound;
                allDepartment.data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allDepartment;
        }

        [HttpGet("getDepartmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DepartmentInfo> getDepartmentById(int id)
        {
            DepartmentInfo res = new DepartmentInfo();
            try
            {
                Department department = await _mediator.Send(new GetByIdDepartmentInfoQuery(id));
                res.StatusCode = (int)HttpStatusCode.OK;
                if (department != null)
                {
                    res.StatusMessage = RespnoseMessage.Record_found;
                }
                else
                {
                    res.StatusMessage = RespnoseMessage.Record_not_found;
                }
                res.data = department!;
            }
            catch (Exception ex)
            {
                res.StatusMessage = RespnoseMessage.Opeartion_Failed;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
                res.data = null;
                Log.Information("error occurred :" + ex.Message);
            }
            return res;
        }

        [HttpDelete("DeleteDepartmentById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DeleteDepartmentRequest> DeleteDepartmentById(int id)
        {
            DeleteDepartmentRequest deleteDepartmentRequest = new();
            var result = await _mediator.Send(new DeleteDepartmentCommand(id));

            if (result)
            {
                deleteDepartmentRequest.StatusCode = 200;
                deleteDepartmentRequest.StatusMessage = RespnoseMessage.VehicelDeleted;
            }
            else
            {
                deleteDepartmentRequest.StatusCode = 400;
                deleteDepartmentRequest.StatusMessage = RespnoseMessage.Not_Deleted;
            }

            return deleteDepartmentRequest;
        }


    }
}
