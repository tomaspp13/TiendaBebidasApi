using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Bebida> Bebidas {  get; set; }
        public DbSet<Usuario> Usuarios { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Bebida>().OwnsOne(b => b.Precio);
            modelBuilder.Entity<Usuario>().OwnsOne(b => b.Nombre);
            modelBuilder.Entity<Usuario>().OwnsOne(b => b.ContraseñaUsuario);
            modelBuilder.Entity<Usuario>().OwnsOne(b => b.EmailUsuario);
        }
    }

}
