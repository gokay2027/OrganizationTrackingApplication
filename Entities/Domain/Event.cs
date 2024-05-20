using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Event : BaseEntity
    {
        public string Name { get; private set; }
        public DateTime EventTime { get; private set; }

        public Guid EventTypeId { get; private set; }
        public EventType EventType { get; private set; }

        public Guid OrganizatorId { get; private set; }
        public Organizator Organizator { get; private set; }

        public Guid LocationId { get; private set; }
        public Location Location { get; private set; }

        public bool IsCompleted { get; private set; } = false;

        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public List<Rules> Rules { get; private set; } = new List<Rules>();
        public List<Rating> Ratings { get; private set; } = new List<Rating>();

        public Event()
        {
        }

        public Event(string name, DateTime eventTime, Guid locationId, Guid eventTypeId, Guid organizatorId)
        {
            Name = name;
            EventTime = eventTime;
            LocationId = locationId;
            EventTypeId = eventTypeId;
            OrganizatorId = organizatorId;
        }

        public Event(string name, DateTime eventTime, Guid locationId, Guid eventTypeId, Guid organizatorId,int price,int ticketNumber)
        {
            Name = name;
            EventTime = eventTime;
            LocationId = locationId;
            EventTypeId = eventTypeId;
            OrganizatorId = organizatorId;

            for(int i = 0; i < ticketNumber; i++)
            {
                Ticket t = new Ticket(price,Id);
                Tickets.Add(t);
            }
        }

        public void Update(string name, DateTime eventTime, Guid locationId, Guid eventTypeId, Guid organizatorId)
        {
            Name = name;
            EventTime = eventTime;
            LocationId = locationId;
            EventTypeId = eventTypeId;
            OrganizatorId = organizatorId;
        }

        public void CompleteEvent()
        {
            IsCompleted = true;
        }

        public void AddCreatedTicketForEvent(int ticketNumber, int price)
        {
            for (int i = 0; i < ticketNumber; i++)
            {
                Ticket ticket = new(price, this.Id);
                Tickets.Add(ticket);
            }
        }

        public void AddRulesForEvent(List<string> rules)
        {
            foreach (string rule in rules)
            {
                Rules.Add(new Rules(rule, this.Id));
            }
        }

        public void AddRuleToEvent(string rule)
        {
            Rules.Add(new Domain.Rules(rule, this.Id));
        }
    }
}