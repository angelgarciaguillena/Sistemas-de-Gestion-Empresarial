using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class EstadoPedidoDTO
    {
        public int EstadoID { get; }

        public string NombreEstado { get; }

        public string? Descripcion { get; }

        public EstadoPedidoDTO(
            int estadoID,
            string nombreEstado,
            string? descripcion)
        {
            EstadoID = estadoID;
            NombreEstado = nombreEstado;
            Descripcion = descripcion;
        }
    }
}