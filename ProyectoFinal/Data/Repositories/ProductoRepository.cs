using Data.DataSources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int productoId)
        {
            return await _context.Productos.FirstOrDefaultAsync(p => p.ProductoID == productoId);
        }

        public async Task<List<Producto>> GetActivosAsync()
        {
            return await _context.Productos.Where(p => p.Activo).ToListAsync();
        }

        public async Task<List<Producto>> GetByCategoriaAsync(int categoriaId)
        {
            return await _context.Productos.Where(p => p.CategoriaID == categoriaId).ToListAsync();
        }
    }
}