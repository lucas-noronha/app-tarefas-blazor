using Demandas.Application.CQRS.Usuario.Queries.Handlers;
using Demandas.Application.CQRS.Usuario.Queries;
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
    public class GetUsuarioByIdQueryHandlerTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly GetUsuarioByIdQueryHandler _handler;

        public GetUsuarioByIdQueryHandlerTest()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _handler = new GetUsuarioByIdQueryHandler(_mockUsuarioService.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUsuarioById()
        {
            // Arrange
            var usuarioDto = new UsuarioDto { Id = 1 };
            _mockUsuarioService.Setup(s => s.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(usuarioDto);

            // Act
            var result = await _handler.Handle(new GetUsuarioByIdQuery(1), new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
