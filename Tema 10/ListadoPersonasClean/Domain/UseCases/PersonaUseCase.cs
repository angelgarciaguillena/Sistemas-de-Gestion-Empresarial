using Domain.DTOS;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class PersonaUseCase : IPersonaUseCase
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly IDepartamentoRepositorio _departamentoRepositorio;

        public PersonaUseCase(IPersonaRepositorio personaRepositorio, IDepartamentoRepositorio departamentoRepositorio)
        {
            _personaRepositorio = personaRepositorio;
            _departamentoRepositorio = departamentoRepositorio;
        }

        public List<PersonaConNombreDepartamento> getPersonas()
        {
            var personas = _personaRepositorio.getPersonas();
            var departamentos = _departamentoRepositorio.getDepartamentos();

            var listado = new List<PersonaConNombreDepartamento>();

            foreach (var persona in personas)
            {
                var departamento = departamentos.FirstOrDefault(d => d.Id == persona.IdDepartamento);
                string nombreDepartamento = departamento?.Nombre ?? "No tiene departamento";

                listado.Add(new PersonaConNombreDepartamento(persona, nombreDepartamento));
            }

            return listado;
        }

        public PersonaConNombreDepartamento getPersona(int id)
        {
            var persona = _personaRepositorio.getPersona(id);
            if (persona == null) return null;

            var departamento = _departamentoRepositorio.getDepartamento(persona.IdDepartamento ?? 0);
            string nombreDepartamento = departamento?.Nombre ?? "No tiene departamento";

            return new PersonaConNombreDepartamento(persona, nombreDepartamento);
        }

        public PersonaConListadoDepartamento getPersonaEditar(int id)
        {
            var persona = _personaRepositorio.getPersona(id);

            var departamentos = _departamentoRepositorio.getDepartamentos();

            return new PersonaConListadoDepartamento(persona, departamentos);
        }

        public PersonaConListadoDepartamento getPersonaAgregar()
        {
            var persona = new Persona();

            var departamentos = _departamentoRepositorio.getDepartamentos();

            return new PersonaConListadoDepartamento(persona, departamentos);
        }

        public List<Departamento> getDepartamentos()
        {
            return _departamentoRepositorio.getDepartamentos();
        }

        public int agregarPersona(Persona persona)
        {
            return _personaRepositorio.agregarPersona(persona);
        }

        public int actualizarPersona(Persona persona)
        {
            return _personaRepositorio.actualizarPersona(persona);
        }

        public int eliminarPersona(int id)
        {
            return _personaRepositorio.eliminarPersona(id);
        }
    }
}