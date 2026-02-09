using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class EstadoPedidoConfiguration : IEntityTypeConfiguration<EstadoPedido>
    {
        public void Configure(EntityTypeBuilder<EstadoPedido> builder)
        {
            builder.ToTable("EstadosPedido");

            builder.HasKey(e => e.EstadoID);


            builder.Property(e => e.EstadoID)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.NombreEstado)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Descripcion)
                .HasMaxLength(255);

            builder.Property(e => e.OrdenEstado)
                .IsRequired();


            builder.HasIndex(e => e.NombreEstado)
                .IsUnique()
                .HasDatabaseName("IX_EstadosPedido_NombreEstado");

            builder.HasIndex(e => e.OrdenEstado)
                .HasDatabaseName("IX_EstadosPedido_OrdenEstado");
        }
    }
}