using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using Demandas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Demandas.Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DemandasDb db;

        public EmpresaRepository(DemandasDb dbContext)
        {
            db = dbContext;
        }

        public async Task<Empresa> AtualizarAsync(Empresa entity)
        {
            db.Empresas.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<Empresa> BuscarPorIdAsync(int id)
        {
            return await db.Empresas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async void DeletarAsync(int id)
        {
            var entity = await db.Empresas.SingleOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                db.Empresas.Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Empresa>> ListarQueryAsync(Expression<Func<Empresa, bool>> expression)
        {
            return await db.Empresas.Where(expression).ToListAsync();
        }

        public async Task<Empresa> SalvarAsync(Empresa entity)
        {
            await db.Empresas.AddAsync(entity);
            await db.SaveChangesAsync();


            return entity;
        }
    }
}
