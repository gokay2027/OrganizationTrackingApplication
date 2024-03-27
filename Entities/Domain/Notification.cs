using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Notification : BaseEntity
    {
        public string Topic { get; private set; }

        public string Content { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Notification()
        {
        }

        public Notification(string topic, string content, Guid userId)
        {
            Topic = topic;
            Content = content;
            UserId = userId;
        }

        public void Update(string topic, string content, Guid userId)
        {
            Topic = topic;
            Content = content;
            UserId = userId;
        }
    }
}