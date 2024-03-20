using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Rating : BaseEntity
    {
        public int Rate { get; private set; }
    }
}