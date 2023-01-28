using ApiRest.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.AccesoDatos
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entidad>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Equipo> Equipos { get; set; }
    }
}
