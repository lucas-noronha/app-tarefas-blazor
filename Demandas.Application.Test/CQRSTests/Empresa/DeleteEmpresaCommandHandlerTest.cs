using Demandas.Application.CQRS.Empresa.Commands.Handlers;
using Demandas.Application.CQRS.Empresa.Commands;
using Demandas.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.CQRSTests.Empresa
{
    public class DeleteEmpresaCommandHandlerTest
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService;

        public DeleteEmpresaCommandHandlerTest()
        {
            _mockEmpresaService = new Mock<IEmpresaService>();
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldDeleteEmpresa()
        {
            // Arrange
            var command = new DeleteEmpresaCommand(1);
            _mockEmpresaService.Setup(s => s.Remover(It.IsAny<int>())).Returns(Task.CompletedTask);
            var handler = new DeleteEmpresaCommandHandler(_mockEmpresaService.Object);

            // Act
            await handler.Handle(command, new CancellationToken());

            // Assert
            _mockEmpresaService.Verify(s => s.Remover(1), Times.Once);
        }
    }
}
