using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUseCases
{
    public interface IProductoUseCases
    {
        Task<List<ProductoDTO>> GetAllAsync();
        Task<ProductoDTO?> GetByIdAsync(int id);
        Task<List<ProductoDTO>> GetByCategoriaAsync(int categoriaId);
        Task<bool> CreateAsync(ProductoDTO createDTO);
        Task<bool> UpdateAsync(ProductoDTO updateDTO);
        Task<bool> DeleteAsync(int productoId);
    }
}
