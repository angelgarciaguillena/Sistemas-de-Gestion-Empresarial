using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    /// <summary>
    /// DTO que representa una persona con el departamento que ha sido seleccionado por el usuario para esa persona
    /// </summary>
    public class PersonaConDepartamentoSeleccionado
    {
        /// <summary>
        /// Persona elegida
        /// </summary>
        private Persona _persona;

        /// <summary>
        /// Departamento seleccionado por el usuario para la persona
        /// </summary>
        private Departamento _departamento;

        /// <summary>
        /// Get de la persona del dto PersonaConDepartamentoSeleccionado
        /// </summary>
        public Persona Persona
        {
            get { return _persona; }
        }

        /// <summary>
        /// Get del departamento del dto PersonaConDepartamentoSeleccionado
        /// </summary>
        public Departamento Departamento
        {
            get { return _departamento; }
        }

        /// <summary>
        /// Constructor que inicializa la persona con el departamento seleccionado para esa persona
        /// </summary>
        /// <param name="persona">Persona que se ha elegido</param>
        /// <param name="departamento">Departamento seleccionado para esa persona</param>
        public PersonaConDepartamentoSeleccionado(Persona persona, Departamento departamento)
        {
            _persona = persona;
            _departamento = departamento;
        }
    }
}