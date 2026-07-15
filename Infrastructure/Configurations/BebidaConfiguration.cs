using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BebidaConfiguration : IEntityTypeConfiguration<Bebida>
    {
        public void Configure(EntityTypeBuilder<Bebida> builder)
        {
            builder.ToTable("Bebidas");

            builder.Property(b => b.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.Cantidad)
                   .IsRequired();

            builder.OwnsOne(b => b.Precio, precio =>
            {
                precio.Property(p => p.Valor).HasColumnName("Precio_Valor");
                precio.Property(p => p.Moneda).HasColumnName("Precio_Moneda");
            });
        }
    }
}
