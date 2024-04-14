using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.Event.GetEvents
{
    public class EventListModel : BaseListOutputModel
    {
        public List<EventListItem> EventList { get; set; } = new List<EventListItem>();
    }

    public class EventListItem
    {
        public string Name { get; set; }
        public DateTime EventTime { get; set; }
        public string EventTypeName { get; set; }
        public string OrganizatorName { get; set; }
        public string LocationAdress { get; set; }
        public bool IsCompleted { get; set; }
        public List<string> Rules { get; set; } = new List<string>();

    }
}