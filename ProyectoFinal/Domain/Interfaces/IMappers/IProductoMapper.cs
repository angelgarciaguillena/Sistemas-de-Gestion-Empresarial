using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IMappers
{
    public interface IProductoMapper
    {
        ProductoDTO ToDTO(Producto entity);
        Producto ToEntity(ProductoDTO dto);
    }
}