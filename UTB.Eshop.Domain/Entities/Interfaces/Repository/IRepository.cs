using System.Linq.Expressions;

namespace UTB.Eshop.Domain.Entities.Interfaces.Repository
{
    public interface IRepository<T, TKey> where T : IEntity<TKey> where TKey : notnull
    {
        T? GetById(TKey id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
