using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.EntityConfigs
{
    public class ProjectEntityConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(255);
        }
    }
}
