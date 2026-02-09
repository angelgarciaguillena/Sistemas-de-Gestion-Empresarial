using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductoDTO
    {
        public int ProductoID { get; }

        public string CodigoProducto { get; }

        public string NombreProducto { get; }

        public string? Descripcion { get; }

        public string UnidadMedida { get; }

        public decimal? PrecioUnitario { get; }

        public int StockActual { get; set; }

        public string CategoriaNombre { get; }

        public ProductoDTO(
            int productoID,
            string codigoProducto,
            string nombreProducto,
            string? descripcion,
            string unidadMedida,
            decimal? precioUnitario,
            int stockActual,
            string categoriaNombre)
        {
            ProductoID = productoID;
            CodigoProducto = codigoProducto;
            NombreProducto = nombreProducto;
            Descripcion = descripcion;
            UnidadMedida = unidadMedida;
            PrecioUnitario = precioUnitario;
            StockActual = stockActual;
            CategoriaNombre = categoriaNombre;
        }
    }
}