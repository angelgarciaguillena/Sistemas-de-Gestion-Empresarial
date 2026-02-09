using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PedidoDTO
    {
        public int PedidoID { get; }

        public string NumeroPedido { get; }

        public string ProveedorNombre { get; }

        public string EstadoNombre { get; }

        public DateTime FechaPedido { get; }

        public DateTime? FechaEntregaPrevista { get; }

        public decimal ImporteTotalConIVA { get; }

        public int NumeroLineas { get; }

        public PedidoDTO(
            int pedidoID,
            string numeroPedido,
            string proveedorNombre,
            string estadoNombre,
            DateTime fechaPedido,
            DateTime? fechaEntregaPrevista,
            decimal importeTotalConIVA,
            int numeroLineas)
        {
            PedidoID = pedidoID;
            NumeroPedido = numeroPedido;
            ProveedorNombre = proveedorNombre;
            EstadoNombre = estadoNombre;
            FechaPedido = fechaPedido;
            FechaEntregaPrevista = fechaEntregaPrevista;
            ImporteTotalConIVA = importeTotalConIVA;
            NumeroLineas = numeroLineas;
        }
    }
}