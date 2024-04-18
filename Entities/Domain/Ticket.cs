using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Ticket : BaseEntity
    {
        public float Price { get; private set; }

        public Guid? OwnerId { get; private set; }
        public User? Owner { get; private set; }

        public Guid EventId { get; private set; }
        public Event Event { get; private set; }

        public bool IsAvailable { get; private set; } = true;

        public Ticket()
        {
        }

        public Ticket(float price, Guid ownerId, Guid eventId)
        {
            Price = price;
            OwnerId = ownerId;
            EventId = eventId;
        }

        public Ticket(float price, Guid eventId)
        {
            Price = price;
            EventId = eventId;
        }

        public void Update(float price, Guid ownerId, Guid eventId)
        {
            Price = price;
            OwnerId = ownerId;
            EventId = eventId;
        }

        /// <summary>
        /// Buy ticket
        /// </summary>
        /// <param name="ownerId"></param>
        public void BuyTicket(Guid ownerId)
        {
            OwnerId = ownerId;
            IsAvailable = false;
        }
    }
}