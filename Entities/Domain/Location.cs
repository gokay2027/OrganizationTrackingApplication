using Entities.BaseAggregate.Concrete;
using Entities.Domain;

namespace Entities.Entities
{
    public class Location : BaseEntity
    {
        public string Description { get; private set; }
        public string FormattedName { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }


        public List<Event> Events { get; private set; } = new List<Event>();
        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();

        public Location(string description, string formattedName, float latitude, float longitude)
        {
            Description = description;
            FormattedName = formattedName;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void Update(string desctiption, string formattedName, float latitude, float longitude)
        {
            Description = desctiption;
            FormattedName = formattedName;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void ChangeLocationDescription(string description)
        {
            Description = description;
        }
    }
}