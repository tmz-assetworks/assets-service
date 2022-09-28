using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using AssetsService.Application.Responses.Assets;
using AssetsService.Application.Queries;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using Serilog;
using Microsoft.AspNetCore.Authorization;

namespace AssetsService.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CountryController> _logger;
        string JSONString = string.Empty;
        public CountryController(IMediator mediator, ILogger<CountryController> logger)
        {
            //_logger = logger;
            _mediator = mediator;
        }




        [HttpGet("getallcountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<AllCountryResponse> GetAllCity()
        {
            AllCountryResponse allCityResponse = new AllCountryResponse();
            try
            {
                List<CountryData> country = await _mediator.Send(new GetAllCountryQuery());
                allCityResponse.StatusMessage = "Record found";
                allCityResponse.StatusCode = (int)HttpStatusCode.OK;
                allCityResponse.data = country;
            }
            catch (Exception ex)
            {
                allCityResponse.StatusMessage = ex.Message.ToString();
                allCityResponse.StatusCode = (int)HttpStatusCode.NotFound;
                allCityResponse.data = null;
                Log.Information("error occurred :" + ex.Message);

            }
            return allCityResponse;
        }

        [HttpGet("getAllStateByCountryId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<StateByCountryIdResponse> GetAllStateByCountryId(long Id)
        {
            StateByCountryIdResponse stateByCountryIdResponse = new StateByCountryIdResponse();
            try
            {
                List<StateData> states = (List<StateData>)await _mediator.Send(new GetStateByCountryIdQuery(Id));

                stateByCountryIdResponse.StatusMessage = "Record found";
                stateByCountryIdResponse.StatusCode = (int)HttpStatusCode.OK;
                stateByCountryIdResponse.data = states;
                ////_logger.LogInformation("Get the all data of State by country Id");
            }
            catch (Exception ex)
            {
                stateByCountryIdResponse.StatusMessage = ex.Message.ToString();
                stateByCountryIdResponse.StatusCode = (int)HttpStatusCode.NotFound;
                stateByCountryIdResponse.data = null;
                ////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return stateByCountryIdResponse;
        }


        [HttpGet("getAllCityByStateId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CityByStateIdResponse> GetAllCityByStateId(long Id)
        {
            CityByStateIdResponse cityByStateIdResponse = new CityByStateIdResponse();
            try
            {
                List<CityData> city = (List<CityData>)await _mediator.Send(new GetCityByStateIdQuery(Id));

                cityByStateIdResponse.StatusMessage = "Record found";
                cityByStateIdResponse.StatusCode = (int)HttpStatusCode.OK;
                cityByStateIdResponse.data = city;
                ////_logger.LogInformation("Get the all data of City by state Id");
            }
            catch (Exception ex)
            {
                cityByStateIdResponse.StatusMessage = ex.Message.ToString();
                cityByStateIdResponse.StatusCode = (int)HttpStatusCode.NotFound;
                cityByStateIdResponse.data = null;
                //////_logger.LogError(ex.ToString());
                Log.Information("error occurred :" + ex.Message);

            }
            return cityByStateIdResponse;


        }
    }
}