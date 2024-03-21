using Entities.BaseAggregate.Concrete;
using Entities.Entities;

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
        public List<User> Friends { get; private set; } = new List<User>();

        public List<User> Followers { get; private set; } = new List<User>();
        public List<User> Followeds { get; private set; } = new List<User>();

        public List<Notification> Notifications { get; private set; } = new List<Notification>();
        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();

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