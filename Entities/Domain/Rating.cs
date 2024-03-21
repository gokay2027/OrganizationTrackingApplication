using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Rating : BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Guid EventId { get; private set; }
        public Event Event { get; private set; }

        public int Rate { get; private set; }

        public Rating()
        {
        }

        public Rating(Guid userId, int rate, Guid eventId)
        {
            UserId = userId;
            Rate = rate;
            EventId = eventId;
        }

        public void UpdateRating(Guid userId, int rate, Guid eventId)
        {
            UserId = userId;
            Rate = rate;
            EventId = eventId;
        }
    }
}