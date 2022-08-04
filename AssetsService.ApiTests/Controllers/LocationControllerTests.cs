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

namespace AssetsService.Api.Tests
{

    [TestClass()]
    public class LocationControllerTests
    {
        private readonly LocationController _locationController;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<LocationController>> _logger;
        string JSONString = string.Empty;
        public LocationControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<LocationController>>();

            _locationController = new LocationController(_mediator.Object, _logger.Object);
            {

            }
        }

        [TestMethod()]
        public void GetAllLocationTest()
        {
            // Arrange
            var allLocation = new List<AssetsService.Core.Entities.Location>() {
            new AssetsService.Core.Entities.Location()
            {
                 ContactPersonName = "Adam",
                 DepartmentId= 1,
                 Description="Desc",
                 FuelProtectType= "1",
                 LocationAddressId= 1,
                 LocationName= "Noida",
                 LocationNumber= 1,
                 LocationStatus= new Core.Entities.LocationStatus()
                 {
                      Id= 1,
                       LocationStatusName="StatusName",
                       CreatedBy = "John",
                       CreatedOn = DateTime.Now,
                       IsActive = true,
                       ModifiedBy = "Smith",
                       ModifiedOn = DateTime.Now,
                 },
                      LocationStatusId= 1,
                      TimeZone="UTC",
                      TotalCapacity="10",
                      UtilityService="Utility",
                  Department = new Core.Entities.Department()
                  {
                        ContactPersonName="John",
                        Address="Delhi",
                        CreatedBy = "John",
                        CreatedOn = DateTime.Now,
                        IsActive = true,
                        DepartmentName= "Computer",
                        Id= 1,
                        ModifiedBy = "Smith",
                        ModifiedOn = DateTime.Now,
                  },
                        LocationSchedule= new List<Core.Entities.LocationSchedule>()
                       {
                       },
                             GlobalTax="10",
                              LocationAddress= new Core.Entities.LocationAddress()
                              {
                              Id= 1,
                              AddressLine1="Noida",
                              AddressLine2="Delhi",
                              AlternateMobileNumber="23131312",
                              CityId= 1,
                              CityName="Bareilly",
                              CountryId= 1,
                              CountryName="India",
                              CreatedBy = "John",
                              CreatedOn = DateTime.Now,
                              IsActive = true,
                              ModifiedBy = "Smith",
                              ModifiedOn = DateTime.Now,
                              Email="abc@gmail.com",
                              LandlineNumber="4242",
                              Latitude=1,
                              Longitude=1,
                              MobileNumber="07358375",
                              PinCode="243223",
                              StateId=1,
                              StateName="U.P"
                      },

                Id = 1,
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                IsActive = true,

                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
            }
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetAllLocationQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(allLocation);
            //Act
            var actionResult = _locationController.GetAllLocation().Result as AssetsService.Application.Responses.Assets.AllLocationStatusQueryResponse;
            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.StatusCode));
        }

        [TestMethod()]
        public void GetAllLocationNameTest()
        {
            // Arrange
            var allLocation = new List<AssetsService.Core.Entities.Location>() {
            new AssetsService.Core.Entities.Location()
            {
                 ContactPersonName = "Adam",
                 DepartmentId= 1,
                 Description="Desc",
                 FuelProtectType= "1",
                 LocationAddressId= 1,
                 LocationName= "Noida",
                 LocationNumber= 1,
                 LocationStatus= new Core.Entities.LocationStatus()
                 {
                      Id= 1,
                       LocationStatusName="StatusName",
                       CreatedBy = "John",
                       CreatedOn = DateTime.Now,
                       IsActive = true,
                       ModifiedBy = "Smith",
                       ModifiedOn = DateTime.Now,
                 },
                      LocationStatusId= 1,
                      TimeZone="UTC",
                      TotalCapacity="10",
                      UtilityService="Utility",
                Id = 1,
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                IsActive = true,

                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
            }
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetAllLocationQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(allLocation);
            //Act
            var actionResult = _locationController.GetAllLocation().Result as AssetsService.Application.Responses.Assets.AllLocationStatusQueryResponse;

            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.StatusCode));
        }

        [TestMethod()]
        public void GetLocationByIdTest()
        {
            // Arrange
            long id = 1;
            var request = new AssetsService.Core.Queries.GetLocationByIdQuery(id);
            var allLocation = new AssetsService.Core.Entities.Location()
            {
                ContactPersonName = "Adam",
                DepartmentId = 1,
                Description = "Desc",
                FuelProtectType = "1",
                LocationAddressId = 1,
                LocationName = "Noida",
                LocationNumber = 1,
                LocationStatus = new Core.Entities.LocationStatus()
                {
                    Id = 1,
                    LocationStatusName = "StatusName",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                LocationStatusId = 1,
                TimeZone = "UTC",
                TotalCapacity = "10",
                UtilityService = "Utility",
                Department = new Core.Entities.Department()
                {
                    ContactPersonName = "John",
                    Address = "Delhi",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    DepartmentName = "Computer",
                    Id = 1,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                LocationSchedule = new List<Core.Entities.LocationSchedule>()
                {
                },
                GlobalTax = "10",
                LocationAddress = new Core.Entities.LocationAddress()
                {
                    Id = 1,
                    AddressLine1 = "Noida",
                    AddressLine2 = "Delhi",
                    AlternateMobileNumber = "23131312",
                    CityId = 1,
                    CityName = "Bareilly",
                    CountryId = 1,
                    CountryName = "India",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                    Email = "abc@gmail.com",
                    LandlineNumber = "4242",
                    Latitude = 1,
                    Longitude = 1,
                    MobileNumber = "07358375",
                    PinCode = "243223",
                    StateId = 1,
                    StateName = "U.P"
                },

                Id = 1,
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                IsActive = true,

                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetLocationByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(allLocation);
            //Act
            var actionResult = _locationController.GetLocationById(id).Result as AssetsService.Application.Responses.Assets.LocationQueryResponse;

            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.StatusCode));
        }

        [TestMethod()]
        public void CreateLocationTest()
        {
            //Arrange
            AssetsService.Application.Commands.Assets.CreateLocationCommand createLocation = CreateLocationCommandDTO();
            var Dto = new AssetsService.Application.Responses.Assets.LocationResponse()
            {
                Id = 1,
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                IsActive = true,
                UtilityService = "Utility",
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                ContactPersonName = "Adam",
                Description = "Desc",
                FuelProtectType = "Full",
                GlobalTax = "10",
                LocationAddressId = 1,
                LocationName = "Noida",
                LocationNumber = 1,
                LocationStatusId = 1,
                TimeZone = "UTC",
                TotalCapacity = "100",
                department = new Core.Entities.Department()
                {
                    ContactPersonName = "John",
                    Address = "Delhi",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    DepartmentName = "Computer",
                    Id = 1,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                DepartmentId = 1,
                locationAddress = new Core.Entities.LocationAddress()
                {
                    Id = 1,
                    AddressLine1 = "Noida",
                    AddressLine2 = "Delhi",
                    AlternateMobileNumber = "23131312",
                    CityId = 1,
                    CityName = "Bareilly",
                    CountryId = 1,
                    CountryName = "India",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                    Email = "abc@gmail.com",
                    LandlineNumber = "4242",
                    Latitude = 1,
                    Longitude = 1,
                    MobileNumber = "07358375",
                    PinCode = "243223",
                    StateId = 1,
                    StateName = "U.P"
                },
                locationSchedule = new List<Core.Entities.LocationSchedule>()
                {
                },
                locationStatus = new Core.Entities.LocationStatus()
                {
                    Id = 1,
                    LocationStatusName = "StatusName",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                operatorUserMapper = new List<Core.Entities.OperatorUserMapper>()
                {
                }
            };
            _mediator.Setup(md => md.Send(It.IsAny<CreateLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Dto);
            //Act
            var actionresult = _locationController.CreateLocation(createLocation).Result as ActionResult<AssetsService.Application.Responses.Assets.LocationResponse>;
            // Assert 
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult.Result as OkObjectResult).StatusCode);
        }

        [TestMethod()]
        public void DeleteLocationTest()
        {
            //Arrange
            AssetsService.Application.Commands.Assets.DeleteLocationCommand deleteLocation = DeleteLocationCommandDTO();
            var Dto = new AssetsService.Application.Responses.Assets.LocationResponse()
            {
                Id = 1,
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                IsActive = true,
                UtilityService = "Utility",
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                ContactPersonName = "Adam",
                Description = "Desc",
                FuelProtectType = "Full",
                GlobalTax = "10",
                LocationAddressId = 1,
                LocationName = "Noida",
                LocationNumber = 1,
                LocationStatusId = 1,
                TimeZone = "UTC",
                TotalCapacity = "100",
                department = new Core.Entities.Department()
                {
                    ContactPersonName = "John",
                    Address = "Delhi",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    DepartmentName = "Computer",
                    Id = 1,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                DepartmentId = 1,
                locationAddress = new Core.Entities.LocationAddress()
                {
                    Id = 1,
                    AddressLine1 = "Noida",
                    AddressLine2 = "Delhi",
                    AlternateMobileNumber = "23131312",
                    CityId = 1,
                    CityName = "Bareilly",
                    CountryId = 1,
                    CountryName = "India",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                    Email = "abc@gmail.com",
                    LandlineNumber = "4242",
                    Latitude = 1,
                    Longitude = 1,
                    MobileNumber = "07358375",
                    PinCode = "243223",
                    StateId = 1,
                    StateName = "U.P"
                },
                locationSchedule = new List<Core.Entities.LocationSchedule>()
                {
                },
                locationStatus = new Core.Entities.LocationStatus()
                {
                    Id = 1,
                    LocationStatusName = "StatusName",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                operatorUserMapper = new List<Core.Entities.OperatorUserMapper>()
                {
                }
            };
            _mediator.Setup(md => md.Send(It.IsAny<DeleteLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Dto);
            //Act
            var actionresult = _locationController.DeleteLocation(deleteLocation).Result as ActionResult<AssetsService.Application.Responses.Assets.LocationResponse>;
            // Assert 
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult.Result as OkObjectResult).StatusCode);
        }

        [TestMethod()]
        public void UpdateLocationTest()
        {
            //Arrange
            AssetsService.Application.Commands.Assets.UpdateLocationCommand updateLocation = UpdateLocationCommandDTO();
            var Dto = new AssetsService.Application.Responses.Assets.LocationResponse()
            {
                Id = 1,
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                IsActive = true,
                UtilityService = "Utility",
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                ContactPersonName = "Adam",
                Description = "Desc",
                FuelProtectType = "Full",
                GlobalTax = "10",
                LocationAddressId = 1,
                LocationName = "Noida",
                LocationNumber = 1,
                LocationStatusId = 1,
                TimeZone = "UTC",
                TotalCapacity = "100",
                department = new Core.Entities.Department()
                {
                    ContactPersonName = "John",
                    Address = "Delhi",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    DepartmentName = "Computer",
                    Id = 1,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                DepartmentId = 1,
                locationAddress = new Core.Entities.LocationAddress()
                {
                    Id = 1,
                    AddressLine1 = "Noida",
                    AddressLine2 = "Delhi",
                    AlternateMobileNumber = "23131312",
                    CityId = 1,
                    CityName = "Bareilly",
                    CountryId = 1,
                    CountryName = "India",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                    Email = "abc@gmail.com",
                    LandlineNumber = "4242",
                    Latitude = 1,
                    Longitude = 1,
                    MobileNumber = "07358375",
                    PinCode = "243223",
                    StateId = 1,
                    StateName = "U.P"
                },
                locationSchedule = new List<Core.Entities.LocationSchedule>()
                {
                },
                locationStatus = new Core.Entities.LocationStatus()
                {
                    Id = 1,
                    LocationStatusName = "StatusName",
                    CreatedBy = "John",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    ModifiedBy = "Smith",
                    ModifiedOn = DateTime.Now,
                },
                operatorUserMapper = new List<Core.Entities.OperatorUserMapper>()
                {
                }
            };
            _mediator.Setup(md => md.Send(It.IsAny<UpdateLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Dto);
            //Act
            var actionresult = _locationController.UpdateLocation(updateLocation).Result as ActionResult<AssetsService.Application.Responses.Assets.LocationResponse>;
            // Assert 
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult.Result as OkObjectResult).StatusCode);
        }

        [TestMethod()]
        public void GetLocationsDispenserformapTest()
        {
            // Arrange
            List<long> Id = new List<long> { 1 };
            var res = new AssetsService.Core.Response.LocationsDispenserformapResponce()
            {
                StatusCode = 200,
                StatusMessage = "Ok",
                data = new List<Core.Response.LocationsDispenser>()
                {
                    new Core.Response.LocationsDispenser()
                    {
                CityName = "Noida",
                CountryName = "India",
                DispenserId = 1,
                Latitude = 10,
                Longitude = 20,
                locationId = 1,
                LocationName = "Delhi",
                StateName = "U.P",
                status = "Active"
                    },
                }
            };
            _mediator.Setup(md => md.Send(It.IsAny<List<GetLocationsDispenserformapQuery>>(), It.IsAny<CancellationToken>())).ReturnsAsync(getLocationDispenser);
            //Act
            var actionResult = _locationController.GetLocationsDispenserformap(Id).Result as ActionResult<AssetsService.Core.Response.LocationsDispenserformapResponce>;

            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.Result as ObjectResult).StatusCode);
        }

        [TestMethod()]
        public void GetLocationsDispenserDetailsTest()
        {
            // Arrange
            List<long> Id = new List<long> { 1 };
            var res = new AssetsService.Core.Response.LocationsDispenserDetailsResponce()
            {
                StatusCode = 200,
                StatusMessage = "Ok",
                data = new List<Core.Response.LocationsDispenserDetails>()
                {
                    new Core.Response.LocationsDispenserDetails()
                    {
                       Address = "Delhi",
                    Available = "Yes",
                    Connected="Yes",
                    ContactName="John",
                    ContactNo="76766767879",
                    Faulty="Yes",
                    NoofPort="1",
                    DispenserId = 1,
                    locationId = 1,
                    LocationName = "Delhi",
                    status = "Active"
                    },
                }
            };
            _mediator.Setup(md => md.Send(It.IsAny<List<GetLocationsDispenserDetailsQuery>>(), It.IsAny<CancellationToken>())).ReturnsAsync(getLocationDispenser);
            //Act
            var actionResult = _locationController.GetLocationsDispenserDetails(Id).Result as ActionResult<AssetsService.Core.Response.LocationsDispenserDetailsResponce>;
            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.Result as ObjectResult).StatusCode);
        }

        [TestMethod()]
        public void GetDispenserByLocationTest()
        {
            // Arrange
            List<long> Id = new List<long> { 1, 2 };
            var res = new AssetsService.Core.Response.LocationDispenserForLocationResponse()
            {
                StatusCode = 200,
                StatusMessage = "Ok",
                data = new List<Core.Response.LocationDispenserForLocation>()
                {
                    new Core.Response.LocationDispenserForLocation()
                    {
                        NoofPort="1",
                        ChargeBoxId="1",
                        ChargerPort="2",
                        ChargerStatus="3",
                        ConnectorType="Type",
                        ConnnectorType="0",
                        DispenserMake="0",
                        DispenserModel="0",
                        DispenserName="DisName",
                        ProtocolName="PrdouctName",
                        SerialNumber="0",
                        DispenserId = 1,
                        locationId = 1,
                    },
                }
            };
            _mediator.Setup(md => md.Send(It.IsAny<List<GetLocationsDispenserForLocationQuery>>(), It.IsAny<CancellationToken>())).ReturnsAsync(res);
            //Act
            var actionResult = _locationController.GetDispenserByLocation(Id).Result as ActionResult<AssetsService.Core.Response.LocationDispenserForLocationResponse>;
            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.Value.StatusCode));
        }
        private AssetsService.Application.Commands.Assets.CreateLocationCommand CreateLocationCommandDTO()
        {
            return new AssetsService.Application.Commands.Assets.CreateLocationCommand()
            {
                ContactPersonName = "Adam",
                Description = "Desc",
                FuelProtectType = "Full",
                GlobalTax = "10",
                IsActive = true,
                LocationAddressId = 1,
                LocationId = 1,
                LocationName = "Noida",
                LocationNumber = 1,
                LocationStatusId = 1,
                TimeZone = "UTC",
                TotalCapacity = "100",
                UtilityService = "Utility",
                CreatedBy = "test",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "test",
                ModifiedOn = DateTime.UtcNow,
            };
        }
        private AssetsService.Application.Commands.Assets.UpdateLocationCommand UpdateLocationCommandDTO()
        {
            return new AssetsService.Application.Commands.Assets.UpdateLocationCommand()
            {
                Id = 1,
                ContactPersonName = "Adam",
                Description = "Desc",
                FuelProtectType = "Full",
                GlobalTax = "10",
                IsActive = true,
                LocationAddressId = 1,
                LocationId = 1,
                LocationName = "Noida",
                LocationNumber = 1,
                LocationStatusId = 1,
                TimeZone = "UTC",
                TotalCapacity = "100",
                UtilityService = "Utility",
                CreatedBy = "test",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "test",
                ModifiedOn = DateTime.UtcNow,
            };
        }
        private AssetsService.Application.Commands.Assets.DeleteLocationCommand DeleteLocationCommandDTO()
        {
            return new AssetsService.Application.Commands.Assets.DeleteLocationCommand()
            {
                Id = 1,
                IsActive = true
            };
        }
    }
}