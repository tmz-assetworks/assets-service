using AssetsService.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediatR;
using Moq;
using Microsoft.Extensions.Logging;
using AssetsService.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using System.Dynamic;
using AssetsService.Application.Queries;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using Microsoft.AspNetCore.Mvc;

namespace AssetsService.Api.Tests
{
    [TestClass()]
    public class DispenserControllerTests
    {

        private readonly DispenserController _dispenserController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<TokenBase> _token;
        private readonly Mock<ILogger<DispenserController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public DispenserControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _token = new Mock<TokenBase>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<DispenserController>>();
            _dispenserController = new DispenserController(_mediator.Object, _logger.Object, _token.Object);
            {
            }

        }
        [TestMethod()]
        public async Task CreateDispenserTest()
        {
            //Arrange
            CreateDispenserCommand command = new CreateDispenserCommand()
            {
                AssetId = "New RFID 22 0",
                CableId = 1,
                LocationId = 1,
                MakeName = "MakeTest",
                ModelName = "ModelTest",
                CreatedBy = "1",
                ChargeBoxId = "",
                RFIdReaderId = 1,
                EndPointUrl = "",
                FirmwareVersion = "",
                HardwareSerialNumber = "1",
                IsActive = true,
                MeterType = "",
                ModemId = 1,
                PadId = 1,
                PingSchedule = "",
                PowerCabinetId = 1,
                FleetStation= true,
                ProtocolName = "",
                ReadingSchedule = "",
                PortCommand = new List<PortCommand>()
                 {
                   new PortCommand()
                   {
                        Id = 1,
                        ConnectorId=1,
                        ConnectorType=1,
                        IncrementalPower=100,
                        MaxPower=100,
                        MinPower=100,
                        PlugTypeId=1,
                        PortName="",
                        IsActive=true,
                        Power=500
                   }
                 }
            };
            DispenserResponse dispenser = new DispenserResponse()
            {
                Id = 1,
                AssetId = "New RFID 22 0",
                SerialNumber = "RRMOINr43",
                LocationId = 1,
                MakeMasterId = 1,
                ModelId = 1,
                CreatedBy = "1",
                ChargeBoxId = "",
                CableId = 1,
                RFIdReaderId = 1,
                DispenserStatusId = 1,
                EndPointUrl = "",
                FirmwareVersion = "",
                HardwareSerialNumber = "1",
                IsActive = true,
                IsAutomatic = true,
                MeterType = "",
                ModemId = 1,
                MultiplePorts = true,
                PadId = 1,
                PingSchedule = "",
                PowerCabinetId = 1,
                PrivateStation = true,
                ProtocolName = "",
                ReadingSchedule = "",
                ModifiedBy = "1",
            };
            _mediator.Setup(md => md.Send(It.IsAny<CreateDispenserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenser);
            // Act
            var actionResult = _dispenserController.CreateDispenser(command).Result;
            dynamic expendo = new ExpandoObject();
            {
                expendo.statusCode = 200;
                expendo.statusMessage = "Recoed saved successfully";
                expendo.Id = dispenser.Id;
            }
            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(200, expendo.statusCode);
        }

        [TestMethod()]
        public void UpdateDispenserTest()
        {
            //Arrange
            UpdateDispenserCommand command = new UpdateDispenserCommand()
            {
                Id = 1,
                CableId = 1,
                AssetId = "New RFID 22 0",
                LocationId = 1,
                MakeName = "Model",
                ModelName = "Make",
                ModifiedBy = "1",
                ChargeBoxId = "",
                RFIdReaderId = 1,
                EndPointUrl = "",
                FirmwareVersion = "",
                HardwareSerialNumber = "1",
                IsActive = true,
                MeterType = "",
                ModemId = 1,
                PadId = 1,
                PingSchedule = "",
                PowerCabinetId = 1,
                FleetStation = true,
                ProtocolName = "",
                ReadingSchedule = "",
                UpdatePortCommand = new List<UpdatePortCommand>()
                 {
                   new UpdatePortCommand()
                   {
                        Id=1,
                        ConnectorId=1,
                        ConnectorType=1,
                        IncrementalPower=100,
                        MaxPower=100,
                        MinPower=100,
                        PlugTypeId=1,
                        PortName="",
                        IsActive=true,
                        Power=500
                   }
                 }
            };
            DispenserResponse dispenser = new DispenserResponse()
            {
                Id = 1,
                AssetId = "New RFID 22 0",
                SerialNumber = "RRMOINr43",
                LocationId = 1,
                MakeMasterId = 1,
                ModelId = 1,
                CreatedBy = "1",
                CableId = 1,
                ChargeBoxId = "",
                RFIdReaderId = 1,
                DispenserStatusId = 1,
                EndPointUrl = "",
                FirmwareVersion = "",
                HardwareSerialNumber = "1",
                IsActive = true,
                IsAutomatic = true,
                MeterType = "",
                ModemId = 1,
                MultiplePorts = true,
                PadId = 1,
                PingSchedule = "",
                PowerCabinetId = 1,
                PrivateStation = true,
                ProtocolName = "",
                ReadingSchedule = "",
                ModifiedBy = "1",
            };
            _mediator.Setup(md => md.Send(It.IsAny<UpdateDispenserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenser);

            // Act
            var actionResult = _dispenserController.UpdateDispenser(command).Result;
            dynamic expendo = new ExpandoObject();
            {
                expendo.statusCode = 200;
                expendo.statusMessage = "Recoed updated successfully";
                expendo.Id = dispenser.Id;
            }
            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(200, expendo.statusCode);
        }
        [TestMethod()]
        public async Task GetDispensersWithPaginationTest()
        {
            //Arrange
            var dispensersRequest = new DispensersRequest()
            {
                operatorId = "",
                OrderBy = "",
                PageNumber = 0,
                SearchParam = "",
                PageSize = 0,
            };
            var dispenserResponse = new AllDispenserResponse()
            {
                StatusCode = 200,
                StatusMessage = "Ok",
                Data = new List<GetAllDispenserResponse>()
                 {
                     new GetAllDispenserResponse()
                     {
                          AssetId="1",
                          ChargeBoxId="1",
                          DispenserStatusId=1,
                          EndPointUrl="",
                          FirmwareVersion="",
                          HardwareSerialNumber="1",
                          Id=1,
                          IsActive=true,
                          IsAutomatic=true,
                          LocationId=48,
                          LocationName="Noida",
                          MakeName="",
                          MeterType="",
                          ModelName="",
                          ModemId=1,
                          ModemSerialNumber="1",
                          ModifiedOn=DateTime.Now,
                          MultiplePorts=true,
                          PadId=1,
                          PadName="1",
                          CableId = 1,
                          CableSerialNumber = "1",
                          PingSchedule="",
                          PortType="",
                          PowerCabinetId=1,
                          PowerCabinetSerialNumber="1",
                          FleetStation=true,
                          ProtocolName="",
                          ReadingSchedule="",
                          RFIDReader="",
                          RFIDReaderId=1,
                          SerialNumber="1",
                          Status=""
                     }
                 },
                PortType = new List<PortTypeResponse>()
                 {
                    new PortTypeResponse()
                    {
                         PortType="CHAdeMO_Test",
                         Color="Red",
                         Count=1,
                    }
                 },
                paginationResponse = new Core.PagingHelper.PaginationResponse()
                {
                    CurrentPage = 1,
                    HasNext = true,
                    HasPrevious = true,
                    PageSize = 1,
                    TotalCount = 20,
                    TotalPages = 100,
                }
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetAllDispenserDetailQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenserResponse);

            //Act
            var actionresult = await _dispenserController.GetDispensersWithPagination(dispensersRequest) as ActionResult<AllDispenserResponse>;

            // Assert
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult.Value).StatusCode);
            var allDispenserResponse = (actionresult).Value as AllDispenserResponse;
            Assert.IsNotNull(allDispenserResponse);
        }

