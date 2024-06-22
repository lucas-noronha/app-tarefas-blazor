using Demandas.Application.CQRS.Demanda.Commands.Handlers;
using Demandas.Application.CQRS.Demanda.Commands;
using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.CQRSTests.Demanda
{
    public class CreateDemandaCommandHandlerTest
    {
        private readonly Mock<IDemandaService> _mockDemandaService;

        public CreateDemandaCommandHandlerTest()
        {
            _mockDemandaService = new Mock<IDemandaService>();
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldCreateDemanda()
        {
            // Arrange
            var demandaDto = new DemandaDto { Id = 1 };
            var command = new CreateDemandaCommand(demandaDto);
            _mockDemandaService.Setup(s => s.Adicionar(It.IsAny<DemandaDto>())).ReturnsAsync(demandaDto);
            var handler = new CreateDemandaCommandHandler(_mockDemandaService.Object);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(1, result);
        }
    }
}
