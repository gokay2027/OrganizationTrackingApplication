using Entities.BaseAggregate.Concrete;
using Entities.Entities;

namespace Entities.Domain
{
    public class Event : BaseEntity
    {
        public string Name { get; private set; }
        public DateTime DateTime { get; private set; }

        public Guid EventTypeId { get; private set; }
        public EventType EventType { get; private set; }

        public Guid OrganizatorId { get; private set; }
        public Organizator Organizator { get; private set; }

        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }

        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public List<Rules> Rules { get; private set; } = new List<Rules>();
        public List<Rating> Ratings { get; private set; } = new List<Rating>();

        public Event()
        {
        }

        public Event(string name, DateTime dateTime, Guid locationId, Guid eventTypeId, Guid organizatorId)
        {
            Name = name;
            DateTime = dateTime;
            LocationId = locationId;
            EventTypeId = eventTypeId;
            OrganizatorId = organizatorId;
        }
    }
}