using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    /// <summary>
    /// DTO que representa una persona junto con el listado de todos los departamentos disponibles
    /// </summary>
    public class PersonaConListadoDepartamento
    {
        /// <summary>
        /// Persona elegida
        /// </summary>
        private Persona _persona;

        /// <summary>
        /// Lista de los departamentos disponibles
        /// </summary>
        private List<Departamento> _listadoDepartamentos;

        /// <summary>
        /// Get de la persona del dto PersonaConListadoDepartamento
        /// </summary>
        public Persona Persona
        {
            get { return _persona; }
        }

        /// <summary>
        /// Get de la lista de departamentos del dto PersonaConListadoDepartamento
        /// </summary>
        public List<Departamento> ListadoDepartamentos
        {
            get { return _listadoDepartamentos; }
        }

        /// <summary>
        /// Constructor que inicializa la persona con su listado de departamentos
        /// </summary>
        /// <param name="persona">Persona que se va a elegir</param>
        /// <param name="listadoDepartamentos">Lista de departamentos disponibles</param>
        public PersonaConListadoDepartamento(Persona persona, List<Departamento> listadoDepartamentos)
        {
            _persona = persona;
            _listadoDepartamentos = listadoDepartamentos;
        }
    }
}