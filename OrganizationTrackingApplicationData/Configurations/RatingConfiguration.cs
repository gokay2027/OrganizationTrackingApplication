using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(a => a.Ratings).HasForeignKey(a => a.UserId);
            builder.HasOne(x => x.Event).WithMany(x => x.Ratings).HasForeignKey(x => x.EventId);
        }
    }
}