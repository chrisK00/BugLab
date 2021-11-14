using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.EntityConfigs
{
    public class BugTypeEntityConfig : IEntityTypeConfiguration<BugType>
    {
        public void Configure(EntityTypeBuilder<BugType> builder)
        {
            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(x => x.ProjectId)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
