using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Services.Abstarction
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IList<T> entities);
        Task<bool> DeleteAsync(string id);
        bool Update(T entity);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression=null);
        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> predicate,IList<string>includingItems=null);
    }
}