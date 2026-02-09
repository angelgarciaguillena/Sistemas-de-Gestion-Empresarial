using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.PedidoID);


            builder.Property(p => p.PedidoID)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.NumeroPedido)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ProveedorID)
                .IsRequired();

            builder.Property(p => p.EstadoID)
                .IsRequired();

            builder.Property(p => p.FechaPedido)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.FechaEntregaPrevista)
                .HasColumnType("date");

            builder.Property(p => p.FechaEntregaReal)
                .HasColumnType("date");

            builder.Property(p => p.ImporteTotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(p => p.IVA)
                .IsRequired()
                .HasColumnType("decimal(5,2)")
                .HasDefaultValue(21.00);

            builder.Property(p => p.ImporteTotalConIVA)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(p => p.Observaciones)
                .HasMaxLength(1000);

            builder.Property(p => p.CreadoPor)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.ModificadoPor)
                .HasMaxLength(255);

            builder.Property(p => p.FechaModificacion);


            builder.Ignore(p => p.PuedeEditarse);
            builder.Ignore(p => p.PuedeEliminarse);


            builder.HasOne<Proveedor>()
                .WithMany()
                .HasForeignKey(p => p.ProveedorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<EstadoPedido>()
                .WithMany()
                .HasForeignKey(p => p.EstadoID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(p => p.NumeroPedido)
                .IsUnique()
                .HasDatabaseName("IX_Pedidos_NumeroPedido");

            builder.HasIndex(p => p.ProveedorID)
                .HasDatabaseName("IX_Pedidos_ProveedorID");

            builder.HasIndex(p => p.EstadoID)
                .HasDatabaseName("IX_Pedidos_EstadoID");

            builder.HasIndex(p => p.FechaPedido)
                .HasDatabaseName("IX_Pedidos_FechaPedido");
        }
    }
}