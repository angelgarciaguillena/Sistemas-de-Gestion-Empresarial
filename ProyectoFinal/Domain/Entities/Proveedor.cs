using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Proveedor
    {
        #region atributos
        private int _proveedorID;
        private string _CIF;
        private string _razonSocial;
        private string? _nombreComercial;
        private string? _direccion;
        private string? _codigoPostal;
        private string? _ciudad;
        private string? _provincia;
        private string _pais = "España";
        private string? _telefono;
        private string? _email;
        private string? _personaContacto;
        private bool _activo = true;
        private DateTime _fechaAlta = DateTime.Now;
        private DateTime? _fechaModificacion;
        #endregion

        #region constructores
        public Proveedor() { }

        public Proveedor(
            int proveedorID,
            string CIF,
            string razonSocial,
            string? nombreComercial,
            string? direccion,
            string? codigoPostal,
            string? ciudad,
            string? provincia,
            string pais,
            string? telefono,
            string? email,
            string? personaContacto,
            bool activo,
            DateTime fechaAlta,
            DateTime? fechaModificacion)
        {
            _proveedorID = proveedorID;
            _CIF = CIF;
            _razonSocial = razonSocial;
            _nombreComercial = nombreComercial;
            _direccion = direccion;
            _codigoPostal = codigoPostal;
            _ciudad = ciudad;
            _provincia = provincia;
            _pais = pais;
            _telefono = telefono;
            _email = email;
            _personaContacto = personaContacto;
            _activo = activo;
            _fechaAlta = fechaAlta;
            _fechaModificacion = fechaModificacion;
        }
        #endregion

        #region propiedades
        [Key]
        public int ProveedorID { get; set; }

        [Required]
        [StringLength(15)]
        public string CIF { get; set; }

        [Required]
        [StringLength(255)]
        public string RazonSocial { get; set; }

        [StringLength(255)]
        public string? NombreComercial { get; set; }

        [StringLength(500)]
        public string? Direccion { get; set; }

        [StringLength(10)]
        public string? CodigoPostal { get; set; }

        [StringLength(100)]
        public string? Ciudad { get; set; }

        [StringLength(100)]
        public string? Provincia { get; set; }

        [Required]
        [StringLength(100)]
        public string Pais { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? PersonaContacto { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        public DateTime? FechaModificacion { get; set; }
        #endregion
    }

}
