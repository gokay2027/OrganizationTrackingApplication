using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Follow.FollowPerson
{
    public class FollowPersonCommand : IRequest<FollowPersonOutputModel>
    {
        public Guid UserId { get; set; }
        public Guid UserToBeFollowedId { get; set; }
    }
}