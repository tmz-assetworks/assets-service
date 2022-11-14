using AssetsService.Api.Controllers;
using AssetsService.Application.Commands.Assets.RFId;
using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Dynamic;

namespace AssetsService.Api.Tests
{

    [TestClass()]
    public class RfIdReaderControllerTest
    {
        private readonly RFIdReaderController _rfIdReaderController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<RFIDReader>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<TokenBase> _token;
        public RfIdReaderControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<RFIDReader>>();
            _token = new Mock<TokenBase>();
            _rfIdReaderController = new RFIdReaderController(_mediator.Object, _logger.Object, _token.Object);
            {
            }
        }
        //===============================Test case Details page=========================================

        [TestMethod()]
        public void GetRfIdReaderByIdTest()
        {
            // Arrange 
            int rfIdReaderId = 4;
            RFIDReaderDetails rFIDReaderDetails = new RFIDReaderDetails()
            {
                Id = 4,
                AssetId = "RfId 011 update",
                CardReader = "Rader 01",
                CreatedBy = "1",
                CreatedOn = DateTime.Now,
                IsActive = true,
                MakeMasterId = 1,
                MakeMasterName = "Make 1",
                ModelId = 1,
                ModelName = "Model",
                ModifiedBy = "1",
                ModifiedOn = DateTime.Now,
                SerialNumber = "1",
                StatusId = 1,
                StatusName = "Commissioned",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                LocationId = 1,
                LocationName = "Noida",
                WarrantyStartDate = DateTime.Now,
            };


            _mediator.Setup(md => md.Send(It.IsAny<GetByIdRfIdReaderQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(rFIDReaderDetails);
            var actionResult = _rfIdReaderController.GetRfIdReaderById(rfIdReaderId).Result as ActionResult<RfIdReaderDetailsResponse>;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, ((actionResult).Value as RfIdReaderDetailsResponse).StatusCode);
        }

        [TestMethod()]
        public void GetAddRfIdReaderTest()
        {
            CreateRFIdCommand command = new CreateRFIdCommand()
            {
                AssetId = "New RFID 22 0",
                SerialNumber = "RRMOINr43",
                LocationId = 1,
                StatusId = 1,
                CardReader = "string1",
                MakeMasterId = 1,
                ModelId = 1,
                WarrantyStartDate = DateTime.Now,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyDuration = 2,
                CreatedBy = "1"
            };
            RFIDReader rFIDReader = new RFIDReader()
            {
                Id = 1,
                AssetId = "ASSET 12 9",
                CardReader = "CARD 898 ",
                CreatedBy = "1",
                CreatedOn = DateTime.Now,
                IsActive = true,
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "1",
                ModifiedOn = DateTime.Now,
                SerialNumber = "SR0990",
                StatusId = 1,
                WarrantyDuration = 200,
                WarrantyExpiryDate = DateTime.Now,
                LocationId = 1,
                WarrantyStartDate = DateTime.Now
            };

            _mediator.Setup(md => md.Send(It.IsAny<CreateRFIdCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(rFIDReader);
            var actionResult = _rfIdReaderController.AddRfIdReader(command).Result;
            // Assert
            Assert.IsNotNull(actionResult);

            Assert.AreEqual(200, ((actionResult).Value as CreateCommonResponse).statusCode);
        }


        [TestMethod()]
        public void UpdateRfIdReaderTest()
        {
            UpdateRFIdCommand command = new UpdateRFIdCommand()
            {
                Id = 1,
                AssetId = "New RFID 22 0",
                SerialNumber = "RRMOINr43",
                LocationId = 1,
                StatusId = 1,
                CardReader = "string1",
                MakeMasterId = 1,
                ModelId = 1,
                WarrantyStartDate = DateTime.Now,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyDuration = 2,
                ModifiedBy = "1"
            };
            RFIDReader rFIDReader = new RFIDReader()
            {
                Id = 1,
                AssetId = "ASSET 12 9",
                CardReader = "CARD 898 ",
                CreatedBy = "1",
                CreatedOn = DateTime.Now,
                IsActive = true,
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "1",
                ModifiedOn = DateTime.Now,
                SerialNumber = "SR0990",
                StatusId = 1,
                WarrantyDuration = 200,
                WarrantyExpiryDate = DateTime.Now,
                LocationId = 1,
                WarrantyStartDate = DateTime.Now
            };

            _mediator.Setup(md => md.Send(It.IsAny<UpdateRFIdCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(rFIDReader);
            var actionResult = _rfIdReaderController.UpdateRfIdReader(command).Result;
            // Assert
            Assert.IsNotNull(actionResult);

            Assert.AreEqual(200, ((actionResult).Value as UpdateCommonResponse).statusCode);
        }


        [TestMethod()]
        public void IsActiveRfIdReaderTest()
        {
            IsActiveRfIdReaderCommand isActiveCommand = new IsActiveRfIdReaderCommand()
            {
                Id = 1,
                IsActive = true,
                ModifiedBy = "1"
            };
            RFIdResponse rFIDReader = new RFIdResponse();

            _mediator.Setup(md => md.Send(It.IsAny<IsActiveRfIdReaderCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(rFIDReader);
            var actionResult = _rfIdReaderController.IsActiveRfIdReader(isActiveCommand).Result;
            // Assert
            Assert.IsNotNull(actionResult);

            Assert.AreEqual(200, ((actionResult).Value as UpdateCommonResponse).statusCode);
        }


        [TestMethod()]
        public void GetAllRFIdReaderDataTest()
        {
            RfIdReaderDataRequest rfIdReaderDataRequest = new RfIdReaderDataRequest()
            {
                userId = "1",
            };
            RfIdReaderDataRespnse rfIdReaderDataRespnse = new RfIdReaderDataRespnse();
            List<RFIDReader> rFIDReaders = new List<RFIDReader>();

            _mediator.Setup(md => md.Send(It.IsAny<GetRFIdReaderDataQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(rFIDReaders);
            var actionResult = _rfIdReaderController.GetAllRFIdReaderData(rfIdReaderDataRequest).Result;
            // Assert
            Assert.IsNotNull(actionResult);

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult as RfIdReaderDataRespnse).StatusCode);
        }


        /// <summary>
        /// All RfId Readers  with Paggination
        /// </summary>
        [TestMethod()]
        public void GetAllRfIdReadersTest()
        {
            RfIdReaderRequest rfIdReaderRequest = new RfIdReaderRequest()
            {
                operatorId = "1",
                SearchParam = "",
                PageSize = 10,
                PageNumber = 1,
                OrderBy = "",
            };
            RfIdReaderRespnse rfIdReaderRespnse = new RfIdReaderRespnse()
            {
                StatusCode = 200,
                StatusMessage = "Record found",
                data = new List<RFIDReaderDetails> { new RFIDReaderDetails()
                {
                     Id =5,
                     AssetId= "Asset 10",
                     CardReader= "Card 1",
                     CreatedBy= "1",
                     CreatedOn= DateTime.Now,
                     IsActive= true,
                     MakeMasterId =1  ,
                     MakeMasterName ="MakeMasterName",
                     ModelId = 1,
                     ModelName= "ModelName",
                     ModifiedBy="1",
                     ModifiedOn = DateTime.Now,
                     SerialNumber="2321312",
                     StatusId=1,
                     StatusName= "Available",
                     WarrantyDuration=10,
                     WarrantyExpiryDate = DateTime.Now,
                     LocationId = 4,
                     LocationName=  "Delhi",
                     WarrantyStartDate= DateTime.Now
                } },

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
            List<RFIDReader> rfidreaders = new List<RFIDReader>()
            {
                new RFIDReader()
            {
                        Id                  =11,
                        AssetId             ="Asset 1",
                        CardReader          ="Card",
                        CreatedBy           = "1",
                        CreatedOn           =DateTime.Now,
                        IsActive            =true,
                        MakeMasterId        = 1,
                        ModelId             =1,
                        ModifiedOn          = DateTime.Now,
                        SerialNumber        ="SerialNo1",
                        Status= new Status() { Id=1, CreatedBy = "1", ModifiedOn = DateTime.Now },
                        StatusId            =1,
                        LocationId=1,
                        Location= new Location(),
                        WarrantyDuration    = 10,
                        WarrantyExpiryDate  = DateTime.Now,
                        WarrantyStartDate   = DateTime.Now,
                        }
                         };

            _mediator.Setup(md => md.Send(It.IsAny<GetRFIdReaderDataQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(rfidreaders);
            var actionResult = _rfIdReaderController.GetAllRfIdReaders(rfIdReaderRequest).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.Value).StatusCode);
            var rfIdReaderData = (actionResult).Value as RfIdReaderRespnse;
            Assert.IsNotNull(rfIdReaderData);

        }
    }
}



