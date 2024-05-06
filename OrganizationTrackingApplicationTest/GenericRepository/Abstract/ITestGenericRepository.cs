using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OrganizationTrackingApplicationData.GenericRepository.Abstract
{
    //Here, we are creating the IGenericRepository interface as a Generic Interface
    //Here, we are applying the Generic Constraint
    //The constraint is, T is going to be a class
    public interface ITestGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task Insert(T obj);

        Task Update(T obj);

        Task Delete(Guid id);

        Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> predicate);

        Task<DbSet<T>> GetSet();

        Task SaveChangesAsync();
    }
}