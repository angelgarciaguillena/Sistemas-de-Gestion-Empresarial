using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PedidoDetalleDTO
    {
        public int PedidoID { get; }

        public string NumeroPedido { get; }

        public ProveedorDTO Proveedor { get; }

        public EstadoPedidoDTO Estado { get; }

        public DateTime FechaPedido { get; }

        public DateTime? FechaEntregaPrevista { get; }

        public DateTime? FechaEntregaReal { get; }

        public decimal ImporteTotal { get; }

        public decimal IVA { get; }

        public decimal ImporteTotalConIVA { get; }

        public string? Observaciones { get; }

        public string CreadoPor { get; }

        public List<DetallePedidoDTO> Detalles { get; }

        public PedidoDetalleDTO(
            int pedidoID,
            string numeroPedido,
            ProveedorDTO proveedor,
            EstadoPedidoDTO estado,
            DateTime fechaPedido,
            DateTime? fechaEntregaPrevista,
            DateTime? fechaEntregaReal,
            decimal importeTotal,
            decimal iva,
            decimal importeTotalConIVA,
            string? observaciones,
            string creadoPor,
            List<DetallePedidoDTO> detalles)
        {
            PedidoID = pedidoID;
            NumeroPedido = numeroPedido;
            Proveedor = proveedor;
            Estado = estado;
            FechaPedido = fechaPedido;
            FechaEntregaPrevista = fechaEntregaPrevista;
            FechaEntregaReal = fechaEntregaReal;
            ImporteTotal = importeTotal;
            IVA = iva;
            ImporteTotalConIVA = importeTotalConIVA;
            Observaciones = observaciones;
            CreadoPor = creadoPor;
            Detalles = detalles;
        }
    }

}
