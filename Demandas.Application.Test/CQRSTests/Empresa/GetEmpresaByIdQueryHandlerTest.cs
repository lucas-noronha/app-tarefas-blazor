using Demandas.Application.CQRS.Empresa.Queries.Handlers;
using Demandas.Application.CQRS.Empresa.Queries;
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
    public class GetEmpresaByIdQueryHandlerTest
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService;

        public GetEmpresaByIdQueryHandlerTest()
        {
            _mockEmpresaService = new Mock<IEmpresaService>();
        }

        [Fact]
        public async Task Handle_ShouldReturnEmpresaById()
        {
            // Arrange
            EmpresaDto empresaDto = new EmpresaDto { Id = 1 };
            _mockEmpresaService.Setup(s => s.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(empresaDto);
            var handler = new GetEmpresaByIdQueryHandler(_mockEmpresaService.Object);

            // Act
            var result = await handler.Handle(new GetEmpresaByIdQuery(1), new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
