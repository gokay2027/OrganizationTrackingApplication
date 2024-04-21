using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Follow.UnfollowPerson;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.FollowCommand.UnfollowPerson
{
    public class UnfollowPersonCommandHandler : IRequestHandler<UnfollowPersonCommand, UnfollowPersonOutputModel>
    {
        private readonly IGenericRepository<Follow> _followRepository;

        public UnfollowPersonCommandHandler(IGenericRepository<Follow> followRepository)
        {
            _followRepository = followRepository;
        }

        public Task<UnfollowPersonOutputModel> Handle(UnfollowPersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}