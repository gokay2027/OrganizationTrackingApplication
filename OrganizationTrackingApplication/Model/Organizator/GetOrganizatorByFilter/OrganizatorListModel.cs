using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorByFilter
{
    public class OrganizatorListModel : BaseListOutputModel
    {
        public List<OrganizatorListItemModel> ResultList { get; set; } = new List<OrganizatorListItemModel>();
    }

    public class OrganizatorListItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<OrganizatorEventListItem> OrganizatorEvents { get; set; } = new List<OrganizatorEventListItem>();
    
    }

    public class OrganizatorEventListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal AverageRating { get; set; }
    }
}