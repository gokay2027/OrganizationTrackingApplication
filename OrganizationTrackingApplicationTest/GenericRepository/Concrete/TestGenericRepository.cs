using Entities.BaseAggregate.Concrete;
using Microsoft.EntityFrameworkCore;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using System.Linq.Expressions;

namespace OrganizationTrackingApplicationData.GenericRepository.Concrete
{
    public class TestGenericRepository<T> : ITestGenericRepository<T> where T : BaseEntity
    {
        private readonly OrganizationTrackingApplicationDbContext _context = null;

        public TestGenericRepository(OrganizationTrackingApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid id)
        {
            _context.Set<T>().First(a => a.Id == id).Delete();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _context.Set<T>()
                .Where(a => a.IsDeleted.Equals(false))
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
        }

        public async Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<T> GetById(Guid id)
        {
            return _context.Set<T>().First(a => a.Id.Equals(id));
        }

        public async Task Insert(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<DbSet<T>> GetSet()
        {
            return _context.Set<T>();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}