using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Follow.UnfollowPerson
{
    public class UnfollowPersonCommand : IRequest<UnfollowPersonOutputModel>
    {
        public Guid FollowId { get; set; }
    }
}