using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Dynamic;
using System.Net;

namespace AssetsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AllAssetListController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CableController> _logger;
        public AllAssetListController(IMediator mediator, ILogger<AllAssetListController> logger)
        {
            _mediator = mediator;
           
        }

        [HttpPost("GetCombineAssetList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CombineAssetResponse> GetCombineAssetList([FromBody] CombineAssetRequest CombineAssetRequest)
        {
            CombineAssetResponse re = new CombineAssetResponse();
            try
            {

                if (CombineAssetRequest.PageSize == 0) CombineAssetRequest.PageSize = 10;
                if (CombineAssetRequest.PageNumber == 0) CombineAssetRequest.PageNumber = 1;
                var modems = await _mediator.Send(new GetCombineAssetQuery(CombineAssetRequest));
                if (modems != null && modems.data.Count > 0)
                    re.StatusMessage = "Record found";
                else re.StatusMessage = "Record not found";
                re.StatusCode = (int)HttpStatusCode.OK;
                List<statusData>  statusDatas = new List<statusData>();

                statusDatas.Add(new statusData() { key = "Total Assets", value = modems.data.Count() });
                statusDatas.Add(new statusData() { key = "Pads", value = modems.data.Where(s => s.Type.Equals("Pads")).Count() });
                statusDatas.Add(new statusData() { key = "Power Cabinet", value = modems.data.Where(s => s.Type.Equals("PowerCabinet")).Count() });
                statusDatas.Add(new statusData() { key = "Modem", value = modems.data.Where(s => s.Type.Equals("Modem")).Count() });
                statusDatas.Add(new statusData() { key = "Cables", value = modems.data.Where(s => s.Type.Equals("Cables")).Count() });              
                statusDatas.Add(new statusData() { key = "RFID Readers", value = modems.data.Where(s => s.Type.Equals("RFIDReaders")).Count() });

                  modems.data = modems.data.Where(r => r.Type.ToLower().
                Contains(string.IsNullOrEmpty(CombineAssetRequest.SearchParam.ToLower()) == true ? r.Type.ToLower() : CombineAssetRequest.SearchParam.ToLower())
                || r.AssetId.ToLower().
                Contains(string.IsNullOrEmpty(CombineAssetRequest.SearchParam.ToLower()) == true ? r.AssetId.ToLower() : CombineAssetRequest.SearchParam.ToLower())
                ).OrderByDescending(a => a.ModifiedAt).ToList();

                var dataResult = PagedList<CombineAsset>.ToPagedList(modems.data,
                CombineAssetRequest.PageNumber,
                CombineAssetRequest.PageSize);
                re.statusData = statusDatas;
                re.data = dataResult;
               
                re.paginationResponse = new Core.PagingHelper.PaginationResponse
                {
                    TotalCount = dataResult.TotalCount,
                    PageSize = dataResult.PageSize,
                    CurrentPage = dataResult.CurrentPage,
                    TotalPages = dataResult.TotalPages,
                    HasNext = dataResult.HasNext,
                    HasPrevious = dataResult.HasPrevious
                };
                //_logger.LogInformation("Get all the data of Modem");
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("error occurred :" + ex.Message);
                Log.Information("error occurred :" + ex.Message);
            }


            return re;

        }

        [HttpPut("IsActiveAsset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpandoObject>> IsActiveAsset([FromBody] IsActiveAssetCommand command)
        {
            dynamic expandoObject = new ExpandoObject();
            try
            {
                expandoObject.statusCode = 200;
                if (command.Id < 0)
                {
                    expandoObject.statusMessage = "Please provide Pad Id value.";
                    return expandoObject;
                }
                else
                    if (string.IsNullOrEmpty(command.ModifiedBy))
                {
                    expandoObject.statusMessage = "Please provide ModifiedBy value.";
                    return expandoObject;
                }
                var result = await _mediator.Send(command);

                if (result.Id > 0)
                    expandoObject.statusMessage = "Record status changed successfully.";
                else
                    expandoObject.statusMessage = "Record not found.";

                return expandoObject;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.ToString());
                expandoObject = new ExpandoObject();
                expandoObject.StatusMessage = "Opeartion failed!";
                expandoObject.statusCode = HttpStatusCode.BadRequest;
                Log.Information("error occurred :" + ex.Message);
            }
            return expandoObject;
        }
    }
}
