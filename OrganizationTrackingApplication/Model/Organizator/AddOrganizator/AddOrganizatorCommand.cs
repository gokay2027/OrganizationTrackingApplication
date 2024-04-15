using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Organizator.AddOrganizator
{
    public class AddOrganizatorCommand : IRequest<AddOrganizatorOutputModel>
    {
        public string Name { get; set; }
    }
}