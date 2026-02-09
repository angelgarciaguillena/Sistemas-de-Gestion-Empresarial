using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        #region atributos
        private int _categoriaID;
        private string _nombreCategoria;
        private string? _descripcion;
        private bool _activo = true;
        #endregion

        #region constructores
        public Categoria() { }

        public Categoria(int categoriaID, string nombreCategoria, string? descripcion, bool activo)
        {
            _categoriaID = categoriaID;
            _nombreCategoria = nombreCategoria;
            _descripcion = descripcion;
            _activo = activo;
        }
        #endregion

        #region propiedades
        [Key]
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCategoria { get; set; }

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required]
        public bool Activo { get; set; }
        #endregion
    }
}
