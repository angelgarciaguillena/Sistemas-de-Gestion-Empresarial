using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetallePedido
    {
        #region atributos
        private int _detallePedidoID;
        private int _pedidoID;
        private int _productoID;
        private int _cantidad;
        private decimal _precioUnitario;
        private decimal _descuento = 0;
        private decimal _importeLinea;
        private string? _observaciones;
        #endregion

        #region constructores
        public DetallePedido() { }

        public DetallePedido(
            int detallePedidoID, 
            int pedidoID, 
            int productoID, 
            int cantidad,
            decimal precioUnitario, 
            decimal descuento, 
            decimal importeLinea, 
            string? observaciones)
        {
            _detallePedidoID = detallePedidoID;
            _pedidoID = pedidoID;
            _productoID = productoID;
            _cantidad = cantidad;
            _precioUnitario = precioUnitario;
            _descuento = descuento;
            _importeLinea = importeLinea;
        }
        #endregion

        #region propiedades
        [Key]
        public int DetallePedidoID { get; set; }

        [Required]
        public int PedidoID { get; set; }

        [Required]
        public int ProductoID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100")]
        public decimal Descuento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal ImporteLinea { get; set; }

        [StringLength(500)]
        public string? Observaciones { get; set; }
        #endregion
    }

}
