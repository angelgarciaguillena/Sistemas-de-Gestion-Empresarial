using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.ToTable("DetallesPedido");

            builder.HasKey(d => d.DetallePedidoID);


            builder.Property(d => d.DetallePedidoID)
                .ValueGeneratedOnAdd();

            builder.Property(d => d.PedidoID)
                .IsRequired();

            builder.Property(d => d.ProductoID)
                .IsRequired();

            builder.Property(d => d.Cantidad)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(d => d.PrecioUnitario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(d => d.Descuento)
                .IsRequired()
                .HasColumnType("decimal(5,2)")
                .HasDefaultValue(0);

            builder.Property(d => d.ImporteLinea)
                .HasColumnType("decimal(18,2)")
                .HasComputedColumnSql("[Cantidad] * [PrecioUnitario] * (1 - [Descuento] / 100)", stored: true);

            builder.Property(d => d.Observaciones)
                .HasMaxLength(500);


            builder.HasOne<Pedido>()
                .WithMany()
                .HasForeignKey(d => d.PedidoID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Producto>()
                .WithMany()
                .HasForeignKey(d => d.ProductoID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(d => d.PedidoID)
                .HasDatabaseName("IX_DetallesPedido_PedidoID");

            builder.HasIndex(d => d.ProductoID)
                .HasDatabaseName("IX_DetallesPedido_ProductoID");
        }
    }
}