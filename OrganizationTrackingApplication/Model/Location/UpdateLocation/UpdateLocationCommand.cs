using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Location.UpdateLocation
{
    public class UpdateLocationCommand:IRequest<UpdateLocationOutputModel>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string FormattedName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
