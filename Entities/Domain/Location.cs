using Entities.BaseAggregate.Concrete;

namespace Entities.Entities
{
    public class Location : BaseEntity
    {
        public string Description { get; private set; }
        public string FormattedName { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }

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