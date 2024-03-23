using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e=>e.EventType).WithMany(e=>e.Events).HasForeignKey(e=>e.EventTypeId);
            builder.HasOne(e => e.Organizator).WithMany(e => e.Events).HasForeignKey(e => e.OrganizatorId);
            builder.HasOne(e => e.Location).WithMany(e => e.Events).HasForeignKey(e => e.LocationId);
        }
    }
}