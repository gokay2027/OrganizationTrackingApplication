using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(f => f.FriendOne)
                .WithMany(u => u.FriendOnes)
                .HasForeignKey(f => f.FriendOneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.FriendTwo)
                .WithMany(u => u.FriendTwos)
                .HasForeignKey(f => f.FriendTwoId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}