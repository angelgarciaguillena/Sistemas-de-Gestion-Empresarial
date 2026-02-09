using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class ProveedorMapper
    {
        public static ProveedorDTO ToDTO(Proveedor entity)
        {
            return new ProveedorDTO(
                proveedorID: entity.ProveedorID,
                cif: entity.CIF,
                razonSocial: entity.RazonSocial,
                nombreComercial: entity.NombreComercial,
                telefono: entity.Telefono,
                email: entity.Email,
                personaContacto: entity.PersonaContacto
            );
        }
    }
}