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

            modelBuilder.Entity<Expert>().HasRequired(p => p.User);

            modelBuilder.Entity<Mark>().HasRequired(p => p.Expert);
            modelBuilder.Entity<Mark>().HasRequired(p => p.Project);

            modelBuilder.Entity<Project>().HasRequired(p => p.Manager);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