        [TestMethod()]
        public async Task GetDispenserDetailsByIdTest()
        {
            // Arrange
            long dispenserId = 1;
            var dispenserResponse = new GetDispenserResponse()
            {
                AssetId = "1",
                ChargeBoxId = "1",
                DispenserStatusId = 1,
                EndPointUrl = "",
                FirmwareVersion = "",
                HardwareSerialNumber = "1",
                Id = 1,
                IsActive = true,
                IsAutomatic = true,
                LocationId = 48,
                LocationName = "Noida",
                MakeName = "",
                MeterType = "",
                ModelName = "",
                ModemId = 1,
                ModemSerialNumber = "1",
                ModifiedOn = DateTime.Now,
                MultiplePorts = true,
                PadId = 1,
                PadName = "1",
                CableId = 1,
                CableSerialNumber = "1",
                PingSchedule = "",
                PortType = "",
                PowerCabinetId = 1,
                PowerCabinetSerialNumber = "1",
                FleetStation = true,
                ProtocolName = "",
                ReadingSchedule = "",
                RFIDReader = "",
                RFIDReaderId = 1,
                SerialNumber = "1",
                Status = "",
                PortCommmand = new List<PortResponse>()
                 {
                      new PortResponse()
                      {
                           PortId = 1,
                           ConnectorId = 1,
                           ConnectorType=1,
                           CreatedBy="",
                           IncrementalPower=10,
                           IsActive=true,
                           MaxPower=100,
                           MinPower=50,
                           PlugTypeId=1,
                           PortName="",
                           Power=2000
                      }
                 }
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetDispenserDetailByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenserResponse);

            //Act
            var actionresult = _dispenserController.GetDispenserDetailsById(dispenserId).Result;

            // Assert
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult).StatusCode);
        }

        [TestMethod()]
        public void DeleteDispenserTest()
        {
            DeleteDispenserCommand deleteDispenserCommand = new DeleteDispenserCommand()
            {
                Id = 192,
                IsActive = false,
            };
            DispenserResponse dispenResponse = new DispenserResponse()
            {
                Id = 192,
                AssetId = "asset12",
                ChargeBoxId = "ch4005",
                EndPointUrl = "url2",
                FirmwareVersion = "virsion123",
                HardwareSerialNumber = "version 2.0",
                LocationId = 48,
                MakeMasterId = 1,
                ModelId = 1,
                ModemId = 1,
                MeterType = "meterType",
                MultiplePorts = true,
                PingSchedule = "1",
                PrivateStation = true,
                ReadingSchedule = "strings",
                SerialNumber = "serial1",
                RFIdReaderId = 19,
                PowerCabinetId = 1,
                PadId = 1,
                DispenserStatusId = 11,
                ProtocolName = "1.6j",
                CreatedBy = "atul",
                ModifiedBy = "atul1",
                IsActive = true,
                IsAutomatic = true,
                CableId = 1
            };
        }
        [TestMethod()]
        public void GetModemDDLTest()
        {
            //Arrange
            PadDataRequest padDataRequest = new PadDataRequest()
            {
                userId = "1"
            };
            List<ListDropDown> modemDropDown = new List<ListDropDown>()
             {
                 new ListDropDown()
                 {
                     Id = 1,
                     Name="Modem1",
                     IsActive = true,
                 }
             };
            _mediator.Setup(md => md.Send(It.IsAny<GetModemDDLQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(modemDropDown);

            // Act
            var actionResult = _dispenserController.GetModemDDL(padDataRequest).Result;
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
        public void GetConnectorTypeTest()
        {
            //Arrange
            ConnectorTypeRequest connectorTypeRequest = new ConnectorTypeRequest()
            {
                userId = "1"
            };
            List<ConnectorTypeResponseData> connectorTypeResponses = new List<ConnectorTypeResponseData>()
             {
                 new ConnectorTypeResponseData()
                 {
                     Id = 1,
                     ConnectorTypeName = "1.6J"
                 }
             };
            _mediator.Setup(md => md.Send(It.IsAny<GetConnectorTypeQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(connectorTypeResponses);

            // Act
            var actionResult = _dispenserController.GetConnectorType(connectorTypeRequest).Result;
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
        public void GetPlugTypeTest()
        {
            //Arrange
            PlugTypeRequest plugTypeRequest = new PlugTypeRequest()
            {
                userId = "1"
            };
            List<PlugTypeResponseData> plugTypeResponseData = new List<PlugTypeResponseData>()
             {
                 new PlugTypeResponseData()
                 {
                     Id = 1,
                     PlugTypeName = "PlugType"
                 }
             };
            _mediator.Setup(md => md.Send(It.IsAny<GetAllPlugTypeQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(plugTypeResponseData);

            // Act
            var actionResult = _dispenserController.GetPlugType(plugTypeRequest).Result;
            dynamic expendo = new ExpandoObject();
            {
                expendo.statusCode = 200;
                expendo.statusMessage = "Record found";
            }
            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(200, expendo.statusCode);
        }
    }
}