using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Owner).WithMany(o => o.Tickets).HasForeignKey(a => a.OwnerId);
            builder.HasOne(t => t.Event).WithMany(e => e.Tickets).HasForeignKey(a => a.EventId);
        }
    }
}