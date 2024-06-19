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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DemandasDb db;

        public UsuarioRepository(DemandasDb dbContext)
        {
            db = dbContext;
        }

        public async Task<Usuario> BuscarPorLogin(string login)
        {
            return await db.Usuarios.SingleOrDefaultAsync(x => x.Login == login);
        }

        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            return await db.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ICollection<Usuario>> ListarQueryAsync(Expression<Func<Usuario, bool>> expression)
        {
            return await db.Usuarios.Where(expression).ToListAsync();
        }
        public async Task<Usuario> AtualizarAsync(Usuario entity)
        {
            db.Usuarios.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async void Deletar(int id)
        {
            var usu = await db.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
            if(usu != null)
            {
                db.Usuarios.Remove(usu);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Usuario> SalvarAsync(Usuario entity)
        {
            await db.Usuarios.AddAsync(entity);
            await db.SaveChangesAsync();


            return entity;
        }
    }


}
