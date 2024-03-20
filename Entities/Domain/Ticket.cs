using Entities.BaseAggregate.Concrete;

namespace Entities.Entities
{
    public class Ticket : BaseEntity
    {
        public float Price { get; private set; }
    }
}