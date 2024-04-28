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

        public async Task<UnfollowPersonOutputModel> Handle(UnfollowPersonCommand request, CancellationToken cancellationToken)
        {
            var personToBeUnfollowed = await _followRepository.GetById(request.FollowId);
            personToBeUnfollowed.Delete();

            return new UnfollowPersonOutputModel
            {
                IsSuccess = true,
                Message = "Person unfollowed successfully",
            };
    }
}
}