using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.Extensions
{
    public static class EntityConfigurationExtensions
    {
        public static void ConfigureAudit<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : AuditableEntity
        {
            builder.HasOne(x => x.CreatedBy)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.CreatedById);

            builder.HasOne(x => x.ModifiedBy)
              .WithMany()
              .HasForeignKey(x => x.ModifiedById);

            builder.HasOne(x => x.DeletedBy)
                .WithMany()
                .HasForeignKey(x => x.DeletedById);

            builder.HasQueryFilter(x => !x.Deleted.HasValue);
        }
    }
}
