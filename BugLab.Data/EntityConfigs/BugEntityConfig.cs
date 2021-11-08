using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.EntityConfigs
{
    public class BugEntityConfig : IEntityTypeConfiguration<Bug>
    {
        public void Configure(EntityTypeBuilder<Bug> builder)
        {
            builder.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.Property(x => x.Priority)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(x => x.ProjectId);

            builder.Property(X => X.ProjectTitle)
                .HasMaxLength(255);

        }
    }
}
