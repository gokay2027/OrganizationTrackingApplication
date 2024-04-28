using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.Follow.GetFollows
{
    public class GetFollowsListModel : BaseListOutputModel
    {
        public List<FollowInformationListItem> FollowerList { get; set; } = new List<FollowInformationListItem>();
        public List<FollowInformationListItem> FollowedList { get; set; } = new List<FollowInformationListItem>();
        public int FollowerCount { get; set; }
        public int FollowedCount { get; set; }
    }

    public class FollowInformationListItem
    {
        public Guid FollowId { get; set; }
        public string UserName { get; set; }
    }
}