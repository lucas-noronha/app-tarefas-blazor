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
        ICollection<T> ListarQuery(Expression<Func<T, bool>> expression);

        T  BuscarPorId(int id);

        T Salvar(T entity);

        T Atualizar(T entity);

        void Deletar(int id);
    }
}
