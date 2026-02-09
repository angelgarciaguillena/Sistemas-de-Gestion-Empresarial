using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.IMappers;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class PedidoMapper
    {
        public static PedidoDTO ToDTO(Pedido entity)
        {
            Proveedor proveedor = GetByIdAsync(entity.ProveedorID);
            EstadoPedido estado = new EstadoPedido(); // Se debe cargar desde la relación

            return new PedidoDTO(
                pedidoID: entity.PedidoID,
                numeroPedido: entity.NumeroPedido,
                proveedorNombre: "", // Se debe cargar desde la relación con Proveedor
                estadoNombre: "", // Se debe cargar desde la relación con EstadoPedido
                fechaPedido: entity.FechaPedido,
                fechaEntregaPrevista: entity.FechaEntregaPrevista,
                importeTotalConIVA: entity.ImporteTotalConIVA,
                numeroLineas: 0 // Se debe calcular desde los detalles
            );
        }

        public static PedidoDetalleDTO ToDetalleDTO(Pedido entity)
        {
            return new PedidoDetalleDTO(
                pedidoID: entity.PedidoID,
                numeroPedido: entity.NumeroPedido,
                proveedor: new ProveedorDTO(0, "", "", null, null, null, null), // Se debe cargar desde la relación
                estado: new EstadoPedidoDTO(0, "", null), // Se debe cargar desde la relación
                fechaPedido: entity.FechaPedido,
                fechaEntregaPrevista: entity.FechaEntregaPrevista,
                fechaEntregaReal: entity.FechaEntregaReal,
                importeTotal: entity.ImporteTotal,
                iva: entity.IVA,
                importeTotalConIVA: entity.ImporteTotalConIVA,
                observaciones: entity.Observaciones,
                creadoPor: entity.CreadoPor,
                detalles: new List<DetallePedidoDTO>() // Se deben cargar desde la relación
            );
        }

    
    }
}