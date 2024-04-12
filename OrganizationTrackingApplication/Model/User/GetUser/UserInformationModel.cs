using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.User.GetUser
{
    public class UserInformationModel : BaseOutputModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int FollowerCount { get; set; }
        public int FollowCount { get; set; }
        public List<string> EventsJoined { get; set; } = new List<string>();
    }
}