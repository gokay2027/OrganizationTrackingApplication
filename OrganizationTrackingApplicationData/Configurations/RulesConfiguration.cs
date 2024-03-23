using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class RulesConfiguration : IEntityTypeConfiguration<Rules>
    {
        public void Configure(EntityTypeBuilder<Rules> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Event).WithMany(x => x.Rules).HasForeignKey(x=>x.EventId);
        }
    }
}