using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Application.Services;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class ClienteServiceTest
{
    private readonly ClienteService _clienteService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IClienteRepository> _mockClienteRepository;

    public ClienteServiceTest()
    {
        _mockMapper = new Mock<IMapper>();
        _mockClienteRepository = new Mock<IClienteRepository>();
        _clienteService = new ClienteService(_mockMapper.Object, _mockClienteRepository.Object);
    }

    [Fact]
    [Trait("Categoria", "Buscar Todos")]
    public async Task BuscarTodos_DeveRetornarTodosClientes()
    {
        // Arrange
        var clientes = new List<Cliente>
        {
            new Cliente("Cliente 1", "email1@teste.com", 1, 1),
            new Cliente("Cliente 2", "email2@teste.com", 2, 2)
        };
        var clientesDto = clientes.Select(c => new ClienteDto { Nome = c.Nome, Contato = c.Contato}).ToList();

        _mockClienteRepository.Setup(repo => repo.ListarQueryAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Cliente, bool>>>())).ReturnsAsync(clientes);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ClienteDto>>(It.IsAny<IEnumerable<Cliente>>())).Returns(clientesDto);
        
        
        // Act
        var result = await _clienteService.BuscarListaAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(clientes.Count, result.Count());
    }
}
