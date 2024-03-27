using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Organizator : BaseEntity
    {
        public string Name { get; private set; }
        public List<Event> Events { get; private set; } = new List<Event>();

        public Organizator()
        {
        }

        public Organizator(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}