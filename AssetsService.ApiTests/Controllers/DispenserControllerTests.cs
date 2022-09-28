// ﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
// using AssetsService.Api;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using MediatR;
// using Moq;
// using AssetsService.Core.Response;
// using AssetsService.Application.Queries;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using AssetsService.Core.Entities;
// using AssetsService.Application.Commands.Assets;
// using AssetsService.Application.Responses.Assets;
// using System.Dynamic;
// using AssetsService.Core.Responses.Assets;
// using AssetsService.Infrastructure.Helpers;

// namespace AssetsService.Api.Tests
// {
//     [TestClass()]
//     public class DispenserControllerTests
//     {
//         public readonly DispenserController dispenserController;
//         private readonly Mock<IMediator> _mediator;
//         private readonly Mock<ILogger<DispenserController>> _logger;
//         public DispenserControllerTests()
//         {
//             _mediator = new Mock<IMediator>();
//             _logger = new Mock<ILogger<DispenserController>>();
//             TokenBase token = new TokenBase();
//             dispenserController = new DispenserController(_mediator.Object, _logger.Object, token);
//             {
//             }
//         }

//         [TestMethod()]
//         public void DispenserControllerTest()
//         {

//         }

//         [TestMethod()]
//         public void GetAllDispenserTest()
//         {

//         }

//         [TestMethod()]
//         public void GetAllModelDataTest()
//         {

//         }

//         [TestMethod()]
//         public async Task GetDispensersWithPaginationTest()
//         {
//             //Arrange
//             var dispensersRequest = new DispensersRequest()
//             {
//                  operatorId="",
//                  OrderBy="",
//                  PageNumber=0,
//                  SearchParam="",
//                  PageSize = 0,
//             };
//             var dispenserResponse = new AllDispenserResponse()
//             {
//                 StatusCode = 200,
//                 StatusMessage = "Ok",
//                 Data = new List<GetAllDispenserResponse>()
//                 {
//                     new GetAllDispenserResponse()
//                     {
//                          AssetId="1",
//                          ChargeBoxId="1",
//                          DispenserStatusId=1,
//                          EndPointUrl="",
//                          FirmwareVersion="",
//                          HardwareSerialNumber="1",
//                          Id=1,
//                          IsActive=true,
//                          IsAutomatic=true,
//                          LocationId=48,
//                          LocationName="Noida",
//                          Make="",
//                          MakeMasterId=1,
//                          MeterType="",
//                          Model="",
//                          ModelId=1,
//                          ModemId=1,
//                          ModemSerialNumber="1",
//                          ModifiedOn=DateTime.Now,
//                          MultiplePorts=true,
//                          PadId=1,
//                          PadName="1",
//                          PingSchedule="",
//                          PortType="",
//                          PowerCabinetId=1,
//                          PowerCabinetSerialNumber="1",
//                          PrivateStation=true,
//                          ProtocolName="",
//                          ReadingSchedule="",
//                          RFIDReader="",
//                          RFIDReaderId=1,
//                          SerialNumber="1",
//                          Status=""
//                     }
//                 },
//                 PortType = new List<PortTypeResponse>()
//                 {
//                    new PortTypeResponse()
//                    {
//                         PortType="CHAdeMO_Test",
//                         Color="Red",
//                         Count=1,
//                    }
//                 },
//                  paginationResponse=new Core.PagingHelper.PaginationResponse()
//                  {
//                      CurrentPage=1,
//                      HasNext=true,
//                      HasPrevious=true,
//                      PageSize=1,
//                      TotalCount=20,
//                      TotalPages=100,
//                  }
//             };
//             _mediator.Setup(md => md.Send(It.IsAny<GetAllDispenserDetailQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenserResponse);

//             //Act
//             var actionresult = await dispenserController.GetDispensersWithPagination(dispensersRequest) as ActionResult<AllDispenserResponse>;

//             // Assert
//             Assert.IsNotNull(actionresult);
//             Assert.AreEqual(200, (actionresult.Value).StatusCode);
//             var allDispenserResponse = (actionresult).Value as AllDispenserResponse;
//             Assert.IsNotNull(allDispenserResponse);
//         }

