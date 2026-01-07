using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interfaz del caso de uso para gestionar la lógica de negocio de las personas
    /// </summary>
    public interface IPersonaUseCase
    {
        /// <summary>
        /// Devuelve la lista de personas con el listado completo de los departamentos disponibles
        /// </summary>
        /// <returns>Lista de personas con departamentos</returns>
        public List<PersonaConListadoDepartamento> getPersonas();

        /// <summary>
        /// Comprueba cuantas personas estan en los departamentos que han sido seleccionados por el usuario
        /// y devuelve el número de aciertos que ha tenido
        /// </summary>
        /// <param name="personas">Lista de personas con el departamento seleccionado por el usuario</param>
        /// <returns>Número de aciertos</returns>
        public int comprobarAciertos(List<PersonaConDepartamentoSeleccionado> personas);
    }
}