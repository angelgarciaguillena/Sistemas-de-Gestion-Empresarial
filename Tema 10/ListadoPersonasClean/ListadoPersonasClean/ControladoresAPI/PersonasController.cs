using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;    


[Route("api/[controller]")]
[ApiController]
public class PersonasController : ControllerBase
{
    private readonly IPersonaUseCase _personasUseCase;

    public PersonasController(IPersonaUseCase personasUseCase)
    {
        _personasUseCase = personasUseCase;
    }

    // GET api/personas
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var listado = _personasUseCase.getPersonas();

            if (listado == null || !listado.Any())
                return NoContent();

            return Ok(listado);
        }
        catch
        {
            return BadRequest();
        }
    }

    // GET api/personas/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var persona = _personasUseCase.getPersona(id);

            if (persona == null)
                return NotFound();

            return Ok(persona);
        }
        catch
        {
            return BadRequest();
        }
    }

    // POST api/personas
    [HttpPost]
    public IActionResult Post([FromBody] Persona persona)
    {
        try
        {
            int filas = _personasUseCase.agregarPersona(persona);

            if (filas == 0)
                return BadRequest();

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    // PUT api/personas/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Persona persona)
    {
        try
        {
            persona.Id = id;
            int filas = _personasUseCase.actualizarPersona(persona);

            if (filas == 0)
                return NotFound();

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    // DELETE api/personas/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            int filas = _personasUseCase.eliminarPersona(id);

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
