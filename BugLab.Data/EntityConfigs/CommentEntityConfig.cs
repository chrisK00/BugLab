using BugLab.Data.Entities;
using BugLab.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.EntityConfigs
{
    public class CommentEntityConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ConfigureAudit();

            builder.ToTable("Comments");

            builder.Property(x => x.Text)
                .IsRequired();
        }
    }
}
