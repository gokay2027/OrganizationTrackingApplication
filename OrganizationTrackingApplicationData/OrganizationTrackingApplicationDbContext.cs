using Entities.Domain;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace OrganizationTrackingApplicationData
{
    public class OrganizationTrackingApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
    }
}