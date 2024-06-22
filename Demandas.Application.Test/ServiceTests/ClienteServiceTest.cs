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

namespace Demandas.Application.Test.ServiceTests
{
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
            var clientesDto = clientes.Select(c => new ClienteDto { Nome = c.Nome, Contato = c.Contato }).ToList();

            _mockClienteRepository.Setup(repo => repo.ListarQueryAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Cliente, bool>>>())).ReturnsAsync(clientes);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ClienteDto>>(It.IsAny<IEnumerable<Cliente>>())).Returns(clientesDto);


            // Act
            var result = await _clienteService.BuscarListaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientes.Count, result.Count());
        }

        // Teste para o método Adicionar
        [Fact]
        [Trait("Categoria", "Adicionar Cliente")]
        public async Task Adicionar_DeveAdicionarCliente()
        {
            // Arrange
            var clienteDto = new ClienteDto { Nome = "Novo Cliente", Contato = "email@teste.com" };
            var cliente = new Cliente("Novo Cliente", "email@teste.com", 1, 1);
            _mockMapper.Setup(mapper => mapper.Map<Cliente>(clienteDto)).Returns(cliente);
            _mockMapper.Setup(mapper => mapper.Map<ClienteDto>(cliente)).Returns(clienteDto);
            _mockClienteRepository.Setup(repo => repo.SalvarAsync(cliente)).ReturnsAsync(cliente);

            // Act
            var result = await _clienteService.Adicionar(clienteDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clienteDto.Nome, result.Nome);
            _mockClienteRepository.Verify(repo => repo.SalvarAsync(It.IsAny<Cliente>()), Times.Once);
        }

        // Teste para o método Atualizar
        [Fact]
        [Trait("Categoria", "Atualizar Cliente")]
        public async Task Atualizar_DeveAtualizarCliente()
        {
            // Arrange
            var clienteDto = new ClienteDto { Nome = "Cliente Atualizado", Contato = "email@update.com" };
            var cliente = new Cliente("Cliente Atualizado", "email@update.com", 1, 1);
            _mockMapper.Setup(mapper => mapper.Map<Cliente>(clienteDto)).Returns(cliente);
            _mockMapper.Setup(mapper => mapper.Map<ClienteDto>(cliente)).Returns(clienteDto);
            _mockClienteRepository.Setup(repo => repo.AtualizarAsync(cliente)).ReturnsAsync(cliente);

            // Act
            var result = await _clienteService.Atualizar(clienteDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clienteDto.Nome, result.Nome);
            _mockClienteRepository.Verify(repo => repo.AtualizarAsync(It.IsAny<Cliente>()), Times.Once);
        }

        // Teste para o método BuscarPorIdAsync
        [Fact]
        [Trait("Categoria", "Buscar Cliente Por ID")]
        public async Task BuscarPorIdAsync_DeveRetornarClientePorId()
        {
            // Arrange
            var cliente = new Cliente("Cliente Existente", "email@existente.com", 1, 1);
            var clienteDto = new ClienteDto { Nome = cliente.Nome, Contato = cliente.Contato };
            _mockClienteRepository.Setup(repo => repo.BuscarPorIdAsync(1)).ReturnsAsync(cliente);
            _mockMapper.Setup(mapper => mapper.Map<ClienteDto>(cliente)).Returns(clienteDto);

            // Act
            var result = await _clienteService.BuscarPorIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cliente.Nome, result.Nome);
            _mockClienteRepository.Verify(repo => repo.BuscarPorIdAsync(It.IsAny<int>()), Times.Once);
        }

        // Teste para o método Remover
        [Fact]
        [Trait("Categoria", "Remover Cliente")]
        public async Task Remover_DeveRemoverCliente()
        {
            // Arrange
            var clienteId = 1;
            _mockClienteRepository.Setup(repo => repo.Deletar(clienteId));

            // Act
            await _clienteService.Remover(clienteId);

            // Assert
            _mockClienteRepository.Verify(repo => repo.Deletar(It.IsAny<int>()), Times.Once);
        }

    }

}
