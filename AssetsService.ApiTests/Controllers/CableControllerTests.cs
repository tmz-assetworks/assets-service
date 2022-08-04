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
    public class CableControllerTests
    {
        private readonly CableController _cableController;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<CableController>> _logger;

        public CableControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<CableController>>();

            _cableController = new CableController(_mediator.Object, _logger.Object);
            {

            }
        }
        [TestMethod()]
        public async Task GetAllCableTest()
        {
            // Arrange
            var cableList = new List<AssetsService.Core.Entities.Cable>() {
            new AssetsService.Core.Entities.Cable()
            {
                Id = 1,
                AssetId = "1",
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                InstallationDate = DateTime.Now,
                IsActive = true,
                MakeMaster = new AssetsService.Core.Entities.MakeMaster()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    Description = "Desc",
                    Name = "Cable"
                },
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                NetworkId = 1,
                NetworkName = "NetworkName",
                SerialNumber = "1",
                Status = new AssetsService.Core.Entities.Status()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                },
                StatusId = 1,
                SubNetworkId = 1,
                SubNetworkName = "Subnetwork",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
            }
            };
            _mediator.Setup(md => md.Send(It.IsAny<GetAllCableQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(cableList);
            //Act
            var actionResult = _cableController.GetAllCable().Result as AssetsService.Core.Responses.CableQueryResponse;

            // Assert 
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult.StatusCode));
        }

        [TestMethod()]
        public async Task GetCableByIdTest()
        {
            //Arrange
            int id = 1;
            var chargerSessionRequest = new AssetsService.Application.Queries.GetByIdCablesQuery(id);
            var Dto = new AssetsService.Core.Entities.Cable()
            {
                Id = id,
                AssetId = "1",
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                InstallationDate = DateTime.Now,
                IsActive = true,
                MakeMaster = new AssetsService.Core.Entities.MakeMaster()
                {
                    Id = id,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    Description = "Desc",
                    Name = "Cable"
                },
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                NetworkId = 1,
                NetworkName = "NetworkName",
                SerialNumber = "1",
                Status = new AssetsService.Core.Entities.Status()
                {
                    Id = id,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                },
                StatusId = id,
                SubNetworkId = 1,
                SubNetworkName = "Subnetwork",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
            };

            _mediator.Setup(md => md.Send(It.IsAny<GetByIdCablesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(Dto);

            //Act
            var actionResult = _cableController.GetCableById(id);

            // Assert 
            Assert.IsNotNull(actionResult);
        }
        [TestMethod()]
        public async Task CreateCableTest()
        {
            //Arrange
            AssetsService.Application.Commands.Assets.CreateCableCommand createCable = CreateCableCommandDTO();
            var Dto = new AssetsService.Core.Responses.CableResponse()
            {
                Id = 1,
                AssetId = "1",
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                InstallationDate = DateTime.Now,
                IsActive = true,
                MakeMaster = new AssetsService.Core.Entities.MakeMaster()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    Description = "Desc",
                    Name = "Cable"
                },
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                NetworkId = 1,
                NetworkName = "NetworkName",
                SerialNumber = "1",
                Status = new AssetsService.Core.Entities.Status()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                },
                StatusId = 1,
                SubNetworkId = 1,
                SubNetworkName = "Subnetwork",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
            };
            _mediator.Setup(md => md.Send(It.IsAny<CreateCableCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Dto);

            //Act
            var actionresult = _cableController.CreateCable(createCable).Result as ActionResult<AssetsService.Core.Responses.CableResponse>;

            // Assert 
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult.Result as OkObjectResult).StatusCode);
        }

        [TestMethod()]
        public async Task UpdateCableTest()
        {
            //Arrange
            AssetsService.Application.Commands.Assets.UpdateCableCommand updateCable = UpdateCableCommandDTO();
            var Dto = new AssetsService.Core.Responses.CableResponse()
            {
                Id = 1,
                AssetId = "1",
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                InstallationDate = DateTime.Now,
                IsActive = true,
                MakeMaster = new AssetsService.Core.Entities.MakeMaster()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    Description = "Desc",
                    Name = "Cable"
                },
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                NetworkId = 1,
                NetworkName = "NetworkName",
                SerialNumber = "1",
                Status = new AssetsService.Core.Entities.Status()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                },
                StatusId = 1,
                SubNetworkId = 1,
                SubNetworkName = "Subnetwork",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
            };
            _mediator.Setup(md => md.Send(It.IsAny<UpdateCableCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Dto);

            //Act
            var actionresult = _cableController.UpdateCable(updateCable).Result as ActionResult<AssetsService.Core.Responses.CableResponse>;

            // Assert 
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult.Result as OkObjectResult).StatusCode);
        }

        [TestMethod()]
        public async Task DeleteCableTest()
        {
            //Arrange
            AssetsService.Application.Commands.Assets.DeleteCableCommand deleteCable = DeleteCableCommandDTO();
            var Dto = new AssetsService.Core.Responses.CableResponse()
            {
                Id = 1,
                AssetId = "1",
                CreatedBy = "John",
                CreatedOn = DateTime.Now,
                InstallationDate = DateTime.Now,
                IsActive = true,
                MakeMaster = new AssetsService.Core.Entities.MakeMaster()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    Description = "Desc",
                    Name = "Cable"
                },
                MakeMasterId = 1,
                ModelId = 1,
                ModifiedBy = "Smith",
                ModifiedOn = DateTime.Now,
                NetworkId = 1,
                NetworkName = "NetworkName",
                SerialNumber = "1",
                Status = new AssetsService.Core.Entities.Status()
                {
                    Id = 1,
                    CreatedBy = "test",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                },
                StatusId = 1,
                SubNetworkId = 1,
                SubNetworkName = "Subnetwork",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
            };
            _mediator.Setup(md => md.Send(It.IsAny<DeleteCableCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Dto);

            //Act
            var actionresult = _cableController.DeleteCable(deleteCable).Result as ActionResult<AssetsService.Core.Responses.CableResponse>;

            // Assert 
            Assert.IsNotNull(actionresult);
            Assert.AreEqual(200, (actionresult.Result as OkObjectResult).StatusCode);
        }
        private AssetsService.Application.Commands.Assets.CreateCableCommand CreateCableCommandDTO()
        {
            return new AssetsService.Application.Commands.Assets.CreateCableCommand()
            {
                AssetId = "1",
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 1,
                NetworkId = 1,
                NetworkName = "NetworkName",
                SerialNumber = "1",
                StatusId = 1,
                SubNetworkId = 1,
                SubNetworkName = "SubNetworkName",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
                CreatedBy = "test",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "test",
                ModifiedOn = DateTime.UtcNow,
            };
        }
        private AssetsService.Application.Commands.Assets.UpdateCableCommand UpdateCableCommandDTO()
        {
            return new AssetsService.Application.Commands.Assets.UpdateCableCommand()
            {
                Id = 1,
                AssetId = "1",
                InstallationDate = DateTime.Now,
                MakeMasterId = 1,
                ModelId = 1,
                NetworkId = 1,
                NetworkName = "NetworkName",
                SerialNumber = "1",
                StatusId = 1,
                SubNetworkId = 1,
                SubNetworkName = "SubNetworkName",
                WarrantyDuration = 1,
                WarrantyExpiryDate = DateTime.Now,
                WarrantyStartDate = DateTime.Now,
                CreatedBy = "test",
                CreatedOn = DateTime.UtcNow,
                ModifiedBy = "test",
                ModifiedOn = DateTime.UtcNow,
                IsActive = true
            };
        }
        private AssetsService.Application.Commands.Assets.DeleteCableCommand DeleteCableCommandDTO()
        {
            return new AssetsService.Application.Commands.Assets.DeleteCableCommand()
            {
                Id = 1,
                IsActive = true
            };
        }
    }
}