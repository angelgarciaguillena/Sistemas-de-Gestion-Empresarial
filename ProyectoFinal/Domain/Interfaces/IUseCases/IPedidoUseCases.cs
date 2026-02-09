using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUseCases
{
    public interface IPedidoUseCases
    {
        Task<List<Pedido>> ObtenerTodosAsync();
        Task<Pedido?> ObtenerPorIdAsync(int id);
        Task<Pedido> CrearPedidoAsync(Pedido pedido);
        Task ActualizarPedidoAsync(Pedido pedido);
        Task EliminarPedidoAsync(int id);
        Task CambiarEstadoAsync(int pedidoId, int nuevoEstadoId, string modificadoPor);
    }
}
