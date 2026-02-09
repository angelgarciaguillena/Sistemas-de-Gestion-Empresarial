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
    public static class ProductoMapper
    {
        public static ProductoDTO ToDTO(Producto entity)
        {
            Categoria categoria = getCate
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
    }
}