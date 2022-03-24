using BugLab.Data.Entities;
using BugLab.Data.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Data
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly string _currentUserId;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContext = null) : base(options)
        {
            _currentUserId = httpContext?.HttpContext?.User?.UserId();
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BugType> BugTypes { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            builder.Seed();
        }

        /// <summary>
        /// Saves Changes and updates any audit tracked entities
        /// </summary>
        /// <inheritdoc cref="DbContext.SaveChangesAsync(CancellationToken)"/>
        /// <param name="cancellationToken"></param>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CreateAuditTrail();
            try
            {
                ChangeTracker.AutoDetectChangesEnabled = false;
                return await base.SaveChangesAsync(cancellationToken);
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        private void CreateAuditTrail()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                var currentTime = DateTime.UtcNow;

                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.SetProperty(x => x.Modified, currentTime);
                        entry.SetProperty(x => x.ModifiedById, _currentUserId);

                        if (entry.Entity.Deleted?.AddMinutes(5) > currentTime)
                        {
                            entry.SetProperty(x => x.DeletedById, _currentUserId);
                        }

                        break;

                    case EntityState.Added:

                        entry.SetProperty(x => x.Created, currentTime);
                        entry.SetProperty(x => x.CreatedById, _currentUserId);
                        break;
                }
            }
        }
    }
}