using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LetsJam.Models;

namespace LetsJam.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Band>()
              .Property(b => b.created)
              .HasDefaultValueSql("GETDATE()");
            builder.Entity<Relation>()
              .Property(b => b.ConnectedOn)
              .HasDefaultValueSql("GETDATE()");
            builder.Entity<StatusUpdates>()
                .Property(d => d.created)
                .HasDefaultValueSql("GETDATE()");
        }

        public DbSet<LetsJam.Models.Relation> Relation { get; set; }

        public DbSet<LetsJam.Models.Band> Band { get; set; }
        public DbSet<LetsJam.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<LetsJam.Models.StatusUpdates> StatusUpdates { get; set; }
    }
}
