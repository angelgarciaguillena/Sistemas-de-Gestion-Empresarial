using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");

            builder.HasKey(p => p.ProveedorID);


            builder.Property(p => p.ProveedorID)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CIF)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.RazonSocial)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.NombreComercial)
                .HasMaxLength(255);

            builder.Property(p => p.Direccion)
                .HasMaxLength(500);

            builder.Property(p => p.CodigoPostal)
                .HasMaxLength(10);

            builder.Property(p => p.Ciudad)
                .HasMaxLength(100);

            builder.Property(p => p.Provincia)
                .HasMaxLength(100);

            builder.Property(p => p.Pais)
                .IsRequired()
                .HasMaxLength(100)
                .HasDefaultValue("España");

            builder.Property(p => p.Telefono)
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .HasMaxLength(255);

            builder.Property(p => p.PersonaContacto)
                .HasMaxLength(255);

            builder.Property(p => p.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(p => p.FechaAlta)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.FechaModificacion);


            builder.HasIndex(p => p.CIF)
                .IsUnique()
                .HasDatabaseName("IX_Proveedores_CIF");

            builder.HasIndex(p => p.RazonSocial)
                .HasDatabaseName("IX_Proveedores_RazonSocial");
        }
    }
}