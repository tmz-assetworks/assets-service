

using System.Dynamic;
using AssetsService.Api.Controllers;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets.Pad;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Queries;
using AssetsService.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AssetsService.Api.Tests
{

    [TestClass()]
    public class PadControllerTest
    {
        private readonly PadController _padController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<PadController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public PadControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<PadController>>();
            _padController = new PadController(_mediator.Object, _logger.Object);
            {
            }

        }

        [TestMethod()]
        public void CreatePadTest()
        {
            CreatePadCommand createPadCommand = new CreatePadCommand()
            {
                SerialNumber = "Serial No 1",
                AssetId = "Asset 1",
                CreatedBy = "1",
                InstallationDate = DateTime.Now,
                IsActive = true,
                PadName = "Pad  1",
                StatusId = 1,
                LocationId = 1
            };

            dynamic expandoObject = new ExpandoObject();
            expandoObject.StatusCode = 200;
            expandoObject.StatusMessage = "Record updated successfully.";
            PadResponse padResponse = new PadResponse()
            {

            };
            _mediator.Setup(md => md.Send(It.IsAny<CreatePadCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(padResponse);
            var actionResult = _padController.CreatePad(createPadCommand).Result.Value.FirstOrDefault(c => c.Key.ToLower() == "statuscode").Value;
            if (actionResult != null)
            {
                Assert.AreEqual(200, actionResult);
            }
        }


        [TestMethod()]
        public void UpdatePadTest()
        {
            UpdatePadCommand updatepadcommand = new UpdatePadCommand()
            {
                SerialNumber = "Serial No 1",
                AssetId = "Asset 1",
                ModifiedBy = "1",
                InstallationDate = DateTime.Now,
                IsActive = true,
                PadName = "Pad  1",
                StatusId = 1,
                LocationId = 1
            };

            dynamic expandoObject = new ExpandoObject();
            expandoObject.StatusCode = 200;
            expandoObject.StatusMessage = "Record updated successfully.";
            PadResponse padResponse = new PadResponse()
            {

            };
            _mediator.Setup(md => md.Send(It.IsAny<CreatePadCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(padResponse);
            var data = _padController.UpdatePad(updatepadcommand).Result;
            var actionResult = _padController.UpdatePad(updatepadcommand).Result.Value.FirstOrDefault(c => c.Key.ToLower() == "statuscode").Value;
            if (actionResult != null)
            {
                Assert.AreEqual(200, actionResult);
            }
        }

        [TestMethod()]
        public void GetPadByIdTest()
        {
            // Arrange 
            int PowerCabinetId = 6;
            GetPadResponse getpadresponse = new GetPadResponse()
            {
                Id = 1,
                AssetId = "Asset 1",
                SerialNumber = "Serial No",
                CreatedBy = "1",
                CreatedOn = DateTime.Now,
                InstallationDate = DateTime.Now,
                IsActive = true,
                ModifiedBy = "1",
                ModifiedOn = DateTime.Now,
                PadName = "Pad 1",
                StatusId = 1,
                StatusName = "Availalbe",
                LocationId = 1,
                LocationName = "Delhi",
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetByIdPadQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(getpadresponse);
            var actionResult = _padController.GetPadById(PowerCabinetId).Result;
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(actionResult.Value.StatusCode, 200);
        }


        [TestMethod()]
        public void IsActivePadTest()
        {
            IsActivePadCommand isActiveCommand = new IsActivePadCommand()
            {
                Id = 1,
                IsActive = true,
                ModifiedBy = "1"
            };
            PadResponse rFIDReader = new PadResponse()
            {
                Id = 1,
                AssetId = "Asset 1",
                CreatedBy = "1",
                CreatedOn = DateTime.Now,
                InstallationDate = DateTime.Now,
                IsActive = true,
                ModifiedBy = "1",
                ModifiedOn = DateTime.Now,
                PadName = "Pad 10",
                StatusId = 1,
                LocationId = 1
            };

            _mediator.Setup(md => md.Send(It.IsAny<IsActivePadCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(rFIDReader);
            var actionResult = _padController.IsActivePad(isActiveCommand).Result.Value.FirstOrDefault(c => c.Key.ToLower() == "statuscode").Value;;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult));
        }

        [TestMethod()]
        public void GetAllPad()
        {
            // Arrange 
            int PowerCabinetId = 6;

    //        AllPad allPad = new AllPad()
    //        {

    //            StatusCode = 200,
    //            StatusMessage = "Record found.",
    //            data = new List<GetPadResponse>
    //            {
    //                new GetPadResponse()
    //                {
    //                    Id                  =1,
    //                    AssetId             ="Asset 1",
    //                    SerialNumber        ="Serial No",
    //                    CreatedBy           ="1",
    //                    CreatedOn           = DateTime.Now,
    //                    InstallationDate    = DateTime.Now,
    //                    IsActive            =true,
    //                    ModifiedBy          ="1",
    //                    ModifiedOn          = DateTime.Now,
    //                    PadName             = "PadName 1",
    //                    StatusId            =1,
    //                    StatusName          ="Available",
    //                    LocationId          = 3,
    //                    LocationName        ="Delh1",
    //}
    //            }

    //        };

          //  _mediator.Setup(md => md.Send(It.IsAny<GetByIdPadQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(getpadresponse);
            var actionResult = _padController.GetPadById(PowerCabinetId).Result;
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(actionResult.Value.StatusCode, 200);
        }

    }
}

