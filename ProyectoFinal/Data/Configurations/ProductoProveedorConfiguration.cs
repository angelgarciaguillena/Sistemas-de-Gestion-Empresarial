using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ProductoProveedorConfiguration : IEntityTypeConfiguration<ProductoProveedor>
    {
        public void Configure(EntityTypeBuilder<ProductoProveedor> builder)
        {
            builder.ToTable("ProductosProveedores");

            builder.HasKey(pp => pp.ProductoProveedorID);


            builder.Property(pp => pp.ProductoProveedorID)
                .ValueGeneratedOnAdd();

            builder.Property(pp => pp.ProductoID)
                .IsRequired();

            builder.Property(pp => pp.ProveedorID)
                .IsRequired();

            builder.Property(pp => pp.PrecioProveedor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(pp => pp.TiempoEntregaDias);

            builder.Property(pp => pp.CantidadMinimaPedido)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(pp => pp.Preferido)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(pp => pp.FechaAlta)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(pp => pp.FechaModificacion);


            builder.HasOne<Producto>()
                .WithMany()
                .HasForeignKey(pp => pp.ProductoID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Proveedor>()
                .WithMany()
                .HasForeignKey(pp => pp.ProveedorID)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasIndex(pp => new { pp.ProductoID, pp.ProveedorID })
                .IsUnique()
                .HasDatabaseName("IX_ProductosProveedores_ProductoID_ProveedorID");

            builder.HasIndex(pp => pp.ProveedorID)
                .HasDatabaseName("IX_ProductosProveedores_ProveedorID");
        }
    }
}