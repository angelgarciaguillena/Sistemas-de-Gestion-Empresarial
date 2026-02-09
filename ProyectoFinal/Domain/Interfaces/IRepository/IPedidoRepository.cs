using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task<Pedido> CreateAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
        Task<List<Pedido>> GetByEstadoAsync(int estadoId);
        Task<List<Pedido>> GetByProveedorAsync(int proveedorId);
    }
}
