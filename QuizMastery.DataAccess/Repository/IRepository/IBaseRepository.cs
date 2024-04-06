using System.Linq.Expressions;

namespace QuizMastery.DataAccess.Repository.IRepository;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true);
    Task RemoveAsync(T entity);
    Task SaveAsync();
    Task<T> UpdateAsync(T entity);
}
