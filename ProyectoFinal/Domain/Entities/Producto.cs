using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Producto
    {
        #region atributos
        private int _productoID;
        private int _categoriaID;
        private string _codigoProducto;
        private string _nombreProducto;
        private string? _descripcion;
        private string _unidadMedida;
        private decimal _precioUnitario;
        private int _stockMinimo = 0;
        private int _stockActual;
        private bool _activo = true;
        private DateTime _fechaAlta = DateTime.Now;
        private DateTime? _fechaModificacion;
        #endregion

        #region constructores
        public Producto() { }

        public Producto(
            int productoID,
            int categoriaID,
            string codigoProducto,
            string nombreProducto,
            string? descripcion,
            string unidadMedida,
            decimal precioUnitario,
            int stockMinimo,
            int stockActual,
            bool activo,
            DateTime fechaAlta,
            DateTime? fechaModificacion)
        {
            _productoID = productoID;
            _categoriaID = categoriaID;
            _codigoProducto = codigoProducto;
            _nombreProducto = nombreProducto;
            _descripcion = descripcion;
            _unidadMedida = unidadMedida;
            _precioUnitario = precioUnitario;
            _stockMinimo = stockMinimo;
            _stockActual = stockActual;
            _activo = activo;
            _fechaAlta = fechaAlta;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        #region propiedades
        [Key]
        public int ProductoID { get; set; }

        [Required]
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(50)]
        public string CodigoProducto { get; set; }

        [Required]
        [StringLength(255)]
        public string NombreProducto { get; set; }

        [StringLength(1000)]
        public string? Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string UnidadMedida { get; set; }

        [Required]
        [Range(0, 1000000000000000.99)]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockMinimo { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockActual { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        public DateTime? FechaModificacion { get; set; }
        #endregion
    }
}
