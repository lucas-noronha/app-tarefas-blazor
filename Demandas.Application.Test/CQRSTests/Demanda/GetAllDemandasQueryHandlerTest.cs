using Demandas.Application.CQRS.Demanda.Queries.Handlers;
using Demandas.Application.CQRS.Demanda.Queries;
using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.CQRSTests.Demanda
{
    public class GetAllDemandasQueryHandlerTest
    {
        private readonly Mock<IDemandaService> _mockDemandaService;

        public GetAllDemandasQueryHandlerTest()
        {
            _mockDemandaService = new Mock<IDemandaService>();
        }

        [Fact]
        public async Task Handle_ShouldReturnAllDemandas()
        {
            // Arrange
            var demandas = new List<DemandaDto> { new DemandaDto { Id = 1 }, new DemandaDto { Id = 2 } };
            _mockDemandaService.Setup(s => s.BuscarListaAsync()).ReturnsAsync(demandas);
            var handler = new GetAllDemandasQueryHandler(_mockDemandaService.Object);

            // Act
            var result = await handler.Handle(new GetAllDemandasQuery(), new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
