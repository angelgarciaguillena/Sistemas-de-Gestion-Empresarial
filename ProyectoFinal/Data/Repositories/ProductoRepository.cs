using Data.DataSources;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.Repository;
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
            return await _context.Productos.Where(p => p.Activo).ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int productoId)
        {
            return await _context.Productos.FirstOrDefaultAsync(p => p.ProductoID == productoId && p.Activo);
        }

        public async Task<List<Producto>> GetByCategoriaAsync(int categoriaId)
        {
            return await _context.Productos.Where(p => p.CategoriaID == categoriaId && p.Activo).ToListAsync();
        }

        public async Task<bool> CreateAsync(Producto producto)
        {
            bool resultado = false;

            try
            {
                _context.Productos.Add(producto);

                await _context.SaveChangesAsync();

                resultado = true;
            }
            catch
            {
                resultado = false;
            }

            return resultado;
        }

        public async Task<bool> UpdateAsync(Producto producto)
        {
            bool resultado = false;

            try
            {
                Producto productoBuscado = await _context.Productos.FirstOrDefaultAsync(p => p.ProductoID == producto.ProductoID && p.Activo);

                if (productoBuscado == null)
                {
                    return false;
                }

                productoBuscado.CategoriaID = producto.CategoriaID;
                productoBuscado.CodigoProducto = producto.CodigoProducto;
                productoBuscado.NombreProducto = producto.NombreProducto;
                productoBuscado.Descripcion = producto.Descripcion;
                productoBuscado.UnidadMedida = producto.UnidadMedida;
                productoBuscado.PrecioUnitario = producto.PrecioUnitario;
                productoBuscado.StockMinimo = producto.StockMinimo;
                productoBuscado.StockActual = producto.StockActual;
                productoBuscado.Activo = producto.Activo;
                productoBuscado.FechaAlta = producto.FechaAlta;
                productoBuscado.FechaModificacion = producto.FechaModificacion;

                await _context.SaveChangesAsync();

            }
            catch
            {
                resultado = false;
            }

            return resultado;
        }

        public async Task<bool> DeleteAsync(int productoId)
        {
            bool res = true;

            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.ProductoID == productoId && p.Activo);

            if (producto == null)
                res = false;

            producto.Activo = false;

            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();

            return res;
        }

    }
}