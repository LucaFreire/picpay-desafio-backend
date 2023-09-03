
using System.Linq.Expressions;

namespace picpay_desafio_backend.Respositories;

public interface IRepository<T>
{
    Task<bool> Create(T entity);
    Task<bool> Delete(T entity);
    Task<bool> Update(T entity);
    Task<List<T>> Filter(Expression<Func<T, bool>> expression);
}