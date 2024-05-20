using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Rating : BaseEntity
    {
        public Guid? UserId { get; private set; }
        public User User { get; private set; }

        public Guid EventId { get; private set; }
        public Event Event { get; private set; }

        public int Rate { get; private set; }
        public string Comment { get; private set; }

        public Rating()
        {
        }

        public Rating(Guid? userId, int rate, string comment, Guid eventId)
        {
            UserId = userId;
            Rate = rate;
            EventId = eventId;
            Comment = comment;
        }

        public void Update(Guid userId, int rate, string comment, Guid eventId)
        {
            UserId = userId;
            Rate = rate;
            EventId = eventId;
            Comment = comment;
        }
    }
}