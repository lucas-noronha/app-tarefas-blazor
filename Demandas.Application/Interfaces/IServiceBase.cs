using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Interfaces
{
    public interface IServiceBase<T> where T : class
    {

        Task<ICollection<T>> BuscarListaComQueryAsync(Expression<Func<T, bool>> expression);

        Task<ICollection<T>> BuscarListaAsync();
        Task<T> BuscarPorIdAsync(int id);

        Task<T> Adicionar(T dto);

        Task<T> Atualizar(T dto);

        Task Remover(int id);
    }
}
