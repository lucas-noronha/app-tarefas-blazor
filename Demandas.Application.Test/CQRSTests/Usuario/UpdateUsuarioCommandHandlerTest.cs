using Demandas.Application.CQRS.Usuario.Commands.Handlers;
using Demandas.Application.CQRS.Usuario.Commands;
using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.CQRSTests.Usuario
{
    public class UpdateUsuarioCommandHandlerTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly UpdateUsuarioCommandHandler _handler;

        public UpdateUsuarioCommandHandlerTest()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _handler = new UpdateUsuarioCommandHandler(_mockUsuarioService.Object);
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldUpdateUsuario()
        {
            // Arrange
            var command = new UpdateUsuarioCommand(new UsuarioDto());
            _mockUsuarioService.Setup(s => s.Atualizar(It.IsAny<UsuarioDto>())).ReturnsAsync(new UsuarioDto());

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
        }
    }
}
