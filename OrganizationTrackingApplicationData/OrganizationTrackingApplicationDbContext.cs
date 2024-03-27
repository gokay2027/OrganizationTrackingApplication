using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using OrganizationTrackingApplicationData.Configurations;

namespace OrganizationTrackingApplicationData
{
    public class OrganizationTrackingApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrganizationTrackingApplication;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new EventConfiguration().Configure(modelBuilder.Entity<Event>());
            new EventTypeConfiguration().Configure(modelBuilder.Entity<EventType>());
            new NotificationConfiguration().Configure(modelBuilder.Entity<Notification>());
            new OrganizatorConfiguration().Configure(modelBuilder.Entity<Organizator>());
            new RatingConfiguration().Configure(modelBuilder.Entity<Rating>());
            new RulesConfiguration().Configure(modelBuilder.Entity<Rules>());
            new TicketConfiguration().Configure(modelBuilder.Entity<Ticket>());
            new FriendConfiguration().Configure(modelBuilder.Entity<Friend>());
            new FollowConfiguration().Configure(modelBuilder.Entity<Follow>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Organizator> Organizators { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Rules> Rules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Follow> Follows { get; set; }
    }
}