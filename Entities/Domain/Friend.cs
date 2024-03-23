using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Friend : BaseEntity
    {
        public Guid FriendOneId { get; private set; }
        public User FriendOne { get; private set; }

        public Guid FriendTwoId { get; private set; }
        public User FriendTwo { get; private set; }

        public Friend()
        { }

        public Friend(Guid friendOneId, Guid friendTwoId)
        {
            FriendOneId = friendOneId;
            FriendTwoId = friendTwoId;
        }
    }
}