using Entities.BaseAggregate.Abstract;

namespace Entities.BaseAggregate.Concrete
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime CreatedDate = DateTime.Now;

        public DateTime UpdatedDate = DateTime.Now;

        public bool IsDeleted = false;

        public void Delete()
        {
            IsDeleted = true;
        }

        public void UpdateDate()
        {
            UpdatedDate = DateTime.Now;
        }
    }
}