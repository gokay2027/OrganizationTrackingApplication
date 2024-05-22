using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.MLData.SuggestEvent
{
    public class MLSuggestEventDataListOutputModel : BaseOutputModel
    {
        public List<MLSuggestEventDataListItem> ResultList { get; set; } = new();
    }

    public class MLSuggestEventDataListItem
    {
        public Guid? UserId { get; set; }
        public bool Gender { get; set; }
        public string eventType { get; set; }
        public int? Age { get; set; }
        public int UserEventRate { get; set; }
        public int? TicketPrice { get; set; }
        public string EventDate { get; set; }
    }
}