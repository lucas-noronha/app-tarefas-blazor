using Demandas.Application.CQRS.Empresa.Commands.Handlers;
using Demandas.Application.CQRS.Empresa.Commands;
using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.CQRSTests.Empresa
{
    public class UpdateEmpresaCommandHandlerTest
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService;

        public UpdateEmpresaCommandHandlerTest()
        {
            _mockEmpresaService = new Mock<IEmpresaService>();
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldUpdateEmpresa()
        {
            // Arrange
            EmpresaDto empresaDto = new EmpresaDto { Id = 1 };
            var command = new UpdateEmpresaCommand(empresaDto);
            _mockEmpresaService.Setup(s => s.Atualizar(It.IsAny<EmpresaDto>())).ReturnsAsync(empresaDto);
            var handler = new UpdateEmpresaCommandHandler(_mockEmpresaService.Object);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
