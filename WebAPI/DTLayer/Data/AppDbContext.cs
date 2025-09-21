using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DTLayer.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
         
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(
        //            "Server=.;Database=SchoolDB;User ID=sa;Password=sa123456;TrustServerCertificate=True"
        //        );
        //    }
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Items> items { get; set; }
        public DbSet<Specilzeations> specilzeations { get; set; }
        public DbSet<Courses> courses { get; set; }
       public DbSet<People> people { get; set; }
    }
}
