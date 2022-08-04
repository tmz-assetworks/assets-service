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

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispenserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DispenserController> _logger;
        string JSONString = string.Empty;
        public DispenserController(IMediator mediator, ILogger<DispenserController> logger)
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
        //         _logger.LogError(ex.ToString());

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
                List<AssetsService.Core.Entities.Dispenser> dispenser = await _mediator.Send(new GetAllDispenserQuery());
              // List<DispenserStatusData> dispenserdata = dispenser.Select(x => new DispenserStatusData { Id = x.Id, ChargeBoxId = x.ChargeBoxId, DispenserStatus = x.DispenserStatus.DispenserStatusName }).ToList();
                //List<DispenserResponse>dispenserdata = new
                allDispenserQueryResponse.StatusMessage = "Record found";
                allDispenserQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                allDispenserQueryResponse.data = dispenser;
                _logger.LogInformation("Get all Dispenser data");
            }
            catch (Exception ex)
            {
                allDispenserQueryResponse.StatusMessage = ex.Message.ToString();
                allDispenserQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                allDispenserQueryResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return allDispenserQueryResponse;
        }



        [HttpGet("getdispenserbyid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserQueryResponse> GetDispenserById(long Id)
        {
            DispenserQueryResponse dispenserQueryResponse = new DispenserQueryResponse();
            try
            {
                AssetsService.Core.Entities.Dispenser dispenser = await _mediator.Send(new GetDispenserByIdQuery(Id));

                dispenserQueryResponse.StatusMessage = "Record found";
                dispenserQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                dispenserQueryResponse.data = new List<Dispenser>();
                dispenserQueryResponse.data.Add(dispenser);

            }
            catch (Exception ex)
            {
                dispenserQueryResponse.StatusMessage = ex.Message.ToString();
                dispenserQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                dispenserQueryResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return dispenserQueryResponse;

            //try
            //{
            //    Dispenser dispenser = await _mediator.Send(new GetDispenserByIdQuery(Id));
            //    return getjson(dispenser);
            //}
            //catch (Exception ex)
            //{
            //    JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
            //    //_logger.LogError(ex.ToString());
            //}
            //return JSONString;

        }

        [HttpGet("getdispenserbylocationid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserByLocationQueryResponse> getDispenserByLocationId(long Id)
        {
            DispenserByLocationQueryResponse dispenserByLocationQueryResponse = new DispenserByLocationQueryResponse();
            try
            {
                List<AssetsService.Core.Responses.Assets.DispenserByLocationIdResponse> dispenser = await _mediator.Send(new GetDispenserByLocationIdQuery(Id));

                dispenserByLocationQueryResponse.StatusMessage = "Record found";
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                dispenserByLocationQueryResponse.data = dispenser;
                _logger.LogInformation("Get the all data of Dispenser location by Id");
            }
            catch (Exception ex)
            {
                dispenserByLocationQueryResponse.StatusMessage = ex.Message.ToString();
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                dispenserByLocationQueryResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return dispenserByLocationQueryResponse;
        }


        [HttpGet("getdispenserbychargeboxid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetDispenserByChargeBoxId(string ChargeBoxId)
        {
            try
            {
                Dispenser dispenser = await _mediator.Send(new GetDispenserByChargeBoxIdQuery(ChargeBoxId));
                _logger.LogInformation("Get the data of Dispenser by Id");
                return getjson(dispenser);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());
            }
            return JSONString;

        }

        [HttpGet("getdispenserbystationid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> GetDispenserByStationId(long StationId)
        {
            try
            {
                Dispenser dispenser = await _mediator.Send(new GetDispenserByStationIdQuery(StationId));
                _logger.LogInformation("Get the Dispenser data by Station Id");
                return getjson(dispenser);
            }
            catch (Exception ex)
            {
                JSONString = "{\n  \"data\" : " + null + ",  \"StatusMessage\" : " + ex.Message.ToString() + ",\n  \"StatusCode\" : " + (int)HttpStatusCode.NotFound + " \n}";
                _logger.LogError(ex.ToString());
            }
            return JSONString;
        }

        [HttpDelete("deletedispenser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DispenserResponse>> Deletedispenser([FromBody] DeleteDispenserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Dispenser data deleted successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Dispenser not Delete "
                };
            }
        }

        [HttpPost("createdispenser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DispenserResponse>> CreateDispenser([FromBody] CreateDispenserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("All Dispenser data saved successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Dispenser not Created "
                };
            }
        }

        [HttpPut("updatedispenser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DispenserResponse>> UpdateDispenser([FromBody] UpdateDispenserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("All Dispenser data updated successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ContentResult()
                {
                    ContentType = "Exception",
                    StatusCode = 404,
                    Content = "Dispenser not Update "
                };
            }
        }
        [HttpPost("GetDispenserByLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DispenserByLocationsQueryResponse> GetDispenserByLocations([FromBody] DispenserByLocations objdisp)
        {
            DispenserByLocationsQueryResponse dispenserByLocationQueryResponse = new DispenserByLocationsQueryResponse();
            try
            {
                List<DispenserByLocationsResponse> dispenser = (List<DispenserByLocationsResponse>) await _mediator.Send(new GetDispenserByLocationsQuery(objdisp.LocationIds));

                
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.OK;
                if (dispenser != null && dispenser.Count > 0)
                {
                    dispenserByLocationQueryResponse.data = dispenser;
                    dispenserByLocationQueryResponse.StatusMessage = "Record found";
                }
                else
                {
                    dispenserByLocationQueryResponse.data = null;
                    dispenserByLocationQueryResponse.StatusMessage = "Record not found";
                }
                _logger.LogInformation("Get the all data of Dispenser location by Id");
            }
            catch (Exception ex)
            {
                dispenserByLocationQueryResponse.StatusMessage = ex.Message.ToString();
                dispenserByLocationQueryResponse.StatusCode = (int)HttpStatusCode.NotFound;
                dispenserByLocationQueryResponse.data = null;
                _logger.LogError(ex.ToString());

            }
            return dispenserByLocationQueryResponse;
        }
    }
}

