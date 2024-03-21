using Entities.BaseAggregate.Concrete;
using Entities.Domain;

namespace Entities.Entities
{
    public class Organizator : BaseEntity
    {
        public string Name { get; private set; }
        public List<Event> Events { get; private set; } = new List<Event>();
    }
}