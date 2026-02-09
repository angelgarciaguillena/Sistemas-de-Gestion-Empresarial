using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido
    {
        #region atributos
        private int _pedidoID;
        private string _numeroPedido;
        private int _proveedorID;
        private int _estadoID;
        private DateTime _fechaPedido = DateTime.Now;
        private DateTime? _fechaEntregaPrevista;
        private DateTime? _fechaEntregaReal;
        private decimal _importeTotal = 0;
        private decimal _IVA = 21.00m;
        private decimal _importeTotalConIVA = 0;
        private string? _observaciones;
        private string _creadoPor;
        private DateTime _fechaCreacion = DateTime.Now;
        private string? _modificadoPor;
        private DateTime? _fechaModificacion;
        private bool _puedeEditarse;
        private bool _puedeEliminarse;
        #endregion

        #region constructores
        public Pedido() { }

        public Pedido(
            int pedidoID,
            string numeroPedido,
            int proveedorID,
            int estadoID,
            DateTime fechaPedido,
            DateTime? fechaEntregaPrevista,
            DateTime? fechaEntregaReal,
            decimal importeTotal,
            decimal IVA,
            decimal importeTotalConIVA,
            string? observaciones,
            string creadoPor,
            DateTime fechaCreacion,
            string? modificadoPor,
            DateTime? fechaModificacion,
            bool puedeEditarse,
            bool puedeEliminarse)
        {
            _pedidoID = pedidoID;
            _numeroPedido = numeroPedido;
            _proveedorID = proveedorID;
            _estadoID = estadoID;
            _fechaPedido = fechaPedido;
            _fechaEntregaPrevista = fechaEntregaPrevista;
            _fechaEntregaReal = fechaEntregaReal;
            _importeTotal = importeTotal;
            _IVA = IVA;
            _importeTotalConIVA = importeTotalConIVA;
            _observaciones = observaciones;
            _creadoPor = creadoPor;
            _fechaCreacion = fechaCreacion;
            _modificadoPor = modificadoPor;
            _fechaModificacion = fechaModificacion;
            _puedeEditarse = puedeEditarse;
            _puedeEliminarse = puedeEliminarse;
        }
        #endregion

        #region propiedades
        [Key]
        public int PedidoID { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroPedido { get; set; }

        [Required]
        public int ProveedorID { get; set; }

        [Required]
        public int EstadoID { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        public DateTime? FechaEntregaPrevista { get; set; }

        public DateTime? FechaEntregaReal { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal ImporteTotal { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal IVA { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal ImporteTotalConIVA { get; set; }

        [StringLength(1000)]
        public string? Observaciones { get; set; }

        [Required]
        [StringLength(255)]
        public string CreadoPor { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [StringLength(255)]
        public string? ModificadoPor { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public bool PuedeEditarse { get; set; }

        public bool PuedeEliminarse { get; set; }
        #endregion
    }
}
