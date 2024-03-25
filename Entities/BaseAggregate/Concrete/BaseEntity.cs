using Entities.BaseAggregate.Abstract;

namespace Entities.BaseAggregate.Concrete
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime CreatedDate { get; private set; } = DateTime.Now;

        public DateTime UpdatedDate { get; private set; } = DateTime.Now;

        public bool IsDeleted { get; private set; }  = false;

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