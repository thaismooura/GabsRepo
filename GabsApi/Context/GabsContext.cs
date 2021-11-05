using GabsApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GabsApi.Context
{
    public class GabsContext : DbContext
    {
        public GabsContext(DbContextOptions<GabsContext> options) : base(options)
        { }

        public DbSet<Gabs> Gabss { get; set; }
        public DbSet<OtherGabs> OtherGabss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gabs>().HasData(new Gabs
            {
                Id = 1,
                Name = "Gabs",
                Age = 29,
                Description = "Gabs is nice!"
            });

            modelBuilder.Entity<OtherGabs>().HasData(new OtherGabs
            {
                Id = 1,
                GabsId = 1,
                Name = "Gabs",
                Age = 25,
                Description = "There's a lot of Gabs"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}