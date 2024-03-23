using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class OrganizatorConfiguration : IEntityTypeConfiguration<Organizator>
    {
        public void Configure(EntityTypeBuilder<Organizator> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}