using Entities.BaseAggregate.Concrete;
using Microsoft.EntityFrameworkCore;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationData.GenericRepository.Concrete
{
    public class GenericRepostory : IGenericRepository<BaseEntity>
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(BaseEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(BaseEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}