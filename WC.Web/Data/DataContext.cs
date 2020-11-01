using Microsoft.EntityFrameworkCore;
using WC.Common.Entities;

namespace WC.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorImage> DoctorImages { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Speciality>().HasIndex(t => t.Name).IsUnique();
        }
    }
}

