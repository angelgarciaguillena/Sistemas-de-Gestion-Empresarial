using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EstadoPedido
    {
        #region atributos
        private int _estadoID;
        private string _nombreEstado;
        private string? _descripcion;
        private int _ordenEstado;
        #endregion

        #region constructores
        public EstadoPedido() { }

        public EstadoPedido(int estadoID, string nombreEstado, string? descripcion, int ordenEstado)
        {
            _estadoID = estadoID;
            _nombreEstado = nombreEstado;
            _descripcion = descripcion;
            _ordenEstado = ordenEstado;
        }
        #endregion

        #region propiedades
        [Key]
        public int EstadoID { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreEstado { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El orden del estado debe ser positivo")]
        public int OrdenEstado { get; set; }
        #endregion
    }

}
