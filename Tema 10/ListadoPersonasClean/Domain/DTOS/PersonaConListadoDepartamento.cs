using Domain.Entities;
using System.Collections.Generic;

namespace Domain.DTOS
{
    public class PersonaConListadoDepartamento
    {
        public Persona Persona { get; set; }
        public List<Departamento> ListadoDepartamentos { get; set; }

        public PersonaConListadoDepartamento() { }

        public PersonaConListadoDepartamento(Persona persona, List<Departamento> departamentos)
        {
            Persona = persona;
            ListadoDepartamentos = departamentos;
        }
    }
}