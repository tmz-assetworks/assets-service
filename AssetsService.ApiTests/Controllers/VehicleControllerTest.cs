using AssetsService.Api.Controllers;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Dynamic;

namespace AssetsService.Api.Tests
{

    [TestClass()]
    public class VehicleControllerTest
    {
        private readonly VehicleController _vehicleController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<VehicleController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public VehicleControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<VehicleController>>();
            _vehicleController = new VehicleController(_mediator.Object, _logger.Object);
            {
            }

        }


        [TestMethod()]
        public void GetVehicleByIdTest()
        {
            // Arrange 
            int VehicleId = 153;
            VehicleDTO vehicleDTOResponse = new VehicleDTO()
            {
                Id = 153,
                VIN = "hr52133",
                LicencePlate = "lp1235",
                Department = "depart5",
                DomicileLocation = "gurugram",
                VehicleMacAddress = "haryana",
                IsActive = true,
                ModifiedOn = DateTime.Now,
                VehicleModelYearid = 11,
                VehicleModelYear = "2012",
                VehicleModelName = "2014",
                VehicleMakeName = "2019",
                vehicleRFIDName = "12345,12345",
                VehicleModelId = 13,
                VehicleMakeId = 13,
                vehicleRFIDIds = new List<VehicleRFIDId>()
            };

            _mediator.Setup(md => md.Send(It.IsAny<GetByIdVehicleQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleDTOResponse);
            var actionResult = _vehicleController.GetVehicleDetailsById(VehicleId).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, ((actionResult) as VehicleDetailsResponse).StatusCode);

        }

        [TestMethod()]
        public void CreateVehicleTest()
        {
            CreateVehicleCommand command = new CreateVehicleCommand()
            {
                Id = 0,
                VIN = "AFbr156ss",
                LicencePlate = "lp1987",
                Department = "34324df",
                DomicileLocation = "34234",
                VehicleMacAddress = "343",
                CreatedBy = "343",
                VehicleModelYearid = 13,
                VehicleModelId = 13,
                VehicleMakeId = 13,
                RfIdCardsAssigneds = new List<RfIdCardsAssigneds>()
                { new RfIdCardsAssigneds(){  Id=0,Name="card1",IsActive=true } },
            };
            CreateVehicleResponse vehicleResponse = new CreateVehicleResponse()
            {
                id = 0,
                VIN = "AFbr15621",
                LicencePlate = "lp1987",
                Department = "automation",
                DomicileLocation = "patna",
                VehicleMacAddress = "vma123",
                CreatedBy = "ak4",
                CreatedOn = DateTime.Now,
                VehicleModelYearid = 13,
                VehicleModelId = 11,
                VehicleMakeId = 13,
                rfids = new List<Rfids>() { new Rfids() { Id = 0, Name = "card1", IsActive = true } },

            };
            _mediator.Setup(md => md.Send(It.IsAny<CreateVehicleCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleResponse);
            var actionResult = _vehicleController.CreateVehicle(command).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, ((actionResult.Value) as CreateCommonResponse).statusCode);
        }

        [TestMethod()]
        public void UpdateVehicleTest()
        {
            UpdateVehicleCommand command = new UpdateVehicleCommand()
            {
                Id = 3,
                VIN = "string",
                LicencePlate = "string",
                Department = "string",
                DomicileLocation = "string",
                VehicleMacAddress = "string",
                ModifiedBy = "string",
                VehicleModelYearid = 13,
                VehicleModelId = 13,
                VehicleMakeId = 13,
                RfIdCardsAssigneds = new List<RfIdCardsAssigned>() { new RfIdCardsAssigned() { Id = 0, Name = "card1", IsActive = true } },

            };
            CreateVehicleResponse vehicleResponse = new CreateVehicleResponse()
            {
                id = 3,
                VIN = "AFbr156",
                LicencePlate = "lp1987",
                Department = "automation",
                DomicileLocation = "patna",
                VehicleMacAddress = "vma123",
                CreatedBy = "ak4",
                CreatedOn = DateTime.Now,
                VehicleModelYearid = 13,
                VehicleModelId = 11,
                VehicleMakeId = 13,
                rfids = new List<Rfids>()
                { new Rfids(){  Id=0,Name="card1",IsActive=true } }
            };
            dynamic expandoObject = new ExpandoObject();
            expandoObject.StatusCode = 200;
            expandoObject.StatusMessage = "Record updated successfully.";

            _mediator.Setup(md => md.Send(It.IsAny<UpdateVehicleCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleResponse);

            var actionResult = _vehicleController.UpdateVehicle(command).Result.Value.FirstOrDefault(c => c.Key.ToLower() == "statuscode").Value;
            if (actionResult != null)
            {
                Assert.AreEqual(200, actionResult);
            }
        }

        [TestMethod()]
        public void IsActiveVehicleTest()
        {
            IsActiveVehicleCommand isActiveCommand = new IsActiveVehicleCommand()
            {
                Id = 3,
                IsActive = true,
                ModifiedBy = "1"
            };
            dynamic expandoObject = new ExpandoObject();
            expandoObject.StatusCode = 200;
            expandoObject.StatusMessage = "Record status changed successfully.";

            VehicleResponse vehicleResponse = new VehicleResponse()
            {
                Id = 3,
                VIN = "AFbr156",
                LicencePlate = "lp1987",
                Department = "automation",
                DomicileLocation = "patna",
                VehicleMacAddress = "vma123",
                CreatedBy = "ak4",
                CreatedOn = DateTime.Now,
                VehicleModelYearid = 13,
                VehicleModelId = 11,
                VehicleMakeId = 13,
            };

            _mediator.Setup(md => md.Send(It.IsAny<IsActiveVehicleCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleResponse);
            var actionResult = _vehicleController.IsActiveVehicleById(isActiveCommand).Result.Where(m => m.Key.ToLower() == "statuscode").FirstOrDefault();
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.Value);
        }

        [TestMethod()]
        public void GetallvehicleListTest()
        {
            GetAllVehicleRequest getAllVehicleRequest = new GetAllVehicleRequest()
            {
                opratorid = "1",
                SearchParam = "",
                PageSize = 10,
                PageNumber = 1,
                OrderBy = "",

            };
            //VehicleDTO vehicledto = new VehicleDTO()
            //{

            //    Id = 1,
            //    VIN = "cvADF",
            //    LicencePlate = "asdfasd",
            //    Department = "asdfsad",
            //    DomicileLocation = "asdfasd",
            //    VehicleMacAddress = "sdfds",
            //    IsActive = false,
            //    ModifiedOn = DateTime.Now,
            //    VehicleModelYearid = 1,
            //    VehicleModelYear = "2022",
            //    VehicleModelName = "2012",
            //    VehicleMakeName = "2223",
            //    vehicleRFIDName = "SAF",
            //    VehicleModelId = 1,
            //    VehicleMakeId = 1,
            //};

            statusData statusDatas = new statusData() { key = "count", value = 1 };

            VehicleListData vehicleListResponse = new VehicleListData()
            {
                Active = 1,
                InActive = 3,
                 //data = new PagedList<VehicleDTO>(),
            };
            VehicleListData vehicleListData = new VehicleListData();
            _mediator.Setup(md => md.Send(It.IsAny<GetVechicleListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(vehicleListResponse);
            var actionResult = _vehicleController.GetVechicleList(getAllVehicleRequest).Result;
            Assert.IsNotNull(actionResult);
        }
    }
}