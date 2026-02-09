using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class DetallePedidoDTO
    {
        public int DetallePedidoID { get; }

        public int ProductoID { get; }

        public string ProductoNombre { get; }

        public string CodigoProducto { get; }

        public int Cantidad { get; }

        public decimal PrecioUnitario { get; }

        public decimal Descuento { get; }

        public decimal ImporteLinea { get; }

        public DetallePedidoDTO(
            int detallePedidoID,
            int productoID,
            string productoNombre,
            string codigoProducto,
            int cantidad,
            decimal precioUnitario,
            decimal descuento,
            decimal importeLinea)
        {
            DetallePedidoID = detallePedidoID;
            ProductoID = productoID;
            ProductoNombre = productoNombre;
            CodigoProducto = codigoProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Descuento = descuento;
            ImporteLinea = importeLinea;
        }
    }
}