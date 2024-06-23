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
    public class ChangeUsuarioPasswordCommandHandlerTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly ChangeUsuarioPasswordCommandHandler _handler;

        public ChangeUsuarioPasswordCommandHandlerTest()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _handler = new ChangeUsuarioPasswordCommandHandler(_mockUsuarioService.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldChangePassword()
        {
            // Arrange
            var dto = new UsuarioAlterarSenhaDTO
            {
                Login = "user",
                Senha = "oldPassword",
                NovaSenha = "newPassword",
                ConfirmacaoNovaSenha = "newPassword"
            };
            var command = ChangeUsuarioPasswordCommand.CriarPorDto(dto);
            _mockUsuarioService.Setup(s => s.ValidarSenha(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            _mockUsuarioService.Setup(s => s.BuscaPorLogin(It.IsAny<string>())).ReturnsAsync(new UsuarioDto { Id = 1 });
            _mockUsuarioService.Setup(s => s.AtualizarSenha(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result);
        }
    }
}
