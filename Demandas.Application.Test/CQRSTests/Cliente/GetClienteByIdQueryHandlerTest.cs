using AutoMapper;
using Demandas.Application.CQRS.Cliente.Queries;
using Demandas.Application.CQRS.Cliente.Queries.Handlers;
using Demandas.Application.DTOs;
using Demandas.Application.Services;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.CQRSTests.Cliente
{
    public class GetClienteByIdQueryHandlerTest
    {
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ClienteService _clienteService;

        public GetClienteByIdQueryHandlerTest()
        {
            _mockClienteRepository = new Mock<IClienteRepository>();
            _mockMapper = new Mock<IMapper>();
            _clienteService = new ClienteService(_mockMapper.Object, _mockClienteRepository.Object);
        }

        [Fact]
        public async Task Handle_DadoId_DeveRetornarCliente()
        {
            // Arrange
            var query = new GetClienteByIdQuery(1);
            var cliente = new Domain.Entities.Cliente("Cliente 1", "email@email.com", 1, 1);
            var clienteDto = new ClienteDto { /* Propriedades do DTO */ };
            _mockClienteRepository.Setup(r => r.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(cliente);
            _mockMapper.Setup(m => m.Map<ClienteDto>(It.IsAny<Domain.Entities.Cliente>())).Returns(clienteDto);

            var handler = new GetClienteByIdQueryHandler(_clienteService);

            // Act
            var result = await handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clienteDto, result);
        }
    }
}
