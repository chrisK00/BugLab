using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.EntityConfigs
{
    public class CommentEntityConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(x => x.Text)
                .IsRequired();

            builder.HasOne(x => x.CreatedBy)
              .WithMany()
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.CreatedById);

            builder.HasOne(x => x.ModifiedBy)
              .WithMany()
              .HasForeignKey(x => x.ModifiedById);
        }
    }
}
