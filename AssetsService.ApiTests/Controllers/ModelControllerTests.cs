using AssetsService.Api.Controllers;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AssetsService.Api.Tests
{

    [TestClass()]
    public class ModelControllerTests
    {
        private readonly ModelController _modelController;

        private readonly Mock<IHtmlHelper> _mockHttpHelper;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<ModelController>> _logger;
        private readonly Mock<IConfiguration> _configuration;
        public ModelControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _mockHttpHelper = new Mock<IHtmlHelper>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILogger<ModelController>>();
            _modelController = new ModelController(_mediator.Object, _logger.Object);
            {
            }

        }

        [TestMethod()]
        public void CreateModel()
        {
            CreateModelCommand Command = new CreateModelCommand()
            {
     
                ConnectorCount = 1,
                CreatedBy = "atul",
                CreatedOn = DateTime.Now,
                IsActive = true,
                ManufactureId = 1,
                ModelName = "Model",
                ModifiedBy = "1",
                ModifiedOn = DateTime.Now,
                PortId = 2,
                ProtocolId = 1,
                LevelId = 1,

            };

            ModelResponse modelResponse = new ModelResponse()
            {

                Id = 0,
                ConnectorCount = 1,
                CreatedBy = "atul",
                CreatedOn = DateTime.Now,
                IsActive = true,
                ManufactureId = 1,
                ModelName = "Model",
                ModifiedBy = "atul11",
                ModifiedOn = DateTime.Now,
                PortId = 2,
                ProtocolId = 1,
                LevelId = 1,

            };

            _mediator.Setup(md => md.Send(It.IsAny<CreateModelCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(modelResponse);
            var actionResult = _modelController.CreateModel(Command).Result;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult, 200);

        }

        [TestMethod]
        public void UpdateModel()
        {
            UpdateModelCommand updateModelCommand = new UpdateModelCommand()
            {
                Id = 4,
                ConnectorCount = 3,
                CreatedBy = "1",
                CreatedOn = DateTime.Now,
                IsActive = true,
                ManufactureId = 1,
                ModelName = "Modelss",
                ModifiedBy = "atul11",
                ModifiedOn = DateTime.Now,
                PortId = 2,
                ProtocolId = 1,
                LevelId = 1,
            };
            ModelResponse Response = new ModelResponse()
            {
                 Id = 4,
                ConnectorCount = 3,
                CreatedBy = "atul",
                CreatedOn = DateTime.Now,
                IsActive = true,
                ManufactureId = 1,
                ModelName = "Modelss",
                ModifiedBy = "atul11",
                ModifiedOn = DateTime.Now,
                PortId = 2,
                ProtocolId = 1,
                LevelId = 1,

            };

             _mediator.Setup(md => md.Send(It.IsAny<UpdateModelCommand>(), It.IsAny<CancellationToken>()));

            var actionResult = _modelController.UpdateCable(updateModelCommand);
            if (actionResult != null)
            {
                Assert.AreEqual(200, actionResult);
            }
        }

    }
}