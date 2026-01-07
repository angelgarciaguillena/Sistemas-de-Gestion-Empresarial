using Domain.DTOs;
using UI.Models;

namespace UI.Mappers
{
    /// <summary>
    /// Mapper que transforma objetos del dominio a objetos de la capa UI
    /// </summary>
    public class DomainToUI : IDomainToUI
    {
        /// <summary>
        /// Lista de colores asignados a cada departamento
        /// </summary>
        private List<string> colores;

        /// <summary>
        /// Constructor que inicializa los colores para cada departamento
        /// </summary>
        public DomainToUI()
        {
            colores = new List<string>
            {
                "#FFE6E6", // Rosa claro 
                "#E6F3FF", // Azul claro 
                "#E6FFE6", // Verde claro
                "#FFF9E6"  // Amarillo claro
            };
        }

        /// <summary>
        /// Transforma un objeto PersonaConListadoDepartamento a PersonaConColor
        /// </summary>
        /// <param name="persona">Persona con listado de departamentos</param>
        /// <returns>Persona con color asignado para la UI</returns>
        public PersonaConColor transformar(PersonaConListadoDepartamento persona)
        {
            string colorDepartamento = colores[persona.Persona.IdDepartamento - 1];

            return new PersonaConColor(persona.Persona, persona.ListadoDepartamentos, colorDepartamento);
        }
    }
}