using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductoProveedor
    {
        #region atributos
        private int _productoProveedorID;
        private int _productoID;
        private int _proveedorID;
        private decimal _precioProveedor;
        private int? _tiempoEntregaDias;
        private int _cantidadMinimaPedido = 1;
        private bool _preferido = false;
        private DateTime _fechaAlta = DateTime.Now;
        private DateTime? _fechaModificacion;
        #endregion

        #region constructor
        public ProductoProveedor(
            int productoProveedorID,
            int productoID,
            int proveedorID,
            decimal precioProveedor,
            int? tiempoEntregaDias,
            int cantidadMinimaPedido,
            bool preferido,
            DateTime fechaAlta,
            DateTime? fechaModificacion)
        {
            _productoProveedorID = productoProveedorID;
            _productoID = productoID;
            _proveedorID = proveedorID;
            _precioProveedor = precioProveedor;
            _tiempoEntregaDias = tiempoEntregaDias;
            _cantidadMinimaPedido = cantidadMinimaPedido;
            _preferido = preferido;
            _fechaAlta = fechaAlta;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        #region propiedades
        [Key]
        public int ProductoProveedorID { get; set; }

        [Required]
        public int ProductoID { get; set; }

        [Required]
        public int ProveedorID { get; set; }

        [Required]
        [Range(0, 9999999999999999.99, ErrorMessage = "El precio proveedor debe ser positivo")]
        public decimal PrecioProveedor { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El tiempo de entrega debe ser positivo")]
        public int? TiempoEntregaDias { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad mínima de pedido debe ser al menos 1")]
        public int CantidadMinimaPedido { get; set; }

        [Required]
        public bool Preferido { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        public DateTime? FechaModificacion { get; set; }
        #endregion
    }
}
