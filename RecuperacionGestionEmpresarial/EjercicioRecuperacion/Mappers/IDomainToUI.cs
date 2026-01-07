using Domain.DTOs;
using UI.Models;

namespace UI.Mappers
{
    /// <summary>
    /// Interfaz del mapper que transforma objetos del dominio a objetos de la capa UI
    /// </summary>
    public interface IDomainToUI
    {
        /// <summary>
        /// Transforma un objeto PersonaConListadoDepartamento a PersonaConColor
        /// </summary>
        /// <param name="persona">Persona con listado de departamentos</param>
        /// <returns>Persona con color asignado</returns>
        PersonaConColor transformar(PersonaConListadoDepartamento persona);
    }
}
