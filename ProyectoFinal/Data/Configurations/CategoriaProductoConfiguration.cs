using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class CategoriaProductoConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CategoriasProducto");

            builder.HasKey(c => c.CategoriaID);


            builder.Property(c => c.CategoriaID)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.NombreCategoria)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Descripcion)
                .HasMaxLength(500);

            builder.Property(c => c.Activo)
                .IsRequired()
                .HasDefaultValue(true);


            builder.HasIndex(c => c.NombreCategoria)
                .IsUnique()
                .HasDatabaseName("IX_CategoriasProducto_NombreCategoria");
        }
    }
}