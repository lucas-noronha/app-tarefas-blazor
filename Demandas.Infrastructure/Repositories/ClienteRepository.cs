using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using Demandas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DemandasDb db;

        public ClienteRepository(DemandasDb dbContext)
        {
            db = dbContext;
        }
        public async Task<Cliente> AtualizarAsync(Cliente entity)
        {
            db.Clientes.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            return await db.Clientes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async void Deletar(int id)
        {
            var usu = await db.Clientes.SingleOrDefaultAsync(x => x.Id == id);
            if (usu != null)
            {
                db.Clientes.Remove(usu);
                await db.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Cliente>> ListarQueryAsync(Expression<Func<Cliente, bool>> expression)
        {
            return await db.Clientes.Where(expression).ToListAsync();
        }

        public async Task<Cliente> SalvarAsync(Cliente entity)
        {
            await db.Clientes.AddAsync(entity);
            await db.SaveChangesAsync();


            return entity;
        }
    }
}