//         [TestMethod()]
//         public async Task GetDispenserDetailsByIdTest()
//         {
//             // Arrange
//             long dispenserId = 1;
//             var dispenserResponse = new GetDispenserResponse()
//             {
//                 AssetId = "1",
//                 ChargeBoxId = "1",
//                 DispenserStatusId = 1,
//                 EndPointUrl = "",
//                 FirmwareVersion = "",
//                 HardwareSerialNumber = "1",
//                 Id = 1,
//                 IsActive = true,
//                 IsAutomatic = true,
//                 LocationId = 48,
//                 LocationName = "Noida",
//                 Make = "",
//                 MakeMasterId = 1,
//                 MeterType = "",
//                 Model = "",
//                 ModelId = 1,
//                 ModemId = 1,
//                 ModemSerialNumber = "1",
//                 ModifiedOn = DateTime.Now,
//                 MultiplePorts = true,
//                 PadId = 1,
//                 PadName = "1",
//                 PingSchedule = "",
//                 PortType = "",
//                 PowerCabinetId = 1,
//                 PowerCabinetSerialNumber = "1",
//                 PrivateStation = true,
//                 ProtocolName = "",
//                 ReadingSchedule = "",
//                 RFIDReader = "",
//                 RFIDReaderId = 1,
//                 SerialNumber = "1",
//                 Status = "", 
//                 PortCommmand= new List<PortResponse>()
//                 {
//                      new PortResponse()
//                      {
//                           PortId = 1,
//                           ConnectorId = 1,
//                           ConnectorType=1,
//                           CreatedBy="",
//                           IncrementalPower=10,
//                           IsActive=true,
//                           MaxPower=100,
//                           MinPower=50,
//                           PlugTypeId=1,
//                           PortName="",
//                           Power=2000
//                      }
//                 }
//             };
//             _mediator.Setup(md => md.Send(It.IsAny<GetDispenserDetailByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenserResponse);

//             //Act
//             var actionresult =  dispenserController.GetDispenserDetailsById(dispenserId).Result;

//             // Assert
//             Assert.IsNotNull(actionresult);
//             Assert.AreEqual(200, (actionresult).StatusCode);
//         }

//         [TestMethod()]
//         public void GetDispenserByIdTest()
//         {

//         }

//         [TestMethod()]
//         public void getDispenserByLocationIdTest()
//         {

//         }

//         [TestMethod()]
//         public void GetDispenserByChargeBoxIdTest()
//         {

//         }

//         [TestMethod()]
//         public void GetDispenserByStationIdTest()
//         {

//         }

//         [TestMethod()]
//         public void DeletedispenserTest()
//         {

//         }

//         [TestMethod()]
//         public async Task CreateDispenserTest()
//         {
//             //Arrange
//             CreateDispenserCommand command = new CreateDispenserCommand()
//             {
//                 AssetId = "New RFID 22 0",
//                 SerialNumber = "RRMOINr43",
//                 LocationId = 1,
//                 MakeMasterId = 1,
//                 ModelId = 1,
//                 CreatedBy = "1",
//                 ChargeBoxId = "",
//                 RFIdReaderId = 1,
//                 DispenserStatusId = 1,
//                 EndPointUrl = "",
//                 FirmwareVersion = "",
//                 HardwareSerialNumber = "1",
//                 IsActive = true,
//                 IsAutomatic = true,
//                 MeterType = "",
//                 ModemId = 1,
//                 MultiplePorts = true,
//                 PadId = 1,
//                 PingSchedule = "",
//                 PowerCabinetId = 1,
//                 PrivateStation = true,
//                 ProtocolName = "",
//                 ReadingSchedule = "",
//                 PortCommand = new List<PortCommand>()
//                 {
//                   new PortCommand()
//                   {
//                        ConnectorId=1,
//                        ConnectorType=1,
//                        IncrementalPower=100,
//                        MaxPower=100,
//                        MinPower=100,
//                        PlugTypeId=1,
//                        PortName="",
//                        //CreatedBy="1",
//                        IsActive=true,
//                        Power=500
//                   }
//                 }
//             };
//             DispenserResponse dispenser = new DispenserResponse()
//             {
//                 Id = 1,
//                 AssetId = "New RFID 22 0",
//                 SerialNumber = "RRMOINr43",
//                 LocationId = 1,
//                 MakeMasterId = 1,
//                 ModelId = 1,
//                 CreatedBy = "1",
//                 ChargeBoxId = "",
//                 RFIdReaderId = 1,
//                 DispenserStatusId = 1,
//                 EndPointUrl = "",
//                 FirmwareVersion = "",
//                 HardwareSerialNumber = "1",
//                 IsActive = true,
//                 IsAutomatic = true,
//                 MeterType = "",
//                 ModemId = 1,
//                 MultiplePorts = true,
//                 PadId = 1,
//                 PingSchedule = "",
//                 PowerCabinetId = 1,
//                 PrivateStation = true,
//                 ProtocolName = "",
//                 ReadingSchedule = "",
//                 ModifiedBy = "1",
//             };

