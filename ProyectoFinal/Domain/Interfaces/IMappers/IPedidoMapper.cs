using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IMappers
{
    public interface IPedidoMapper
    {
        PedidoDTO ToDTO(Pedido entity);
        PedidoDetalleDTO ToDetalleDTO(Pedido entity);
        Pedido ToEntity(PedidoDTO dto);
    }
}