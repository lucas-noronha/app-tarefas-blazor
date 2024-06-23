using Demandas.Domain.Entities;
using Demandas.Infrastructure.Context;
using Demandas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Infrastructure.Test
{
    public class ClienteRepositoryTests : IDisposable
    {
        private readonly DemandasDb _context;
        private readonly ClienteRepository _repository;

        public ClienteRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DemandasDb>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usar um novo banco de dados para cada teste
                .Options;
            _context = new DemandasDb(options);
            _repository = new ClienteRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted(); // Garantir que o banco de dados seja limpo após cada teste
            _context.Dispose();
        }

        [Fact]
        public async Task SalvarAsync_ShouldAddEntity()
        {
            var cliente = new Cliente("Cliente Teste", "email@teste.com", 1, 1);

            await _repository.SalvarAsync(cliente);

            Assert.Equal(1, _context.Clientes.Count());
            Assert.Contains(_context.Clientes, c => c.Nome == "Cliente Teste");
        }

        [Fact]
        public async Task AtualizarAsync_ShouldUpdateEntity()
        {
            var cliente = new Cliente("Cliente Original", "email@original.com", 1, 1);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            cliente.AtualizarEntidade("Cliente Atualizado", cliente.Contato, cliente.EmpresaId, cliente.UsuarioUltimaEdicaoId);
            await _repository.AtualizarAsync(cliente);

            Assert.Equal("Cliente Atualizado", _context.Clientes.First().Nome);
        }

        [Fact]
        public async Task Deletar_ShouldRemoveEntity()
        {
            var cliente = new Cliente("Cliente Para Deletar", "email@deletar.com", 1, 1);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            _repository.Deletar(cliente.Id);

            Assert.Empty(_context.Clientes);
        }

        [Fact]
        public async Task BuscarPorIdAsync_ShouldReturnEntity()
        {
            var cliente = new Cliente("Cliente Busca", "email@busca.com", 1, 1);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var result = await _repository.BuscarPorIdAsync(cliente.Id);

            Assert.NotNull(result);
            Assert.Equal("Cliente Busca", result.Nome);
        }

        [Fact]
        public async Task ListarQueryAsync_ShouldReturnEntities()
        {
            _context.Clientes.Add(new Cliente("Cliente 1", "email1@listar.com", 1, 1));
            _context.Clientes.Add(new Cliente("Cliente 2", "email2@listar.com", 1, 1));
            await _context.SaveChangesAsync();

            var result = await _repository.ListarQueryAsync(c => c.Id > 0);

            Assert.Equal(2, result.Count);
        }
    }
}
