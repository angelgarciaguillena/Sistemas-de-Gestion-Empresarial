using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IMappers
{
    public interface IProveedorMapper
    {
        ProveedorDTO ToDTO(Proveedor entity);
        Proveedor ToEntity(ProveedorDTO dto);
    }
}