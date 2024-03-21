using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class 
    {
        Task<ICollection<T>> ListarQueryAsync(Expression<Func<T, bool>> expression);

        Task<T> BuscarPorIdAsync(int id);

        Task<T> SalvarAsync(T entity);

        Task<T> AtualizarAsync(T entity);

        void DeletarAsync(int id);
    }
}
