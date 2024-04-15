using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Location.AddLocation
{
    public class AddLocationCommand : IRequest<AddLocationOutputModel>
    {
        public string Description { get; set; }
        public string FormattedName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}