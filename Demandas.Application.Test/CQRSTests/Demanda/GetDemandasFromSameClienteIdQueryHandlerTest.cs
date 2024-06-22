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
using System.Linq.Expressions;

namespace Demandas.Application.Test.CQRSTests.Demanda
{
    public class GetDemandasFromSameClienteIdQueryHandlerTest
    {
        private readonly Mock<IDemandaService> _mockDemandaService;

        public GetDemandasFromSameClienteIdQueryHandlerTest()
        {
            _mockDemandaService = new Mock<IDemandaService>();
        }

        [Fact]
        public async Task Handle_ShouldReturnDemandasFromSameClienteId()
        {
            // Arrange
            var demandas = new List<DemandaDto> { new DemandaDto { Id = 1 } };
            _mockDemandaService.Setup(s => s.BuscarListaComQueryAsync(It.IsAny<Expression<Func<DemandaDto, bool>>>())).ReturnsAsync(demandas);
            var handler = new GetDemandasFromSameClienteIdQueryHandler(_mockDemandaService.Object);

            // Act
            var result = await handler.Handle(new GetDemandasFromSameClienteIdQuery(1), new CancellationToken());

            // Assert
            Assert.Single(result);
        }
    }
}
