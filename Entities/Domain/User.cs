using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Gender { get; private set; }

        //Many to Many itselfs
        public List<Friend> FriendOnes { get; private set; } = new List<Friend>();
        public List<Friend> FriendTwos { get; private set; } = new List<Friend>();

        public List<Follow> Followers { get; private set; } = new List<Follow>();
        public List<Follow> Followeds { get; private set; } = new List<Follow>();

        public List<Notification> Notifications { get; private set; } = new List<Notification>();
        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public List<Rating> Ratings { get; private set; } = new List<Rating>();

        public User()
        {
        }

        public User(string name, string surname, string email, string password, bool gender)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public void Update(string name, string surname, string email, string password, bool gender)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword.Equals(Password))
            {
                Password = newPassword;
            }
        }
    }
}