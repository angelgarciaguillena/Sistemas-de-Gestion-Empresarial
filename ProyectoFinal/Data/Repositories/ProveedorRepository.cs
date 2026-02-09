using Data.DataSources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProveedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(int id)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.ProveedorID == id);
        }

        public async Task<List<Proveedor>> GetActivosAsync()
        {
            return await _context.Proveedores.Where(p => p.Activo).ToListAsync();
        }
    }
}
