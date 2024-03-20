using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Event : BaseEntity
    {
        public string Name { get; private set; }
        
        public DateTime DateTime { get; private set; }

        public Event(string name, DateTime dateTime)
        {
            Name = name;
            DateTime = dateTime;
        }
    }
}