using Entities.BaseAggregate.Concrete;
using Entities.Domain;

namespace Entities.Entities
{
    public class Rules : BaseEntity
    {
        public string Rule { get; private set; }

        public Guid EventId { get; private set; }
        public Event Event { get; private set; }

        public Rules()
        {
        }

        public Rules(string rule, Guid eventId)
        {
            Rule = rule;
            EventId = eventId;
        }

        public void Update(string rule, Guid eventId)
        {
            Rule = rule;
            EventId = eventId;
        }
    }
}