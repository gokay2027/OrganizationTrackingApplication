using Entities.BaseAggregate.Concrete;
using Entities.Domain;

namespace Entities.Entities
{
    public class EventType : BaseEntity
    {
        public string TypeName { get; private set; }

        public List<Event> Events { get; private set; } = new List<Event>();

        public EventType(string typeName)
        {
            TypeName = typeName;
        }
    }
}