using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssetsService.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Microsoft.Extensions.Logging;
using AssetsService.Application.Queries;
using AssetsService.Core.Queries;
using AssetsService.Application.Commands.Assets;
using Microsoft.AspNetCore.Mvc;
using AssetsService.Api.Controllers;

namespace AssetsService.Api.Tests
{

    [TestClass()]
    public class VehicleControllerTest
    {
        private readonly VehicleController _vehicleController;

        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<CableController>> _logger;

        string JSONString = string.Empty;
        public VehicleControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<VehicleController>>();

            _vehicleController = new VehicleController(_mediator.Object, _logger.Object);
            {

            }


        }
        public void GetVehicleByIdTests()
        {


            var vehicleID = new AssetsService.Core.Entities.Vehicle()
            {
                new AssetsService.Core.Entities.Vehicle(){


                //arrange             
                id = 1,
                vin = "QWER",
                licencePlate = "SDF",
                department = "SDF",
                domicileLocation = "DF",
                vehicleMacAddress = "SDF",
                modelYear = 2344,
                make = "WERF",
                model = 1,
                isActive = false,
                createdBy = "SDF",
                createdOn = "2022-08-05T14:01:39.5166667",
                modifiedBy = "ASDF",
                modifiedOn = "2022-08-05T14:01:39.5166667",

                vehicleModelYear = new AssetsService.Core.Entities.VehicleModelYear()
                {
                    id = 1,
                    name = "ASDF",
                    isActive = true,
                    createdBy = "ASDF",
                    createdOn = "2022-08-05T14:01:39.5166667",
                    modifiedBy = "asdfh",
                    
                    modifiedOn = "2022-08-05T14:01:39.5166667"
                },

                VehicleModel = new AssetsService.Core.Entities.VehicleModelYear()
                {
                    id = 1,
                    name = "X1",
                    isActive = true,
                    createdBy = "ASDF",
                    createdOn = "2022-08-05T14:01:39.5166667",
                    modifiedBy = "FGHJ",
                    modifiedOn = "2022-08-05T14:01:39.5166667"
                },

                vehicleMake = new AssetsService.Core.Entities.vehicleMake()
                {
                    id = 1,
                    name = toyota,
                    isActive = true,
                    createdBy = "atul",
                    createdOn = "2022-08-05T14:01:39.5166667",
                    modifiedBy = "JCFHJHF",
                    modifiedOn = "2022-08-05T14:01:39.5166667"
                },
                status = "ACTIVE",

                vehicleSubscriptionPlan = new AssetsService.Core.Entities.VehicleSubscriptionPlan()
                {
                    id = 1,
                    subscriptionPlanName = "abcd",
                    type = "kjh",
                    value = "123",
                    validFrom = "2022-08-05T13:39:11.1533333",
                    validTo = "2022-08-05T13:39:11.1533333",
                    rfidNo = 1,
                    isActive = true,
                    createdBy = "ATUL",
                    createdOn = "2022-08-05T13:39:11.1533333",
                    modifiedBy = "AFGH",
                    modifiedOn = "2022-08-05T13:39:11.1533333"
                },

                vehicleRFID = new AssetsService.Core.Entities.VehicleRFID()
                {
                    id = 1,
                    name = "ASD",
                    isActive = false,
                    createdBy = "ASDF",
                    createdOn = "2022-08-05T14:01:39.5166667",
                    modifiedBy = "KJH",
                    modifiedOn = -"2022-08-05T14:01:39.5166667"
                }
                }

            };

            _mediator.Setup(md => md.Send(It.IsAny<GetByIdVehicleQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleID);

            //Act
            var actionResult = _vehicleController.GetVehicleById(id);

            // Assert 
            Assert.IsNotNull(actionResult);

        }



    }
}


