using Entities.BaseAggregate.Concrete;

namespace Entities.Entities
{
    public class EventType : BaseEntity
    {
        public string TypeName { get; private set; }

        public EventType(string typeName)
        {
            TypeName = typeName;
        }
    }
}