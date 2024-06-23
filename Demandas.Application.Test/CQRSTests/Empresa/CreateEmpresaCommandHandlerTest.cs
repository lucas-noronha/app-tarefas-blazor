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
    public class CreateEmpresaCommandHandlerTest
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService;

        public CreateEmpresaCommandHandlerTest()
        {
            _mockEmpresaService = new Mock<IEmpresaService>();
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldCreateEmpresa()
        {
            // Arrange
            EmpresaDto empresaDto = new EmpresaDto { Id = 1 };
            var command = new CreateEmpresaCommand(empresaDto);
            _mockEmpresaService.Setup(s => s.Adicionar(It.IsAny<EmpresaDto>())).ReturnsAsync(empresaDto);
            var handler = new CreateEmpresaCommandHandler(_mockEmpresaService.Object);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(1, result);
        }
    }
}
