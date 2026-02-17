using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.IMappers;
using Domain.Interfaces.IUseCases;
using Domain.Interfaces.Repository;
using Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class ProductoUseCases : IProductoUseCases
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoMapper _productoMapper;
        private readonly ICategoriaUseCases _categoriaUseCases;

        public ProductoUseCases(IProductoRepository productoRepository, IProductoMapper productoMapper, ICategoriaUseCases categoriaUseCase)
        {
            _productoRepository = productoRepository;
            _productoMapper = productoMapper;
            _categoriaUseCases = categoriaUseCase;
        }

        public async Task<List<ProductoDTO>> GetAllAsync()
        {
            List<Producto> productos = await _productoRepository.GetAllAsync();
            List<ProductoDTO> productosDTO = new List<ProductoDTO>();

            foreach (Producto producto in productos)
            {
                try
                {
                    if (producto == null)
                    {
                        Console.WriteLine("Producto es null");
                        continue;
                    }

                    Console.WriteLine($"Procesando producto ID: {producto.ProductoID}, CategoriaID: {producto.CategoriaID}");

                    CategoriaDTO? categoria = await _categoriaUseCases.GetByIdAsync(producto.CategoriaID);

                    Console.WriteLine($"Categoría obtenida: {categoria?.NombreCategoria ?? "NULL"}");

                    ProductoDTO productoDTO = _productoMapper.ToDTO(producto, categoria?.NombreCategoria ?? "Sin Categoría");
                    productosDTO.Add(productoDTO);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en producto ID {producto?.ProductoID}: {ex.Message}");
                    throw new Exception($"Error procesando producto ID {producto?.ProductoID}: {ex.Message}", ex);
                }
            }

            return productosDTO;
        }

        public async Task<ProductoDTO?> GetByIdAsync(int id)
        {
            Producto? producto = await _productoRepository.GetByIdAsync(id);

            if (producto is null)
            {
                return null;
            }

            CategoriaDTO? categoria = await _categoriaUseCases.GetByIdAsync(producto.CategoriaID);
            ProductoDTO productoDTO = _productoMapper.ToDTO(producto, categoria?.NombreCategoria ?? "Sin Categoría");

            return productoDTO;
        }

        public async Task<List<ProductoDTO>> GetByCategoriaAsync(int categoriaId)
        {
            List<Producto> productos = await _productoRepository.GetByCategoriaAsync(categoriaId);
            List<ProductoDTO> productosDTO = new List<ProductoDTO>();

            CategoriaDTO? categoria = await _categoriaUseCases.GetByIdAsync(categoriaId);
            string nombreCategoria = categoria?.NombreCategoria ?? "Sin Categoría";

            foreach (Producto producto in productos)
            {
                ProductoDTO productoDTO = _productoMapper.ToDTO(producto, nombreCategoria);
                productosDTO.Add(productoDTO);
            }

            return productosDTO;
        }

        public async Task<bool> CreateAsync(ProductoDTO productoDTO)
        {
            CategoriaDTO categoria = await _categoriaUseCases.GetByNombreAsync(productoDTO.CategoriaNombre);

            Producto producto = _productoMapper.ToEntity(productoDTO, categoria.CategoriaID);

            return await _productoRepository.CreateAsync(producto);
        }

        public async Task<bool> UpdateAsync(ProductoDTO productoDTO)
        {
            CategoriaDTO categoria = await _categoriaUseCases.GetByNombreAsync(productoDTO.CategoriaNombre);

            Producto producto = _productoMapper.ToEntity(productoDTO, categoria.CategoriaID);

            return await _productoRepository.UpdateAsync(producto);
        }

        public async Task<bool> DeleteAsync(int productoId)
        {
            return await _productoRepository.DeleteAsync(productoId);
        }

    }
}
public async Task<Categoria> GetByNombreAsync(string nombreCategoria)
{
    return await _context.CategoriasProducto.FirstOrDefaultAsync(c => c.NombreCategoria == nombreCategoria);
}

public async Task<CategoriaDTO?> GetByNombreAsync(string nombreCategoria)
{
    Categoria? categoria = await _categoriaRepository.GetByNombreAsync(nombreCategoria);

    if(categoria is null)
    {
        return null;
    }

    CategoriaDTO? categoriaDTO = _categoriaMapper.ToDTO(categoria);

    return categoria;
}