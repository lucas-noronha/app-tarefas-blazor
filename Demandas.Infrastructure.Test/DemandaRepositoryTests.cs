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
    public class DemandaRepositoryTests : IDisposable
    {
        private readonly DemandasDb _context;
        private readonly DemandaRepository _repository;

        public DemandaRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DemandasDb>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usar um novo banco de dados para cada teste
                .Options;
            _context = new DemandasDb(options);
            _repository = new DemandaRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted(); // Garantir que o banco de dados seja limpo após cada teste
            _context.Dispose();
        }

        [Fact]
        public async Task SalvarAsync_ShouldAddEntity()
        {
            var demanda = new Demanda(
                "Demanda Numero 1", 
                "Uma demanda para fins de teste", 
                Domain.Enums.EnumStatusDemanda.Adicionada, 
                Domain.Enums.EnumTipoDemanda.Bug,
                1,
                true,
                true,
                1,
                1);
            
            await _repository.SalvarAsync(demanda);

            Assert.Equal(1, _context.Demandas.Count());
            Assert.Contains(_context.Demandas, d => d.Titulo == "Demanda Numero 1");
        }

        [Fact]
        public async Task AtualizarAsync_ShouldUpdateEntity()
        {
            var demanda = new Demanda(
                "Demanda Numero 1",
                "Uma demanda para fins de teste",
                Domain.Enums.EnumStatusDemanda.Adicionada,
                Domain.Enums.EnumTipoDemanda.Bug,
                1,
                true,
                true,
                1,
                1);
            _context.Demandas.Add(demanda);
            await _context.SaveChangesAsync();

            demanda.AtualizarEntidade(
                "Título Atualizado",
                "Descrição Atualizada",
                null,
                Domain.Enums.EnumStatusDemanda.EmAndamento,
                Domain.Enums.EnumTipoDemanda.Melhoria,
                true,
                true,
                1,
                1,
                1,
                1
                );
            await _repository.AtualizarAsync(demanda);

            Assert.Equal("Título Atualizado", _context.Demandas.First().Titulo);
        }

        [Fact]
        public async Task Deletar_ShouldRemoveEntity()
        {
            var demanda = new Demanda(
                "Demanda Numero 1",
                "Uma demanda para fins de teste",
                Domain.Enums.EnumStatusDemanda.Adicionada,
                Domain.Enums.EnumTipoDemanda.Bug,
                1,
                true,
                true,
                1,
                1);
            _context.Demandas.Add(demanda);
            await _context.SaveChangesAsync();

            _repository.Deletar(demanda.Id);

            Assert.Empty(_context.Demandas);
        }

        [Fact]
        public async Task BuscarPorIdAsync_ShouldReturnEntity()
        {
            var demanda = new Demanda(
                "Demanda Numero 1",
                "Uma demanda para fins de teste",
                Domain.Enums.EnumStatusDemanda.Adicionada,
                Domain.Enums.EnumTipoDemanda.Bug,
                1,
                true,
                true,
                1,
                1);
            _context.Demandas.Add(demanda);
            await _context.SaveChangesAsync();

            var result = await _repository.BuscarPorIdAsync(demanda.Id);

            Assert.NotNull(result);
            Assert.Equal("Demanda Numero 1", result.Titulo);
        }

        [Fact]
        public async Task ListarQueryAsync_ShouldReturnEntities()
        {
            _context.Demandas.Add(new Demanda(
                "Demanda Numero 1",
                "Uma demanda para fins de teste",
                Domain.Enums.EnumStatusDemanda.Adicionada,
                Domain.Enums.EnumTipoDemanda.Bug,
                1,
                true,
                true,
                1,
                1));
            _context.Demandas.Add(new Demanda(
                "Demanda Numero 2",
                "Uma demanda para fins de teste 2",
                Domain.Enums.EnumStatusDemanda.Concluida,
                Domain.Enums.EnumTipoDemanda.Melhoria,
                1,
                true,
                true,
                1,
                1));
            await _context.SaveChangesAsync();

            var result = await _repository.ListarQueryAsync(d => d.Id > 0);

            Assert.Equal(2, result.Count);
        }
    }
}
