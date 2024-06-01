using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.Event.GetEvents
{
    public class EventListModel : BaseListOutputModel
    {
        public List<EventListItem> EventList { get; set; } = new List<EventListItem>();
    }

    public class EventListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime EventTime { get; set; }

        public string EventDescription { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorNameSurname { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public bool IsUserJoined { get; set; }
        public string EventTypeName { get; set; }
        public string OrganizatorName { get; set; }
        public string LocationAdress { get; set; }
        public bool IsCompleted { get; set; }
        public List<string> Rules { get; set; } = new List<string>();
    }
}