//             dynamic expendo = new ExpandoObject();
//             {
//                 expendo.statusCode = 200;
//                 expendo.statusMessage = "Recoed saved successfully";
//                 expendo.Id = dispenser.Id;
//             }
//             _mediator.Setup(md => md.Send(It.IsAny<CreateDispenserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenser);

//             // Act
//             var actionResult = dispenserController.CreateDispenser(command).Result;
      
//             // Assert
//             Assert.IsNotNull(actionResult.Value);
//             Assert.AreEqual(200, expendo.statusCode);
//         }

//         [TestMethod()]
//         public void UpdateDispenserTest()
//         {
//             //Arrange
//             UpdateDispenserCommand command = new UpdateDispenserCommand()
//             {
//                 Id = 1,
//                 AssetId = "New RFID 22 0",
//                 SerialNumber = "RRMOINr43",
//                 LocationId = 1,
//                 MakeMasterId = 1,
//                 ModelId = 1,
//                 ModifiedBy = "1",
//                 ChargeBoxId = "",
//                 RFIdReaderId = 1,
//                 DispenserStatusId = 1,
//                 EndPointUrl = "",
//                 FirmwareVersion = "",
//                 HardwareSerialNumber = "1",
//                 IsActive = true,
//                 IsAutomatic = true,
//                 MeterType = "",
//                 ModemId = 1,
//                 MultiplePorts = true,
//                 PadId = 1,
//                 PingSchedule = "",
//                 PowerCabinetId = 1,
//                 PrivateStation = true,
//                 ProtocolName = "",
//                 ReadingSchedule = "",
//                 UpdatePortCommand = new List<UpdatePortCommand>()
//                 {
//                   new UpdatePortCommand()
//                   {
//                        Id=1,
//                        ConnectorId=1,
//                        ConnectorType=1,
//                        IncrementalPower=100,
//                        MaxPower=100,
//                        MinPower=100,
//                        PlugTypeId=1,
//                        PortName="",
//                       // ModifiedBy="1",
//                        IsActive=true,
//                        Power=500
//                   }
//                 }
//             };
//             DispenserResponse dispenser = new DispenserResponse()
//             {
//                 Id = 1,
//                 AssetId = "New RFID 22 0",
//                 SerialNumber = "RRMOINr43",
//                 LocationId = 1,
//                 MakeMasterId = 1,
//                 ModelId = 1,
//                 CreatedBy = "1",
//                 ChargeBoxId = "",
//                 RFIdReaderId = 1,
//                 DispenserStatusId = 1,
//                 EndPointUrl = "",
//                 FirmwareVersion = "",
//                 HardwareSerialNumber = "1",
//                 IsActive = true,
//                 IsAutomatic = true,
//                 MeterType = "",
//                 ModemId = 1,
//                 MultiplePorts = true,
//                 PadId = 1,
//                 PingSchedule = "",
//                 PowerCabinetId = 1,
//                 PrivateStation = true,
//                 ProtocolName = "",
//                 ReadingSchedule = "",
//                 ModifiedBy = "1",
//             };

//             dynamic expendo = new ExpandoObject();
//             {
//                 expendo.statusCode = 200;
//                 expendo.statusMessage = "Recoed updated successfully";
//                 expendo.Id = dispenser.Id;
//             }
//             _mediator.Setup(md => md.Send(It.IsAny<UpdateDispenserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(dispenser);

//             // Act
//             var actionResult = dispenserController.UpdateDispenser(command).Result;

//             // Assert
//             Assert.IsNotNull(actionResult.Value);
//             Assert.AreEqual(200, expendo.statusCode);
//         }

//         [TestMethod()]
//         public void GetDispenserByLocationsTest()
//         {

//         }

//         [TestMethod()]
//         public void GetDispensersListTest()
//         {

//         }

//         [TestMethod()]
//         public void ValidateChargerIdTest()
//         {

//         }

//         [TestMethod()]
//         public void GetModemDDLTest()
//         {
//             //Arrange
//             PadDataRequest padDataRequest = new PadDataRequest()
//             {
//                userId="1"
//             };
//             List<ListDropDown> modemDropDown = new List<ListDropDown>()
//             {
//                 new ListDropDown()
//                 {
//                     Id = 1,
//                     Name="Modem1"
//                 }
//             };

//             dynamic expendo = new ExpandoObject();
//             {
//                 expendo.statusCode = 200;
//                 expendo.statusMessage = "Record found";
//             }
//             _mediator.Setup(md => md.Send(It.IsAny<GetModemDDLQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(modemDropDown);

//             // Act
//             var actionResult = dispenserController.GetModemDDL(padDataRequest).Result;

//             // Assert
//             Assert.IsNotNull(actionResult.Value);
//             Assert.AreEqual(200, expendo.statusCode);
//         }
//     }
// }
