using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AssetsService.Api.Tests
{

    [TestClass()]
    public class ModemControllerTests
    {
        private readonly ModemController _modemController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<ModemController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public ModemControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<ModemController>>();
            _modemController = new ModemController(_mediator.Object, _logger.Object);
            {
            }

        }
        [TestMethod()]
        public void GetModemByIdTest()
        {
            int ModemId = 4;
            ModemDTO modemDTO = new ModemDTO()

            {

                Id = 4,
                AssetId = "atul",
                Carrier = "atul123",
                ImeiNumber = "123456",
                InstallationDate = DateTime.Now,
                IpAddress = "string11",
                MakeMasterId = 1,
                ModelId = 4,
                MakeMasterName = "Make 1",
                ModelName = "Model",
                SerialNumber = "string22",
                SimNumber = "875566",
                StatusId = 2,
                StatusName = "DeCommissioned",
                ModemTypeId = 1,
                ModemTypeName = "modemtype1",
                WarrantyDuration = 12,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
                LocationId = 1,
                IsActive = true,
                LocationName = "Noida",
                ModifiedAt = DateTime.Now,
            };

            _mediator.Setup(md => md.Send(It.IsAny<GetByIdModemsQuery>(), It.IsAny<CancellationToken>()));
            var actionResult = _modemController.GetModemById(ModemId).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult, 200);
        }


        [TestMethod()]
        public void CreateModemTest()
        {


            CreateModemCommand createModemCommand = new CreateModemCommand()
            {

                AssetId = "asset123",
                Carrier = "carrier12",
                CreatedBy = "atul",
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 4,
                SimNumber = "875566",
                SerialNumber = "sn00765",
                StatusId = 2,
                ModemTypeId = 1,
                LocationId = 1,
                ImeiNumber = "875566",
                IpAddress = "12345.112",
                WarrantyDuration = 11,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
                IsActive = true

            };
            Modem modem = new Modem()
            {
                Id = 0,
                AssetId = "asset123",
                Carrier = "carrier12",
                CreatedBy = "atul",
                CreatedOn = DateTime.Now,
                ImeiNumber = "875566",
                InstallationDate = DateTime.Now,
                IpAddress = "12345.112",
                MakeMasterId = 1,
                ModelId = 4,
                ModifiedBy = "atul",
                ModifiedOn = DateTime.Now,
                SerialNumber = "sn00765",
                SimNumber = "875566",
                StatusId = 2,
                LocationId = 1,
                ModemTypeId = 1,
                WarrantyDuration = 11,
                WarrantyStartDate = DateTime.Now,
                IsActive = true
            };

            _mediator.Setup(md => md.Send(It.IsAny<CreateModemCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(modem);
            var actionResult = _modemController.CreateModem(createModemCommand).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult, 200);
        }
        [TestMethod()]
        public void UpdateModemTest()
        {
            UpdateModemCommand updateModemCommand = new UpdateModemCommand()
            {
                Id = 5,
                ModifiedBy = "atul",
                AssetId = "Modem",
                Carrier = "UpdateModem",
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 4,
                SimNumber = "875566",
                SerialNumber = "serial1234",
                StatusId = 1,
                ModemTypeId = 1,
                LocationId = 1,
                ImeiNumber = "875566",
                IpAddress = "string",
                WarrantyDuration = 0,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
                IsActive = true


            };
            Modem modem = new Modem()
            {
                Id = 0,
                AssetId = "asset123",
                Carrier = "carrier12",
                CreatedBy = "atul",
                CreatedOn = DateTime.Now,
                ImeiNumber = "875566",
                InstallationDate = DateTime.Now,
                IpAddress = "12345.112",
                MakeMasterId = 1,
                ModelId = 4,
                ModifiedBy = "atul",
                ModifiedOn = DateTime.Now,
                SerialNumber = "sn00765",
                SimNumber = "875566",
                StatusId = 1,
                LocationId = 1,
                ModemTypeId = 1,
                WarrantyDuration = 11,
                WarrantyStartDate = DateTime.Now,
                IsActive = true
            };
            

            _mediator.Setup(md => md.Send(It.IsAny<UpdateModemCommand>(), It.IsAny<CancellationToken>()));

            var actionResult = _modemController.UpdateModem(updateModemCommand).Result.Value.FirstOrDefault(c => c.Key.ToLower() == "statuscode").Value;
            if (actionResult != null)
            {
                Assert.AreEqual(200, actionResult);
            }

        }

        public void GetAllModem()
        {
            ModemRequest modemRequest = new ModemRequest()
            {
                SearchParam = "",
                PageSize = 10,
                PageNumber = 1,
                OrderBy = "",

            };

            _mediator.Setup(md => md.Send(It.IsAny<GetAllModemQuery>(), It.IsAny<CancellationToken>()));
            var actionResult = _modemController.GetAllModem(modemRequest).Result;
            Assert.IsNotNull(actionResult);


        }


    }
}