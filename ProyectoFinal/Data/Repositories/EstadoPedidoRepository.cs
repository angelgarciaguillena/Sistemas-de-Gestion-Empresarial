using Data.DataSources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EstadoPedidoRepository : IEstadoPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public EstadoPedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstadoPedido>> GetAllAsync()
        {
            return await _context.EstadosPedido.ToListAsync();
        }

        public async Task<EstadoPedido?> GetByIdAsync(int id)
        {
            return await _context.EstadosPedido.FirstOrDefaultAsync(e => e.EstadoID == id);
        }
    }
}