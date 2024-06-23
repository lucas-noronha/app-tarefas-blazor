using Demandas.Domain.Entities;
using Demandas.Infrastructure.Context;
using Demandas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Demandas.Infrastructure.Test
{
    public class EmpresaRepositoryTests : IDisposable
    {
        private readonly DemandasDb _context;
        private readonly EmpresaRepository _repository;

        public EmpresaRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DemandasDb>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usar um novo banco de dados para cada teste
                .Options;
            _context = new DemandasDb(options);
            _repository = new EmpresaRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted(); // Garantir que o banco de dados seja limpo após cada teste
            _context.Dispose();
        }

        [Fact]
        public async Task SalvarAsync_ShouldAddEntity()
        {
            var empresa = new Empresa("Empresa Teste", "Descrição da Empresa Teste", 1);

            await _repository.SalvarAsync(empresa);

            Assert.Equal(1, _context.Empresas.Count());
            Assert.Contains(_context.Empresas, e => e.Nome == "Empresa Teste");
        }

        [Fact]
        public async Task AtualizarAsync_ShouldUpdateEntity()
        {
            var empresa = new Empresa("Empresa Original", "Descrição Original", 1);
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            empresa.AtualizarEntidade("Empresa Atualizada", empresa.Logo, empresa.UsuarioUltimaEdicaoId);
            await _repository.AtualizarAsync(empresa);

            Assert.Equal("Empresa Atualizada", _context.Empresas.First().Nome);
        }

        [Fact]
        public async Task Deletar_ShouldRemoveEntity()
        {
            var empresa = new Empresa("Empresa Para Deletar", "Descrição Para Deletar", 1);
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            _repository.Deletar(empresa.Id);

            Assert.Empty(_context.Empresas);
        }

        [Fact]
        public async Task BuscarPorIdAsync_ShouldReturnEntity()
        {
            var empresa = new Empresa("Empresa Busca", "Descrição Busca", 1);
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            var result = await _repository.BuscarPorIdAsync(empresa.Id);

            Assert.NotNull(result);
            Assert.Equal("Empresa Busca", result.Nome);
        }

        [Fact]
        public async Task ListarQueryAsync_ShouldReturnEntities()
        {
            _context.Empresas.Add(new Empresa("Empresa 1", "Descrição 1", 1));
            _context.Empresas.Add(new Empresa("Empresa 2", "Descrição 2", 1));
            await _context.SaveChangesAsync();

            var result = await _repository.ListarQueryAsync(e => e.Id > 0);

            Assert.Equal(2, result.Count);
        }
    }
}