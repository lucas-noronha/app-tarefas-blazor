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
    public class GetAllUsuariosQueryHandlerTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly GetAllUsuariosQueryHandler _handler;

        public GetAllUsuariosQueryHandlerTest()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _handler = new GetAllUsuariosQueryHandler(_mockUsuarioService.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllUsuarios()
        {
            // Arrange
            _mockUsuarioService.Setup(s => s.BuscarListaAsync()).ReturnsAsync(new List<UsuarioDto>());

            // Act
            var result = await _handler.Handle(new GetAllUsuariosQuery(), new CancellationToken());

            // Assert
            Assert.NotNull(result);
        }
    }
}
