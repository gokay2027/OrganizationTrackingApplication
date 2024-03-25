using Entities.Domain;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationTrackingApplicationData.Configurations
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(new EventType("Concert"));
            builder.HasData(new EventType("Carnival"));
            builder.HasData(new EventType("Festival"));
            builder.HasData(new EventType("Meeting"));
            builder.HasData(new EventType("Activity"));
            builder.HasData(new EventType("Trip"));
        }
    }
}