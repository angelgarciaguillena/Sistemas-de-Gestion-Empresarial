using Domain.DTOs;
using Domain.Interfaces.IUseCases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoUseCases _productoUseCases;

        public ProductoController(IProductoUseCases productoUseCases)
        {
            _productoUseCases = productoUseCases;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>> GetAll()
        {
            ActionResult<List<ProductoDTO>> result;
            try
            {
                var productos = await _productoUseCases.GetAllAsync();
                result = Ok(productos);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, new { message = "Error al obtener los productos", error = ex.Message });
            }
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int id)
        {
            ActionResult<ProductoDTO> result;
            try
            {
                var producto = await _productoUseCases.GetByIdAsync(id);
                result = producto is null
                    ? NotFound(new { message = "Producto no encontrado" })
                    : Ok(producto);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, new { message = "Error al obtener el producto", error = ex.Message });
            }
            return result;
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<List<ProductoDTO>>> GetByCategoria(int categoriaId)
        {
            ActionResult<List<ProductoDTO>> result;
            try
            {
                var productos = await _productoUseCases.GetByCategoriaAsync(categoriaId);
                result = Ok(productos);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, new { message = "Error al obtener los productos por categorÃ­a", error = ex.Message });
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductoDTO productoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool creado = await _productoUseCases.CreateAsync(productoDTO);

                if (!creado)
                {
                    return BadRequest(new { message = "No se pudo crear el producto" });
                }

                return Ok(new { message = "Producto creado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error al crear el producto",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductoDTO productoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != productoDTO.ProductoID)
                {
                    return BadRequest(new { message = "El ID del producto no coincide con el ID de la URL" });
                }

                bool actualizado = await _productoUseCases.UpdateAsync(productoDTO);

                if (!actualizado)
                {
                    return NotFound(new { message = $"Producto con ID {id} no encontrado" });
                }

                return Ok(new { message = "Producto actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error al actualizar el producto",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]-
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool eliminado = await _productoUseCases.DeleteAsync(id);

                if (!eliminado)
                {
                    return NotFound(new { message = $"Producto con ID {id} no encontrado" });
                }

                return NoContent(); // 204 - Eliminado correctamente
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error al eliminar el producto",
                    error = ex.Message
                });
            }
        }
    }
}