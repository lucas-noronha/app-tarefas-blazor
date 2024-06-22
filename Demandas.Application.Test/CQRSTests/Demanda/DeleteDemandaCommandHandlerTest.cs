using Demandas.Application.CQRS.Demanda.Commands.Handlers;
using Demandas.Application.CQRS.Demanda.Commands;
using Demandas.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.CQRSTests.Demanda
{
    public class DeleteDemandaCommandHandlerTest
    {
        private readonly Mock<IDemandaService> _mockDemandaService;

        public DeleteDemandaCommandHandlerTest()
        {
            _mockDemandaService = new Mock<IDemandaService>();
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldDeleteDemanda()
        {
            // Arrange
            var command = new DeleteDemandaCommand(1);
            _mockDemandaService.Setup(s => s.Remover(It.IsAny<int>())).Returns(Task.CompletedTask);
            var handler = new DeleteDemandaCommandHandler(_mockDemandaService.Object);

            // Act
            await handler.Handle(command, new CancellationToken());

            // Assert
            _mockDemandaService.Verify(s => s.Remover(1), Times.Once);
        }
    }
}
