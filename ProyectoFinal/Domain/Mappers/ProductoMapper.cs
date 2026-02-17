using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public class ProductoMapper
    {
        public ProductoDTO ToDTO(Producto entity)
        {
            return new ProductoDTO(
                productoID: entity.ProductoID,
                codigoProducto: entity.CodigoProducto,
                nombreProducto: entity.NombreProducto,
                descripcion: entity.Descripcion,
                unidadMedida: entity.UnidadMedida,
                precioUnitario: entity.PrecioUnitario,
                stockActual: entity.StockActual,
                categoriaNombre: "" // Se debe cargar desde la relación con Categoria
            );
        }

        public Producto ToEntity(ProductoDTO productoDTO, int categoriaID)
        {
            return new Producto
            {
                ProductoID = productoDTO.ProductoID,
                CategoriaID = categoriaID,
                CodigoProducto = productoDTO.CodigoProducto,
                NombreProducto = productoDTO.NombreProducto,
                Descripcion = productoDTO.Descripcion,
                UnidadMedida = productoDTO.UnidadMedida,
                PrecioUnitario = productoDTO.PrecioUnitario ?? 0,
                StockActual = productoDTO.StockActual,
                Activo = true,
                FechaAlta = DateTime.Now,
                FechaModificacion = null,
            };
        }
    }
}