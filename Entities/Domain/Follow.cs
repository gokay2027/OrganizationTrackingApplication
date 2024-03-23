using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Follow : BaseEntity
    {
        public Guid FollowerId { get; private set; }
        public User Follower { get; private set; }

        public Guid? FollowedId { get; private set; }
        public User? Followed { get; private set; }

        public Follow()
        { }

        public Follow(Guid followerId,Guid followedId)
        {
            FollowerId = followerId;
            FollowedId = followedId;
        }
    }
}