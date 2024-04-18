using Entities.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(a => a.User).WithOne(a => a.Balance);
        }
    }
}
