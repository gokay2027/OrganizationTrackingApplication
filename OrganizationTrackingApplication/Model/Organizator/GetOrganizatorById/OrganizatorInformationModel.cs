using OrganizationTrackingApplicationApi.Model.BaseModel;
using OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorByFilter;

namespace OrganizationTrackingApplicationApi.Model.Organizator.GetOrganizatorById
{
    public class OrganizatorInformationModel : BaseOutputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<OrganizatorEventListItem> OrganizatorEvents { get; set; } = new List<OrganizatorEventListItem>();
    }

    public class OrganizatorEventsListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal AverageRating { get; set; }
    }
}