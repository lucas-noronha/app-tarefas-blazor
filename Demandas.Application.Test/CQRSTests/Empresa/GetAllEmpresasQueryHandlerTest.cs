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
    public class GetAllEmpresasQueryHandlerTest
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService;

        public GetAllEmpresasQueryHandlerTest()
        {
            _mockEmpresaService = new Mock<IEmpresaService>();
        }

        [Fact]
        public async Task Handle_ShouldReturnAllEmpresas()
        {
            // Arrange
            var empresas = new List<EmpresaDto> { new EmpresaDto { Id = 1 } };
            _mockEmpresaService.Setup(s => s.BuscarListaAsync()).ReturnsAsync(empresas);
            var handler = new GetAllEmpresasQueryHandler(_mockEmpresaService.Object);

            // Act
            var result = await handler.Handle(new GetAllEmpresasQuery(), new CancellationToken());

            // Assert
            Assert.Single(result);
        }
    }
}
