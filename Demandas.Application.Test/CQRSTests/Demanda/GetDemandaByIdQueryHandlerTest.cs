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
    public class GetDemandaByIdQueryHandlerTest
    {
        private readonly Mock<IDemandaService> _mockDemandaService;

        public GetDemandaByIdQueryHandlerTest()
        {
            _mockDemandaService = new Mock<IDemandaService>();
        }

        [Fact]
        public async Task Handle_ShouldReturnDemandaById()
        {
            // Arrange
            var demandaDto = new DemandaDto { Id = 1 };
            _mockDemandaService.Setup(s => s.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(demandaDto);
            var handler = new GetDemandaByIdQueryHandler(_mockDemandaService.Object);

            // Act
            var result = await handler.Handle(new GetDemandaByIdQuery(1), new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
