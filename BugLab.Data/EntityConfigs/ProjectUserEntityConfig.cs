using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugLab.Data.EntityConfigs
{
    public class ProjectUserEntityConfig : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProjectId });

            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(x => x.ProjectId);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

        }
    }
}
