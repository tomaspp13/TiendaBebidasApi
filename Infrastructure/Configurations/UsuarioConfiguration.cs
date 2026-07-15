using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.OwnsOne(u => u.Nombre, nombre =>
            {
                nombre.Property(u => u.Nombre).HasColumnName("Nombre_Principal");
                nombre.Property(u => u.Apellido).HasColumnName("Apellido");
            });

            builder.OwnsOne(u => u.EmailUsuario, email => 
            {
                email.Property(u => u.EmailNombre).HasColumnName("Email_Nombre");
            });

            builder.OwnsOne(u => u.ContraseñaUsuario, contraseña =>
            {
                contraseña.Property(u => u.ContraseñaDeEmail).HasColumnName("Contraseña");
            });

        }
    }
}
