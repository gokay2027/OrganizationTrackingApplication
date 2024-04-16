using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.EventType
{
    public class GetAllEventTypesListModel : BaseListOutputModel
    {
        public List<EventTypeListItem> ResultList { get; set; } = new();
    }

    public class EventTypeListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}