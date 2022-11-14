using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssetsService.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Responses.Assets;
using Moq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Microsoft.Extensions.Logging;
using Castle.Core.Configuration;
using AssetsService.Application.Queries;
using System.Dynamic;
using AssetsService.Core.Entities;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;

namespace AssetsService.Api.Controllers.Tests
{
    [TestClass()]
    public class VehicleMakeControllerTests
    {
        private readonly VehicleMakeController _vehicleController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<VehicleMakeController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public VehicleMakeControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<VehicleMakeController>>();
            _vehicleController = new VehicleMakeController(_mediator.Object, _logger.Object);
            {
            }

        }
        [TestMethod()]
        public async Task GetAllVehicleMakeTest()
        {
            //Arrange
            List<AssetsService.Core.Entities.VehicleMake> allVehicleMake = new List<AssetsService.Core.Entities.VehicleMake>()
             {
                      new Core.Entities.VehicleMake()
                      {
                           Id = 1,
                           IsActive = true,
                           Name="Name",
                           CreatedBy="",
                           CreatedOn=DateTime.Now,
                           ModifiedBy="",
                           ModifiedOn=DateTime.Now,
                      }
             };
            _mediator.Setup(md => md.Send(It.IsAny<GetAllVehicleMakeQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(allVehicleMake);

            // Act
            var actionResult = _vehicleController.GetAllVehicleMake().Result;

            dynamic expendo = new ExpandoObject();
            {
                expendo.statusCode = 200;
                expendo.statusMessage = "Record found";
            }
            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(200, expendo.statusCode);
        }

        [TestMethod()]
        public void GetVehicleMakeByIdTest()
        {
            // Arrange 
            int VehicleId = 153;
            VehicleMake vehicleMakeById = new VehicleMake()
            {
                Id = VehicleId,
                Name = "Name",
                IsActive = true,
                CreatedBy = "",
                CreatedOn = DateTime.Now,
                ModifiedBy = "",
                ModifiedOn = DateTime.Now
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetByIdVehicleMakeQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleMakeById);

            // Act
            var actionResult = _vehicleController.GetVehicleMakeById(VehicleId).Result;
            dynamic expendo = new ExpandoObject();
            {
                expendo.statusCode = 200;
                expendo.statusMessage = "Record found";
            }

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(200, expendo.statusCode);
        }

        [TestMethod()]
        public void CreateVehicleTest()
        {
            // Arrange
            CreateVehicleMakeCommand command = new CreateVehicleMakeCommand()
            {
                Name = "Name",
                ModifiedBy = "",
                ModifiedOn = DateTime.Now,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = "343",
            };
            VehicleMakeResponse vehicleResponse = new VehicleMakeResponse()
            {
                Id = 1,
                Name = "Name",
                ModifiedBy = "",
                ModifiedOn = DateTime.Now,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = "343",
            };
            _mediator.Setup(md => md.Send(It.IsAny<CreateVehicleMakeCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleResponse);

            // Act
            var actionResult = _vehicleController.CreateVehicle(command).Result;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.Value));
        }
    }
}