

using System.Dynamic;
using AssetsService.Api.Controllers;
using AssetsService.Application.Commands.Assets;
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
    public class PowerCabinetControllerTest
    {
        private readonly PowerCabinetController _powerCabinetController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<PowerCabinetController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public PowerCabinetControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<PowerCabinetController>>();
            _powerCabinetController = new PowerCabinetController(_mediator.Object, _logger.Object);
            {
            }

        }


        [TestMethod()]
        public void GetPowerCabinetByIdTest()
        {
            // Arrange 
            int PowerCabinetId = 6;
            GetPowerCabinetResponse getPowerCabinetResponse = new GetPowerCabinetResponse()
            {
                Id = 6,
                AssetId = "Power Cabinet",
                BreakerRating = 1,
                CreatedBy = "2e8687a7-ab66-4637-83be-9ccc3b66e876",
                CreatedOn = DateTime.Now,
                DcPortQuantityRating = 1,
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                MakeMasterName = "Make 1",
                ModelId = 4,
                ModelName = "Model",
                ModifiedBy = "2e8687a7-ab66-4637-83be-9ccc3b66e876",
                ModifiedOn = DateTime.Now,
                PeakCurrent = 1,
                SerialNumber = "InDsss",
                ServiceVolts = 1,
                StatusId = 1,
                StatusName = "Commissioned",
                IsActive = true,
                WarrantyDuration = 7,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
                LocationId = 4,
                LocationName = "New York"


            };

            _mediator.Setup(md => md.Send(It.IsAny<GetPowerCabinetByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(getPowerCabinetResponse);
            var actionResult = _powerCabinetController.GetPowerCabinetById(PowerCabinetId).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult, 200);

        }


        [TestMethod()]
        public void CreatePowerCabinetTest()
        {


            CreatePowerCabinetCommand createPowerCabinetCommand = new CreatePowerCabinetCommand()
            {

                AssetId = "string112",
                BreakerRating = 123,
                CreatedBy = "atul",
                DcPortQuantityRating = 152,
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 1,
                PeakCurrent = 123,
                SerialNumber = "msn123456",
                ServiceVolts = 123,
                IsActive = true,
                StatusId = 1,
                LocationId = 4,
                WarrantyDuration = 12,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now

            };
            PowerCabinetResponse powerCabinetResponse = new PowerCabinetResponse()
            {

                Id = 0,
                AssetId = "string112",
                BreakerRating = 123,
                CreatedBy = "atul",
                CreatedOn = DateTime.Now,
                DcPortQuantityRating = 152,
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "atul",
                ModifiedOn = DateTime.Now,
                PeakCurrent = 123,
                SerialNumber = "msn123456",
                ServiceVolts = 123,
                StatusId = 1,
                IsActive = true,
                WarrantyDuration = 12,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now

            };
            _mediator.Setup(md => md.Send(It.IsAny<CreatePowerCabinetCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(powerCabinetResponse);
            var actionResult = _powerCabinetController.CreatePowerCabinet(createPowerCabinetCommand).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult, 200);
        }


        [TestMethod]
        public void UpdatePowerCabinetController()
        {
            UpdatePowerCabinetCommand updatePowerCabinetCommand = new UpdatePowerCabinetCommand()
            {
                Id =15,
                AssetId = "string112",
                BreakerRating = 12,
                DcPortQuantityRating = 12,
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 1,
                PeakCurrent = 1,
                SerialNumber = "string07",
                ServiceVolts = 1123,
                IsActive = true,
                StatusId = 1,
                LocationId = 1,
                WarrantyDuration = 12,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now
            };
            PowerCabinetResponse powerCabinetResponse = new PowerCabinetResponse()
            {

               Id =15,
                AssetId = "string112",
                BreakerRating = 12,
                DcPortQuantityRating = 12,
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 1,
                PeakCurrent = 1,
                SerialNumber = "string07",
                ServiceVolts = 1123,
                IsActive = true,
                StatusId = 1,
                WarrantyDuration = 12,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now

            };
              dynamic expandoObject = new ExpandoObject();
            expandoObject.StatusCode = 200;
            expandoObject.StatusMessage = "Record updated successfully.";

            _mediator.Setup(md => md.Send(It.IsAny<UpdatePowerCabinetCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(powerCabinetResponse);

            var actionResult = _powerCabinetController.UpdatePowerCabinet(updatePowerCabinetCommand).Result.Value.FirstOrDefault(c => c.Key.ToLower() == "statuscode").Value;
            if (actionResult != null)
            {
                Assert.AreEqual(200, actionResult);
            }

        }

    }

}

