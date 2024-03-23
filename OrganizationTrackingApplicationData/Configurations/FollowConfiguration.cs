using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(f => f.Follower).WithMany(u => u.Followers).HasForeignKey(f => f.FollowerId);
            builder.HasOne(f => f.Followed).WithMany(u => u.Followeds).HasForeignKey(f => f.FollowedId);
        }
    }
}