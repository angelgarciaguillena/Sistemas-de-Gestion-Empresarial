using Data.DataSources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.PedidoID == id);
        }

        public async Task<List<Pedido>> GetByProveedorAsync(int proveedorId)
        {
            return await _context.Pedidos.Where(p => p.ProveedorID == proveedorId).ToListAsync();
        }

        public async Task<List<Pedido>> GetByEstadoAsync(int estadoId)
        {
            return await _context.Pedidos.Where(p => p.EstadoID == estadoId).ToListAsync();
        }

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(pedido.PedidoID);
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
