using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Follow.FollowPerson;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.FollowCommand.FollowPerson
{
    public class FollowPersonCommandHandler : IRequestHandler<FollowPersonCommand, FollowPersonOutputModel>
    {
        private readonly IGenericRepository<Follow> _followRepoistory;

        public FollowPersonCommandHandler(IGenericRepository<Follow> followRepoistory)
        {
            _followRepoistory = followRepoistory;
        }

        public async Task<FollowPersonOutputModel> Handle(FollowPersonCommand request, CancellationToken cancellationToken)
        {
            var output = new FollowPersonOutputModel();
            try
            {
                var followData = await _followRepoistory.GetByFilter(a => a.FollowerId.Equals(request.UserId) && a.FollowedId.Equals(request.UserToBeFollowedId));
                var checkForFollower = followData.FirstOrDefault();
                if (checkForFollower == null)
                {
                    await _followRepoistory.Insert(new Follow(
                         request.UserId, request.UserToBeFollowedId));
                }
                else
                {
                    output.Message = "Person is already being followed";
                    output.IsSuccess = true;
                    return output;
                }

                output.Message = "Person followed successfully";
                output.IsSuccess = true;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.IsSuccess = false;
                return output;
            }
        }
    }
}