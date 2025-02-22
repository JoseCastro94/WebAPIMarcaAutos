using Microsoft.EntityFrameworkCore;
using WebAPIMarcaAutos.Models;

namespace WebAPIMarcaAutos.Config
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<MarcasAutos> MarcasAutos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MarcasAutos>().HasData(
                new MarcasAutos { Id = 1, Nombre = "Toyota" },
                new MarcasAutos { Id = 2, Nombre = "Ford" },
                new MarcasAutos { Id = 3, Nombre = "Chevrolet" },
                new MarcasAutos { Id = 4, Nombre = "Audi" },
                new MarcasAutos { Id = 5, Nombre = "Hyundai" },
                new MarcasAutos { Id = 6, Nombre = "Kia" }
            );
        }
    }
}
