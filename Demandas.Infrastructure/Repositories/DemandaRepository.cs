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
    public class DemandaRepository : IDemandaRepository
    {
        private readonly DemandasDb db;

        public DemandaRepository(DemandasDb dbContext)
        {
            db = dbContext;
        }

        public async Task<Demanda> AtualizarAsync(Demanda entity)
        {
            db.Demandas.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<Demanda> BuscarPorIdAsync(int id)
        {
            return await db.Demandas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async void Deletar(int id)
        {
            var entity = await db.Demandas.SingleOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                db.Demandas.Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Demanda>> ListarQueryAsync(Expression<Func<Demanda, bool>> expression)
        {
            return await db.Demandas.Where(expression).ToListAsync();
        }

        public async Task<Demanda> SalvarAsync(Demanda entity)
        {
            await db.Demandas.AddAsync(entity);
            await db.SaveChangesAsync();


            return entity;
        }
    }
}
