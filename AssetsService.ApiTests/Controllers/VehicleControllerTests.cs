using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssetsService.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AssetsService.Core.Responses;
using Moq;
using Microsoft.Extensions.Logging;
using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using AssetsService.Application.Commands.Assets;

namespace AssetsService.Api.Tests
{
    [TestClass()]
    public class VehicleControllerTests
    {
        private readonly VehicleControllerTests _vehicleController;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<VehicleController>> _logger;

        public VehicleControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<VehicleController>>();

            _vehicleController = new VehicleController(_mediator.Object, _logger.Object);
            {

            }
        }
        [TestMethod()]
        public async Task GetAllVehicleTest()
        {
            // Arrange
            var vehicleList = new List<AssetsService.Core.Entities.Vehicle>() {
            new AssetsService.Core.Entities.Vehicle()
            {

             Id = 1,
             VIN = "543545",
             LicencePlate = "HighSecurity",
             Department = "Transport",
             DomicileLocation = "Delhi",
             VehicleMacAddress = "PDHR32456GT",
             IsActive = true,
             CreatedBy = "test",
             CreatedOn = DateTime.Now,
             ModifiedBy = "user",
             ModifiedOn = DateTime.Now,
             VehicleModelYear = new AssetsService.Core.Entities.VehicleModelYear(){
                  Id = 1,
                  Name = "",
                  IsActive = true,
                  CreatedBy = "tata",
                  CreatedOn = DateTime.Now,
                  ModifiedBy = "tata",
                  ModifiedOn = DateTime.Now,
              },

             VehicleModel = new AssetsService.Core.Entities.VehicleModel(){
                    Id = 1,
                  Name = "",
                  IsActive = true,
                  CreatedBy = "tata",
                  CreatedOn = DateTime.Now,
                  ModifiedBy = "tata",
                  ModifiedOn = DateTime.Now,


             },

             VehicleMake = new AssetsService.Core.Entities.VehicleMake() {
                  Id = 1,
                  Name = "",
                  IsActive = true,
                  CreatedBy = "tata",
                  CreatedOn = DateTime.Now,
                  ModifiedBy = "tata",
                  ModifiedOn = DateTime.Now,

             },

             VehicleRFID = new AssetsService.Core.Entities.VehicleRFID() {
                  Id = 1,
                  Name = "",
                  IsActive = true,
                  CreatedBy = "tata",
                  CreatedOn = DateTime.Now,
                  ModifiedBy = "tata",
                  ModifiedOn = DateTime.Now,

             },
            }

          };

          _mediator.Setup(md => md.Send(It.IsAny<GetAllVechicleQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(cableList);
            //Act
            var actionResult = _vehicleController.GetAllVehicle().Result as AssetsService.Core.Responses.Vehicles;

            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.StatusCode));
        }
    }
}
