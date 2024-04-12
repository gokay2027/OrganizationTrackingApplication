using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.User.GetUsers
{
    public class UserListModel : BaseListOutputModel
    {
        public List<UserItemModel> ResultList { get; set; } = new List<UserItemModel>();
    }

    public class UserItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}