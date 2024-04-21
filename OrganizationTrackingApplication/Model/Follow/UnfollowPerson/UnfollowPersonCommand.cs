using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Follow.UnfollowPerson
{
    public class UnfollowPersonCommand : IRequest<UnfollowPersonOutputModel>
    {
        public Guid UserId { get; set; }
        public Guid PersonToBeUnfollowed { get; set; }
    }
}