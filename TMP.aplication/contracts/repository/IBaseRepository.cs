using System.Linq.Expressions;
using TMP.aplication.response.db;
using TPM.domain.commons;

namespace TMP.aplication.contracts.repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {

        Task<DbResponse> GetAllAsync();
        Task<DbResponse> GetAsync(Expression<Func<T, bool>> predicate);
        Task<DbResponse> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disabledTracking = true
                                        );
       Task<DbResponse> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<Expression<Func<T, object>>> includes = null,
                                        bool disabledTracking = true
                                        );
        Task<DbResponse> GetByIdAsync(int id);
        Task<DbResponse> AddAsync(T entity);
        Task<DbResponse> UpdateAsync(T entity);
        Task<DbResponse> DeleteAsync(T entity);
    }
}

