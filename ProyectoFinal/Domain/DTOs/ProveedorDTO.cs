using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProveedorDTO
    {
        public int ProveedorID { get; }

        public string CIF { get; }

        public string RazonSocial { get; }

        public string? NombreComercial { get; }

        public string? Telefono { get; }

        public string? Email { get; }

        public string? PersonaContacto { get; }

        public ProveedorDTO(
            int proveedorID,
            string cif,
            string razonSocial,
            string? nombreComercial,
            string? telefono,
            string? email,
            string? personaContacto)
        {
            ProveedorID = proveedorID;
            CIF = cif;
            RazonSocial = razonSocial;
            NombreComercial = nombreComercial;
            Telefono = telefono;
            Email = email;
            PersonaContacto = personaContacto;
        }
    }
}