using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.EntityConfigs
{
    public class BugEntityConfig : IEntityTypeConfiguration<Bug>
    {
        public void Configure(EntityTypeBuilder<Bug> builder)
        {
            builder.ConfigureAudit();

            builder.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.Property(x => x.Priority)
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(x => x.Comments)
                .WithOne()
                .IsRequired();

            builder.HasOne(x => x.BugType)
                .WithMany()
                .HasForeignKey(x => x.BugTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
