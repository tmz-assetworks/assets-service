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
using System.Net;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OwningDepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OwningDepartmentsController> _logger;

        public OwningDepartmentsController(
            IMediator mediator,
            ILogger<OwningDepartmentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Create / Update Common Handler

        private async Task<ActionResult<CreateCommonResponse>> HandleDepartmentCommand<TCommand>(TCommand command)
            where TCommand : class
        {
            var response = new CreateCommonResponse();

            try
            {
                var departmentNameProperty = command!.GetType().GetProperty("DepartmentName");
                var departmentName = departmentNameProperty?.GetValue(command)?.ToString();

                if (string.IsNullOrWhiteSpace(departmentName))
                {
                    response.statusMessage = "Please provide Department Name";
                    response.statusCode = StatusCodes.Status400BadRequest;
                    return response;
                }

                if (!ModelState.IsValid)
                {
                    response.statusMessage = string.Join(" | ",
                        ModelState.Values
                                  .SelectMany(v => v.Errors)
                                  .Select(e => e.ErrorMessage));
                    response.statusCode = StatusCodes.Status400BadRequest;
                    return response;
                }

                var result = await _mediator.Send(command);

                if (result != null)
                {
                    response.Id = (long)(result.GetType().GetProperty("Id")?.GetValue(result))!;
                    response.statusMessage = RespnoseMessage.Record_Save_Successfully;
                    response.statusCode = StatusCodes.Status200OK;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing department command");
                response.statusMessage = RespnoseMessage.Opeartion_Failed;
                response.statusCode = StatusCodes.Status500InternalServerError;
            }

            return response;
        }

        #endregion

        [HttpPost("CreateDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCommonResponse>> CreateDepartment(
            [FromBody] CreateDepartmentCommand command)
        {
            return await HandleDepartmentCommand(command);
        }

        [HttpPut("UpdateDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCommonResponse>> UpdateDepartment(
            [FromBody] UpdateDepartmentCommand command)
        {
            return await HandleDepartmentCommand(command);
        }

        [HttpPost("GetAllDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllDepartment>> GetAllDepartment( [FromBody] GetAllDepartmentRequest getAllDepartmentRequest)
        {
            var response = new GetAllDepartment();

            try
            {
                getAllDepartmentRequest.PageSize = getAllDepartmentRequest.PageSize == 0 ? 10 : getAllDepartmentRequest.PageSize;
                getAllDepartmentRequest.PageNumber = getAllDepartmentRequest.PageNumber == 0 ? 1 : getAllDepartmentRequest.PageNumber;

                if (!string.IsNullOrWhiteSpace(getAllDepartmentRequest.SearchParam))
                {
                    getAllDepartmentRequest.PageNumber = 1;
                }

                var result = await _mediator.Send(new GetAllDepartmentQuery(getAllDepartmentRequest));

                if (result?.data?.Count > 0)
                {
                    response.StatusMessage = RespnoseMessage.Record_found;
                    response.data = result.data;
                    response.Active = result.Active;
                    response.Inactive = result.Inactive;
                    response.paginationResponse = new Core.PagingHelper.PaginationResponse
                    {
                        TotalCount = result.data.TotalCount,
                        PageSize = result.data.PageSize,
                        CurrentPage = result.data.CurrentPage,
                        TotalPages = result.data.TotalPages,
                        HasNext = result.data.HasNext,
                        HasPrevious = result.data.HasPrevious
                    };
                    response.StatusCode = StatusCodes.Status200OK;
                }
                else
                {
                    response.StatusMessage = RespnoseMessage.Record_not_found;
                    response.StatusCode = StatusCodes.Status200OK;
                    response.data = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching departments");
                response.StatusMessage = RespnoseMessage.Opeartion_Failed;
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.data = null;
            }

            return response;
        }

        [HttpGet("getDepartmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DepartmentInfo>> GetDepartmentById(int id)
        {
            var response = new DepartmentInfo();

            try
            {
                var department = await _mediator.Send(new GetByIdDepartmentInfoQuery(id));

                response.StatusCode = StatusCodes.Status200OK;
                response.StatusMessage = department != null
                    ? RespnoseMessage.Record_found
                    : RespnoseMessage.Record_not_found;

                response.data = department;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching department by id");
                response.StatusMessage = RespnoseMessage.Opeartion_Failed;
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.data = null;
            }

            return response;
        }

        [HttpDelete("DeleteDepartmentById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DeleteDepartmentRequest>> DeleteDepartmentById(int id)
        {
            var response = new DeleteDepartmentRequest();

            var result = await _mediator.Send(new DeleteDepartmentCommand(id));

            response.StatusCode = result
                ? StatusCodes.Status200OK
                : StatusCodes.Status400BadRequest;

            response.StatusMessage = result
                ? RespnoseMessage.VehicelDeleted
                : RespnoseMessage.Not_Deleted;

            return response;
        }
    }
}