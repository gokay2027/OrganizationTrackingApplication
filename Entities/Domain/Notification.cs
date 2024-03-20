using Entities.BaseAggregate.Concrete;

namespace Entities.Entities
{
    public class Notification : BaseEntity
    {
        public string Topic { get; private set; }

        public string Content { get; private set; }

        public Notification(string topic, string content)
        {
            Topic = topic;
            Content = content;
        }
    }
}