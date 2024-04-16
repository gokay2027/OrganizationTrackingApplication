using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.Model.Location.GetAllLocations
{
    public class GetAllLocationsListModel : BaseListOutputModel
    {
        public List<LocationListItem> ResultList { get; set; } = new();
    }

    public class LocationListItem
    {
        public Guid Id { get;set; }
        public string Description { get; set; }
        public string FormattedName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}