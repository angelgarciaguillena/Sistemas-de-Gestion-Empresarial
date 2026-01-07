using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    /// <summary>
    /// Caso de uso que implementa la lógica de negocio para personas
    /// </summary>
    public class PersonaUseCase : IPersonaUseCase
    {
        /// <summary>
        /// Repositorio de personas
        /// </summary>
        private readonly IPersonaRepository _personaRepository;

        /// <summary>
        /// Caso de uso de departamentos
        /// </summary>
        private readonly IDepartamentoUseCase _departamentoUseCase;

        /// <summary>
        /// Constructor que inyecta las dependencias necesarias
        /// </summary>
        /// <param name="personaRepository">Repositorio de personas</param>
        /// <param name="departamentoUseCase">Caso de uso de departamentos</param>
        public PersonaUseCase(IPersonaRepository personaRepository, IDepartamentoUseCase departamentoUseCase)
        {
            _personaRepository = personaRepository;
            _departamentoUseCase = departamentoUseCase;
        }

        /// <summary>
        /// Devuelve la lista de personas con el listado completo de departamentos disponibles
        /// </summary>
        /// <returns>Lista de personas con departamentos</returns>
        public List<PersonaConListadoDepartamento> getPersonas()
        {
            List<Persona> personas = _personaRepository.getPersonas();
            List<Departamento> departamentos = _departamentoUseCase.getDepartamentos();

            List<PersonaConListadoDepartamento> resultado = new List<PersonaConListadoDepartamento>();

            foreach (Persona persona in personas)
            {
                resultado.Add(new PersonaConListadoDepartamento(persona, departamentos));
            }

            return resultado;
        }

        /// <summary>
        /// Comprueba cuántos departamentos han sido acertados por el usuario
        /// </summary>
        /// <param name="personas">Lista de personas con el departamento seleccionado por el usuario</param>
        /// <returns>Número de aciertos</returns>
        public int comprobarAciertos(List<PersonaConDepartamentoSeleccionado> personas)
        {
            List<Persona> personasReales = _personaRepository.getPersonas();
            int aciertos = 0;

            foreach (PersonaConDepartamentoSeleccionado personaSeleccionada in personas)
            {
                Persona personaReal = personasReales.FirstOrDefault(p => p.Id == personaSeleccionada.Persona.Id);

                if (personaReal != null && personaReal.IdDepartamento == personaSeleccionada.Departamento.Id)
                {
                    aciertos++;
                }
            }

            return aciertos;
        }
    }
}