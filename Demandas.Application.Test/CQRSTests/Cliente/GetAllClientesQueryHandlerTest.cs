using AutoMapper;
using Demandas.Application.CQRS.Cliente.Queries.Handlers;
using Demandas.Application.CQRS.Cliente.Queries;
using Demandas.Application.DTOs;
using Demandas.Domain.Interfaces;
using Demandas.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demandas.Application.Services;

namespace Demandas.Application.Test.CQRSTests.Cliente
{
    public class GetAllClientesQueryHandlerTest
    {
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ClienteService _clienteService;
        public GetAllClientesQueryHandlerTest()
        {
            _mockClienteRepository = new Mock<IClienteRepository>();
            _mockMapper = new Mock<IMapper>();
            _clienteService = new ClienteService(_mockMapper.Object, _mockClienteRepository.Object);
        }

        [Fact]
        public async Task Handle_DeveRetornarTodosClientes()
        {
            // Arrange
            var query = new GetAllClientesQuery();
            var clientes = new List<Domain.Entities.Cliente> { /* Lista de Clientes */ };
            var clientesDto = clientes.Select(c => new ClienteDto { /* Propriedades do DTO */ }).ToList();
            _mockClienteRepository.Setup(r => r.ListarQueryAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Domain.Entities.Cliente, bool>>>())).ReturnsAsync(clientes);
            _mockMapper.Setup(m => m.Map<IEnumerable<ClienteDto>>(It.IsAny<IEnumerable<Domain.Entities.Cliente>>())).Returns(clientesDto);

            var handler = new GetAllClientesQueryHandler(_clienteService);

            // Act
            var result = await handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientes.Count, result.Count());
        }
    }
}
