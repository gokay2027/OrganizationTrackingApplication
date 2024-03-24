using Entities.BaseAggregate.Concrete;
using Microsoft.EntityFrameworkCore;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using System.Linq.Expressions;

namespace OrganizationTrackingApplicationData.GenericRepository.Concrete
{
    public class GenericRepostory<T> : IGenericRepository<T> where T : BaseEntity
    {
        private OrganizationTrackingApplicationDbContext _context = null;

        public GenericRepostory(OrganizationTrackingApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            _context.Set<T>().First(a => a.Id == id).Delete();
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().First(a => a.Id.Equals(id));
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public DbSet<T> GetSet()
        {
            return _context.Set<T>();
        }
    }
}