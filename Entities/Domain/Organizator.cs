using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Organizator : BaseEntity
    {
        public string Name { get; private set; }
        public List<Event> Events { get; private set; } = new List<Event>();

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public Organizator()
        {
        }

        public Organizator(string name)
        {
            Name = name;
        }

        public Organizator(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}