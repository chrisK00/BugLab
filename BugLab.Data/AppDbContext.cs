using BugLab.Data.Entities;
using BugLab.Data.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.UtcNow;
                        entry.Entity.ModifiedById = _currentUserId;
                        break;

                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.CreatedById = _currentUserId;
                        break;

                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}