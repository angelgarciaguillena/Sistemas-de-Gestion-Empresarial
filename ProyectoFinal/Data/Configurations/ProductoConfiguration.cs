using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");

            builder.HasKey(p => p.ProductoID);


            builder.Property(p => p.ProductoID)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CodigoProducto)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.NombreProducto)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.UnidadMedida)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.PrecioUnitario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.StockMinimo)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.StockActual)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(p => p.FechaAlta)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.FechaModificacion)
                .IsRequired();


            builder.HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(p => p.CategoriaID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(p => p.CodigoProducto)
                .IsUnique()
                .HasDatabaseName("IX_Productos_CodigoProducto");

            builder.HasIndex(p => p.CategoriaID)
                .HasDatabaseName("IX_Productos_CategoriaID");
        }
    }
}