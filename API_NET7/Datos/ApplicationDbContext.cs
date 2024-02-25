using API_NET7.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API_NET7.Datos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Villa> Villas { get; set;}
        public DbSet<NumeroVilla> NumeroVillas { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa",
                    imageUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Preminun Vista al Mar",
                    Detalle = "Detalle de la Villa...",
                    imageUrl = "",
                    Ocupantes = 3,
                    MetrosCuadrados = 90,
                    Tarifa = 1500,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                }
            ); 
        }
    }
}
