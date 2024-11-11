using System.Linq.Expressions;

namespace Data.Repository.IRepository;

public interface IRepository<T> where T : class
{
    public T Get(Expression<Func<T, bool>> filter);
    public IEnumerable<T> GetAll();
    void Add(T entity); 
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);

}