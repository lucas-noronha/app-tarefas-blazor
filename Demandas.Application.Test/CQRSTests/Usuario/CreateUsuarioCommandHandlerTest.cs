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
    public class CreateUsuarioCommandHandlerTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly CreateUsuarioCommandHandler _handler;

        public CreateUsuarioCommandHandlerTest()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _handler = new CreateUsuarioCommandHandler(_mockUsuarioService.Object);
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldCreateUsuario()
        {
            // Arrange
            var command = new CreateUsuarioCommand(new UsuarioDto());
            _mockUsuarioService.Setup(s => s.Adicionar(It.IsAny<UsuarioDto>())).ReturnsAsync(new UsuarioDto { Id = 1 });

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(1, result);
        }
    }
}
