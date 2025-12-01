using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace UI.ControllersAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoUseCase _departamentosUseCase;

        public DepartamentosController(IDepartamentoUseCase departamentosUseCase)
        {
            _departamentosUseCase = departamentosUseCase;
        }

        // GET api/departamentos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listado = _departamentosUseCase.getDepartamentos();

                if (listado == null || !listado.Any())
                    return NoContent();

                return Ok(listado);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/departamentos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var departamento = _departamentosUseCase.getDepartamento(id);

                if (departamento == null)
                    return NotFound();

                return Ok(departamento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/departamentos
        [HttpPost]
        public IActionResult Post([FromBody] Departamento departamento)
        {
            try
            {
                int filas = _departamentosUseCase.agregarDepartamento(departamento);

                if (filas == 0)
                    return BadRequest();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/departamentos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamento departamento)
        {
            try
            {
                departamento.Id = id;
                int filas = _departamentosUseCase.actualizarDepartamento(departamento);

                if (filas == 0)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/departamentos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int filas = _departamentosUseCase.eliminarDepartamento(id);

                if (filas == 0)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
