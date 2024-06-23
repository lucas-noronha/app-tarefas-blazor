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
    public class UsuarioRepositoryTests : IDisposable
    {
        private readonly DemandasDb _context;
        private readonly UsuarioRepository _repository;

        public UsuarioRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DemandasDb>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usar um novo banco de dados para cada teste
                .Options;
            _context = new DemandasDb(options);
            _repository = new UsuarioRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted(); // Garantir que o banco de dados seja limpo após cada teste
            _context.Dispose();
        }

        [Fact]
        public async Task SalvarAsync_ShouldAddEntity()
        {
            var usuario = new Usuario("Usuario Numero 1", "loginTeste", "123senha321", "email@email.com", true, true, 1, 1);

            await _repository.SalvarAsync(usuario);

            Assert.Equal(1, _context.Usuarios.Count());
            Assert.Contains(_context.Usuarios, u => u.Login == "loginTeste");
        }

        [Fact]
        public async Task AtualizarAsync_ShouldUpdateEntity()
        {
            var usuario = new Usuario("Usuario Numero 1", "login1", "123senha321", "email@email.com", true, true, 1, 1);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            usuario.AtualizarEntidade("Usuario Numero 1 Att", "loginAtualizado", "123senha321", "emailatualizado@email", true, true, 1, 1);
            await _repository.AtualizarAsync(usuario);

            Assert.Equal("loginAtualizado", _context.Usuarios.First().Login);
        }

        [Fact]
        public async Task Deletar_ShouldRemoveEntity()
        {
            var usuario = new Usuario("Usuario Numero 1", "login1", "123senha321", "email@email.com", true, true, 1, 1);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            _repository.Deletar(usuario.Id);

            Assert.Empty(_context.Usuarios);
        }

        [Fact]
        public async Task BuscarPorIdAsync_ShouldReturnEntity()
        {
            var usuario = new Usuario("Usuario Numero 1", "loginBusca", "123senha321", "email@email.com", true, true, 1, 1);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var result = await _repository.BuscarPorIdAsync(usuario.Id);

            Assert.NotNull(result);
            Assert.Equal("loginBusca", result.Login);
        }

        [Fact]
        public async Task BuscarPorLoginAsync_ShouldReturnEntity()
        {
            var usuario = new Usuario("nomeUnico", "loginUnico", "123senha321", "email@email.com", true, true, 1, 1);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var result = await _repository.BuscarPorLoginAsync("loginUnico");

            Assert.NotNull(result);
            Assert.Equal("nomeUnico", result.Nome);
        }

        [Fact]
        public async Task ListarQueryAsync_ShouldReturnEntities()
        {
            _context.Usuarios.Add(new Usuario("Usuario Numero 1", "login1", "123senha321", "email@email.com", true, true, 1, 1));
            _context.Usuarios.Add(new Usuario("Usuario Numero 2", "login2", "123senha321se", "email1@email.com", false, false, 1, 1));
            await _context.SaveChangesAsync();

            var result = await _repository.ListarQueryAsync(u => u.Id > 0);

            Assert.Equal(2, result.Count);
        }
    }
}