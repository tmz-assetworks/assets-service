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

namespace AssetsService.Api.Tests
{
    [TestClass()]
    public class DispenserControllerTestCase
    {

        private readonly DispenserController _dispenserController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<TokenBase> _token;
        private readonly Mock<ILogger<DispenserController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public DispenserControllerTestCase()
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
        public void CreateDispenserController()
        {
            CreateDispenserCommand createDispenser = new CreateDispenserCommand()
            {

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
                IsActive = true,
                IsAutomatic = true,
                PortCommand = new List<PortCommand>()
                {
                    new PortCommand(){
                        Id = 0,
                        ConnectorType=123,
                        ConnectorId=1,
                        IncrementalPower=120,
                        IsActive=true,
                        MaxPower=12567,
                        MinPower=87655,
                        PlugTypeId=2,
                        PortName="port12",
                        Power=123,
},

}
            };
            DispenserResponse dispenserResponse = new DispenserResponse()
            {
                Id = 0,
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
            };
            _mediator.Setup(md => md.Send(It.IsAny<CreateDispenserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenserResponse);
            var actionResult = _dispenserController.CreateDispenser(createDispenser).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult, 200);

        }
        [TestMethod()]
        public void UpdateDispenserTest()
        {
            UpdateDispenserCommand updateDispenserCommand = new UpdateDispenserCommand()
            {
                AssetId = "asset125",
                ChargeBoxId = "ch40056",
                EndPointUrl = "url21",
                FirmwareVersion = "virsion1234",
                HardwareSerialNumber = "version 2.1",
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
                ModifiedBy = "atul",
                IsActive = true,
                IsAutomatic = true,
                UpdatePortCommand = new List<UpdatePortCommand>()
                {
                    new UpdatePortCommand(){
                        Id = 0,
                        ConnectorType=123,
                        ConnectorId=1,
                        IncrementalPower=120,
                        IsActive=true,
                        MaxPower=12567,
                        MinPower=87655,
                        PlugTypeId=2,
                        PortName="port12",
                        Power=123,
},

}
            };
            DispenserResponse dispenserResponse = new DispenserResponse()
            {
                Id = 0,
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
            };
            dynamic expandoObject = new ExpandoObject();
            expandoObject.StatusCode = 200;
            expandoObject.StatusMessage = "Record updated successfully.";

            _mediator.Setup(md => md.Send(It.IsAny<UpdateVehicleCommand>(), It.IsAny<CancellationToken>()));

            var actionResult = _dispenserController.UpdateDispenser(updateDispenserCommand).Result.Value.FirstOrDefault(c => c.Key.ToLower() == "statuscode").Value;
            if (actionResult != null)
            {
                Assert.AreEqual(200, actionResult);
            }


        }
        [TestMethod()]
        public void GetAllDispenserWithPagination()
        {
            DispensersRequest getAllDispenserRequest = new DispensersRequest()
            {
                operatorId = "1",
                SearchParam = "",
                PageSize = 10,
                PageNumber = 1,
                OrderBy = "",


            };
            var AllDispensersResponse = new AllDispenserResponse()
            {
                Data = new List<GetAllDispenserResponse>()
                {
                    new GetAllDispenserResponse()
                    {

                    }
                },
                paginationResponse = new PaginationResponse()
                {
                    CurrentPage = 1,
                    HasNext = true,
                    HasPrevious = true,
                    PageSize = 10,
                    TotalCount = 10,
                    TotalPages = 10
                }
            };

            AllDispenserResponse allDispenserResponse = new AllDispenserResponse();
            _mediator.Setup(md => md.Send(It.IsAny<GetAllDispenserDetailQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(AllDispensersResponse);
            var actionResult = _dispenserController.GetDispensersWithPagination(getAllDispenserRequest).Result;
            Assert.IsNotNull(actionResult);
        }

        [TestMethod()]
        public void DispenserDetailsById()
        {
            int DispenserId = 190;
            GetDispenserResponse dispenserByIdResponse = new GetDispenserResponse()
            {
                Id = 190,
                AssetId = "Asset2023",
                ChargeBoxId = "CH2023",
                EndPointUrl = "endPointUrl",
                FirmwareVersion = "Firmware Version2023",
                HardwareSerialNumber = "hardwareSerial1",
                LocationId = 83,
                LocationName = "mahagun noida",
                MakeMasterId = 3,
                Make = "BoldMak",
                ModelId = 5,
                Model = "5",
                ModemId = 3,
                ModemSerialNumber = "11",
                MeterType = "Didital",
                MultiplePorts = false,
                SerialNumber = "serialNumber05",
                PingSchedule = "Eveni",
                PrivateStation = false,
                ReadingSchedule = "Evening",
                PowerCabinetSerialNumber = "2022",
                RFIDReaderId = 19,
                RFIDReader = "Rader 01",
                PowerCabinetId = 2,
                DispenserStatusId = 5,
                PadId = 10,
                PadName = "AssetsWorksTMZ01",
                ProtocolName = "1.6J",
                Status = "Busy",
                PortType = "Port",
                ModifiedOn = DateTime.Now,
                IsActive = true,
                IsAutomatic = true,
                PortCommmand = new List<PortResponse>()

            };

            _mediator.Setup(md => md.Send(It.IsAny<GetDispenserDetailByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenserByIdResponse);
            var actionResult = _dispenserController.GetDispenserDetailsById(DispenserId).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, ((actionResult) as GetDispenserByIdResponse).StatusCode);
        }

        [TestMethod()]
        public void DeleteDispenser()
        {
            DeleteDispenserCommand deleteDispenserCommand = new DeleteDispenserCommand()
            {
                Id = 192,
                IsActive= false,
            };
            DispenserResponse dispenResponse = new DispenserResponse(){
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

            };
        }

    }
}