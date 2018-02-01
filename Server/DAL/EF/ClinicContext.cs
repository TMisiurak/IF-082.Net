using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class ClinicContext : DbContext
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasAlternateKey(c => c.Email)
              .HasName("AlternateKey_Email");
        }
    }
}
