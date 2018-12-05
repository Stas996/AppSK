using AppSK.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AppSK.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("AppSKConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Expert> Experts { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<Manager>().HasRequired(p => p.User);
            modelBuilder.Entity<Manager>()
                .HasMany(x => x.Projects)
                .WithRequired(x => x.Manager);

            modelBuilder.Entity<Expert>().HasRequired(p => p.User);
            modelBuilder.Entity<Expert>()
                .HasMany(x => x.Marks)
                .WithRequired(x => x.Expert);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Marks)
                .WithRequired(x => x.Project);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
